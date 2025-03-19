using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Add the visual elements to check, what I have in my db
namespace Poliklinika_DB_UI {
  public partial class DatabaseForm : Form {

    // SQL command for creating a new database
    // Using COLLATE Latin1_General_100_CI_AS_SC_UTF8 to get uft8 support for unicode characters
    // verbatim string for readability
    string createTablesCommand =
      @"      
      ALTER DATABASE Poliklinika COLLATE Latin1_General_100_CI_AS_SC_UTF8;
      USE Poliklinika;

      CREATE TABLE Pacienti (PacientaKartinasNumurs int NOT NULL, Uzvards nvarchar(30), Vards nvarchar(20), Iela nvarchar (50), Maja int, Dzivoklis int, Pilseta nvarchar (20), Rajons nvarchar (20), PastaIndekss nvarchar (10), TelefonaNumurs nvarchar (20), PRIMARY KEY (PacientaKartinasNumurs)); 
      CREATE TABLE Konsultacijas (KonsultacijasNumurs nvarchar(15) NOT NULL, Nosaukums nvarchar (100), Cena float, PRIMARY KEY (KonsultacijasNumurs)); 
      CREATE TABLE Arsti (ArstaPersonasKods nvarchar(15) NOT NULL, Uzvards nvarchar (30), Vards nvarchar (20), TelefonaNumurs nvarchar (20), Epasts nvarchar (50), PRIMARY KEY (ArstaPersonasKods)); 
      CREATE TABLE Kabineti (KabinetaNumurs int NOT NULL, Nosaukums nvarchar (100), TelefonaNumurs nvarchar (20), PRIMARY KEY (KabinetaNumurs));
      CREATE TABLE Registrs (Datums date, KonsultacijasSakums time, KonsultacijasBeigas time, KabinetaNumurs int, KonsultacijasNumurs nvarchar(15), ArstaPersonasKods nvarchar (15), PacientaKartinasNumurs int, PRIMARY KEY (Datums, KonsultacijasSakums, KabinetaNumurs, KonsultacijasNumurs, ArstaPersonasKods, PacientaKartinasNumurs), CONSTRAINT FK_KabinetaNumurs FOREIGN KEY (KabinetaNumurs) REFERENCES Kabineti (KabinetaNumurs), CONSTRAINT FK_KonsultacijasNumurs FOREIGN KEY (KonsultacijasNumurs) REFERENCES Konsultacijas (KonsultacijasNumurs), CONSTRAINT FK_ArstaPersonasKods FOREIGN KEY (ArstaPersonasKods) REFERENCES Arsti (ArstaPersonasKods), CONSTRAINT FK_PacientaKartinasNumurs FOREIGN KEY (PacientaKartinasNumurs) REFERENCES Pacienti (PacientaKartinasNumurs));";

    // SQL command for inserting data (for the second call)
    string insertDataCommand =
      @"INSERT INTO Pacienti VALUES ('2025-0001', 'Ozola', 'Madara', 'Rīgas', '32', '5', 'Liepāja', 'Liepājas', 'LV – 3401', '+37126612345'), ('2025-0002', 'Bērziņš', 'Linards', 'Kokles', '15', '65', 'Rīga', 'Rīgas', 'LV – 1029', '+37124494859'), ('2025-0003', 'Kļaviņa', 'Lauma', 'Tērbatas', '14', '10', 'Valmiera', 'Valmieras', 'LV – 4201', '+37125516868'), ('2025-0004', 'Kārkliņš', 'Elvijs', 'Ainavu', '4', '2', 'Sigulda', 'Siguldas', 'LV – 2150', '+37129912323'), ('2025-0005', 'Liepa', 'Ilga', 'Ābeļu', '5', '1', 'Jelgava', 'Jelgavas', 'LV-3008', '+37129912366');
     INSERT INTO Konsultacijas VALUES ('2025-0001-01', 'Ginekologa konsultācija', '80'), ('2025-0002-02', 'Urologa konsultācija', '50'), ('2025-0003-03', 'Operējoša Otolaringologa (LOR) konsultācija', '65'), ('2025-0004-04', 'Neiroķirurga konsultācija bērnam', '4.72'), ('2025-0005-05', 'Rentgens (RTG, radioloģisks izmeklējums, nosūtījums obligāts)', '50');
     INSERT INTO Arsti VALUES ('180593-26655', 'Dzērve', 'Jānis', '+3712211668', 'janis.dzerve@poliklinika.lv'), ('120286-12233', 'Žagata', 'Līga', '+3713344755', 'liga.zagata@poliklinika.lv'), ('200675-36600', 'Lakstīgala', 'Daina', '+3714455883', 'daina.lakstigala@poliklinika.lv'), ('151168-41166', 'Krauklis', 'Kristaps', '+3715566991', 'kristaps.krauklis@poliklinika.lv'), ('261066-53311', 'Dzenis', 'Mārtiņš', '+3716677123', 'martins.dzenis@poliklinika.lv');
     INSERT INTO Kabineti VALUES ('105', 'Ginekologs', '+3716755123'),  ('202', 'Urologs', '+3716731122'), ('304', 'Otolaringologs', '+3716753005'), ('403', 'Neiroķirurgs', '+3716741978'), ('501', 'Radiologs', '+3716791357');
     INSERT INTO Registrs  VALUES ('2025.03.21', '09:30:00', '09:45:00', '105', '2025-0001-01', '180593-26655', '2025-0001'), ('2025.03.30', '11:45:00', '12:00:00', '202', '2025-0002-02', '120286-12233', '2025-0002'), ('2025.04.14', '12:00:00', '12:15:00', '304', '2025-0003-03', '200675-36600', '2025-0003'), ('2025.04.21', '08:20:00', '08:40:00', '403', '2025-0004-04', '151168-41166', '2025-0004'), ('2025.06.06', '17:10:00', '17:20:00', '501', '2025-0005-05', '261066-53311', '2025-0005');";

    string queryTablesCommand = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'\r\n";

    public DatabaseForm () {
      InitializeComponent();
    }
    private void DatabaseForm_Load (object sender, EventArgs e) {
      fillCombobox();
    }

    private void createDB_Click (object sender, EventArgs e) {

      // Creating the connection to the database
      SqlConnection databaseConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Poliklinika;Trusted_Connection=True;");


      // Creating a new SQL command for creating the database
      SqlCommand createDB = new SqlCommand(createTablesCommand, databaseConnection);
      // Creating a new SQL command for inserting data (for the second call)
      SqlCommand insertData = new SqlCommand(insertDataCommand, databaseConnection);

      try {

        /*
        1. Opening the connection to the database
        2. Executing the SQL command to create the database
        3. Running a confirmation message
         */

        databaseConnection.Open();


        createDB.ExecuteNonQuery();
        // Making the second call for inserting data
        insertData.ExecuteNonQuery();


        //MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK);
        MessageBox.Show("DataBase is created Successfully", "Poliklinika db", MessageBoxButtons.OK);


      } catch (System.Exception ex) {
        MessageBox.Show(ex.ToString(), "Could not create the database", MessageBoxButtons.OK);

      } finally {
        /*
        1. Opening the database connection
        2. Closing the database connection, if it is open
         */
        if (databaseConnection.State == ConnectionState.Open) {
          databaseConnection.Close();

        }
      }
    }

    private void fillCombobox () {

      SqlConnection databaseConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Poliklinika;Trusted_Connection=True;");
      SqlCommand queryTables = new SqlCommand(queryTablesCommand, databaseConnection);


      try {
        // Connecting to the database and reading the tables
        databaseConnection.Open();
        SqlDataReader reader = queryTables.ExecuteReader();

        // While there are rows to read, we add them to the combobox
        while (reader.Read()) {
          tableSelection.Items.Add(reader.GetString(0));
        }

        // Checking, if the dropdown is empty
        if (tableSelection.Items.Count == 0) {
          MessageBox.Show(tableSelection.ToString(), "The dropdown is empty", MessageBoxButtons.OK);
        }

        tableSelection.SelectedIndex = 0;

      } catch (System.Exception ex) {
        MessageBox.Show(ex.ToString(), "Could not read from the database", MessageBoxButtons.OK); // immeadietly went to this
      } finally {
        if (databaseConnection.State == ConnectionState.Open) {
          databaseConnection.Close();
        }
      }
    }

    //Next Steps:
    //Create a method to load and display data from the selected table into the DataGridView.
    //Attach this method to the ComboBox’s SelectedIndexChanged event so that when the user picks a different table, the DataGridView updates accordingly.
    private void tableSelect_SelectedIndexChanged (object sender, EventArgs e) {
      // selecting tables - user interaction
    }
    private void databaseDataGrid_CellContentClick (object sender, DataGridViewCellEventArgs e) {
      // table 1
    }


    private void databaseNavigator_RefreshItems (object sender, EventArgs e) {
      // table 1
    }


  }
}

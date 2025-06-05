using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poliklinika_DB_UI.Properties;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Add the visual elements to check, what I have in my db
namespace Poliklinika_DB_UI {
  public partial class DatabaseForm : Form {

     /*
      * SQL commands for creating a new database and inserting data.
      * The commands are read from an external SQL file to keep the code clean.
     */
    string createTablesCommand = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateTables.sql"));
    string insertDataCommand = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InsertData.sql"));
    string queryTablesCommand = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'\r\n";

    // Creating the connection to the database
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Poliklinika;Integrated Security=True;";

     public DatabaseForm () {
      InitializeComponent();

      // Setting the DataGridView to automatically resize all its columns
      tableDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


     }
    private void DatabaseForm_Load (object sender, EventArgs e) {
      fillCombobox();
    }

    private void createDB_Click (object sender, EventArgs e) {

      // Creating the connection to the database
      SqlConnection databaseConnection = new SqlConnection(connectionString);


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

       try {

        createDB.ExecuteNonQuery();
        MessageBox.Show("Tables created successfully!");

        } catch (Exception ex1) {
            MessageBox.Show("Could not create the tables: " + ex1.Message);
        }

       try {

        insertData.ExecuteNonQuery();
        MessageBox.Show("Data inserted successfully!");

        } catch (Exception ex1) {
            MessageBox.Show("Could not insert the data: " + ex1.Message);
        }
                

      } catch (System.Exception ex) {
        MessageBox.Show(ex.ToString(), "Could not connect to the database", MessageBoxButtons.OK);
       
       } finally {

        MessageBox.Show("DataBase is created Successfully", "Poliklinika db", MessageBoxButtons.OK);

       //Closing the database connection, if it is open
        if (databaseConnection.State == ConnectionState.Open) {
          databaseConnection.Close();

        }
      }
    }

    private void fillCombobox () {

      SqlConnection databaseConnection = new SqlConnection(connectionString);
      SqlCommand queryTables = new SqlCommand(queryTablesCommand, databaseConnection);

      try {
        // Connecting to the database and reading the tables
        databaseConnection.Open();
        SqlDataReader tableReader = queryTables.ExecuteReader();

        // While there are rows to read, we add them to the combobox
        while (tableReader.Read()) {
          tableSelector.Items.Add(tableReader.GetString(0));
        }

        // Checking, if the dropdown is empty
        if (tableSelector.Items.Count == 0) {
          MessageBox.Show(tableSelector.ToString(), "The dropdown is empty", MessageBoxButtons.OK);
        }

        tableSelector.SelectedIndex = 0; // no data, apparently?

      } catch (System.Exception ex) {
        MessageBox.Show(ex.ToString(), "Could not read from the database", MessageBoxButtons.OK); 
      } finally {
        if (databaseConnection.State == ConnectionState.Open) {
          databaseConnection.Close();
        }
      }
    }

    //Attach this method to the ComboBox’s SelectedIndexChanged event so that when the user picks a different table, the DataGridView updates accordingly.
    private void displayTableData () {

      SqlConnection databaseConnection = new SqlConnection(connectionString);
      SqlCommand queryTables = new SqlCommand(queryTablesCommand, databaseConnection);
      SqlDataAdapter tableDataAdapter = new SqlDataAdapter();

      try {
       databaseConnection.Open();

       if (tableSelector.SelectedItem == null) {
            MessageBox.Show("Please select a table first.");
             return;
        }

       string selectedTable = tableSelector.SelectedItem.ToString();

        // Building the SQL query for selecting the table with an interpolated string to dynamically select the selected table values.
        string selectQuery = $"SELECT * FROM [{selectedTable}]";

       // Executing the select query
       tableDataAdapter.SelectCommand = new SqlCommand(
            selectQuery, databaseConnection);

       DataSet tableDataSet = new DataSet(selectedTable);

        // Filling the data set with the selected table
        tableDataAdapter.Fill(tableDataSet);

        // Binding the selected table from the data set to the DataGridView component.
        dataBindingSource.DataSource = tableDataSet.Tables [0];

        tableDataGridView.DataSource = dataBindingSource;
        } catch (System.Exception ex) {
        MessageBox.Show(ex.ToString(), "Could not display the table", MessageBoxButtons.OK); // immeadietly went to this
      } finally {
        if (databaseConnection.State == ConnectionState.Open) {
          databaseConnection.Close();
        }
      }
    }

    private void tableSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayTableData();
        }

   private void addRows_Click(object sender, EventArgs e) {

      string selectedTable = tableSelector.SelectedItem?.ToString();

      if (selectedTable == null) {
        MessageBox.Show("Please select a table first.");
        return;
      }

      SqlConnection databaseConnection = new SqlConnection(connectionString);

    // Getting columns and data types for the user-selected table
     string getTableColumnsCommand = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = [{selectedTable}]";

     SqlCommand getColumns = new SqlCommand(getTableColumnsCommand, databaseConnection);

      // Initializing table reader here to have access to it in try/catch block
      SqlDataReader tableReader = null;

       try {
          databaseConnection.Open();
          tableReader = getColumns.ExecuteReader();

          List<(string columnName, string dataType)> columns = new List<(string, string)>();

          while (tableReader.Read()) {
             // Gettting the first column from the result set - the column name
             string columnName = tableReader.GetString(0);

             // Getting the second column from the result set - the data type
             string dataType = tableReader.GetString(1);

             columns.Add((columnName, dataType));
           }

          // Looping through column names and data types
          foreach (var (columnName, dataType) in columns) {

            Label columnLabel = new Label();
            columnLabel.Text = columnName;
            columnLabel.AutoSize = true;

           // Adding the label to the panel
           addRecordsPanel.Controls.Add(columnLabel);

           Control inputControl;

           if (dataType == "int") {
              inputControl = new NumericUpDown();
            } else if (dataType == "varchar" || dataType == "nvarchar") {
              inputControl = new System.Windows.Forms.TextBox();
            } else if (dataType == "date") {
              inputControl = new DateTimePicker();
              ((DateTimePicker)inputControl).Format = DateTimePickerFormat.Short;
             } else if (dataType == "time") {
               inputControl = new DateTimePicker();
               // Setting the format to time and showing the up/down arrow to select the time
               ((DateTimePicker)inputControl).Format = DateTimePickerFormat.Time;
               ((DateTimePicker)inputControl).ShowUpDown = true;
             } else {
               // Defaulting to textbox if nothing else applies
               inputControl = new System.Windows.Forms.TextBox();
             }

             // Setting a name to identify the control later
             inputControl.Name = "input_" + columnName;

             // Adding the input control to the form panel
             addRecordsPanel.Controls.Add(inputControl);

           }

       } catch (System.Exception ex) {
           MessageBox.Show(ex.ToString(), "Could not read tables columns and types from the database", MessageBoxButtons.OK);
        } finally {

           // Closing the table reader, if it is open
           if (tableReader != null && !tableReader.IsClosed) {
            tableReader.Close();
          }
           if (databaseConnection.State == ConnectionState.Open) {
                databaseConnection.Close();
            }
          }

        }

   }
}

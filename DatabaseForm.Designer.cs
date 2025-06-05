namespace Poliklinika_DB_UI {
  partial class DatabaseForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            this.createDB = new System.Windows.Forms.Button();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableSelector = new System.Windows.Forms.ComboBox();
            this.addRows = new System.Windows.Forms.Button();
            this.deleteRecords = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addRecordsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveNewRecordsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // createDB
            // 
            this.createDB.Location = new System.Drawing.Point(12, 364);
            this.createDB.Name = "createDB";
            this.createDB.Size = new System.Drawing.Size(75, 23);
            this.createDB.TabIndex = 0;
            this.createDB.Text = "Create DB";
            this.createDB.UseVisualStyleBackColor = true;
            this.createDB.Click += new System.EventHandler(this.createDB_Click);
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Location = new System.Drawing.Point(15, 114);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.Size = new System.Drawing.Size(776, 214);
            this.tableDataGridView.TabIndex = 1;
            // 
            // tableSelector
            // 
            this.tableSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableSelector.FormattingEnabled = true;
            this.tableSelector.Location = new System.Drawing.Point(15, 59);
            this.tableSelector.Name = "tableSelector";
            this.tableSelector.Size = new System.Drawing.Size(121, 21);
            this.tableSelector.TabIndex = 3;
            this.tableSelector.SelectedIndexChanged += new System.EventHandler(this.tableSelector_SelectedIndexChanged);
            // 
            // addRows
            // 
            this.addRows.Location = new System.Drawing.Point(118, 364);
            this.addRows.Name = "addRows";
            this.addRows.Size = new System.Drawing.Size(75, 23);
            this.addRows.TabIndex = 4;
            this.addRows.Text = "Add records";
            this.addRows.UseVisualStyleBackColor = true;
            this.addRows.Click += new System.EventHandler(this.addRows_Click);
            // 
            // deleteRecords
            // 
            this.deleteRecords.Location = new System.Drawing.Point(221, 364);
            this.deleteRecords.Name = "deleteRecords";
            this.deleteRecords.Size = new System.Drawing.Size(92, 23);
            this.deleteRecords.TabIndex = 5;
            this.deleteRecords.Text = "Delete records";
            this.deleteRecords.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Edit records";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete all data";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // addRecordsPanel
            // 
            this.addRecordsPanel.Location = new System.Drawing.Point(808, 102);
            this.addRecordsPanel.Name = "addRecordsPanel";
            this.addRecordsPanel.Size = new System.Drawing.Size(305, 305);
            this.addRecordsPanel.TabIndex = 8;
            // 
            // saveNewRecordsButton
            // 
            this.saveNewRecordsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNewRecordsButton.Location = new System.Drawing.Point(1038, 425);
            this.saveNewRecordsButton.Name = "saveNewRecordsButton";
            this.saveNewRecordsButton.Size = new System.Drawing.Size(75, 23);
            this.saveNewRecordsButton.TabIndex = 0;
            this.saveNewRecordsButton.Text = "Save entry";
            this.saveNewRecordsButton.UseVisualStyleBackColor = true;
            this.saveNewRecordsButton.Visible = false;
            this.saveNewRecordsButton.Click += new System.EventHandler(this.saveNewRecordsButton_Click);
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 456);
            this.Controls.Add(this.saveNewRecordsButton);
            this.Controls.Add(this.addRecordsPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteRecords);
            this.Controls.Add(this.addRows);
            this.Controls.Add(this.tableSelector);
            this.Controls.Add(this.tableDataGridView);
            this.Controls.Add(this.createDB);
            this.Name = "DatabaseForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DatabaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button createDB;
    private System.Windows.Forms.DataGridView tableDataGridView;
    private System.Windows.Forms.BindingSource dataBindingSource;
    private System.Windows.Forms.ComboBox tableSelector;
        private System.Windows.Forms.Button addRows;
        private System.Windows.Forms.Button deleteRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel addRecordsPanel;
        private System.Windows.Forms.Button saveNewRecordsButton;
    }
}


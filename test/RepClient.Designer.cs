namespace test
{
    partial class RepClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TravelerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TravelDataSet = new test.TravelDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TravelerTableAdapter = new test.TravelDataSetTableAdapters.TravelerTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TravelerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TravelerBindingSource
            // 
            this.TravelerBindingSource.DataMember = "Traveler";
            this.TravelerBindingSource.DataSource = this.TravelDataSet;
            // 
            // TravelDataSet
            // 
            this.TravelDataSet.DataSetName = "TravelDataSet";
            this.TravelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TravelerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "test.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(978, 583);
            this.reportViewer1.TabIndex = 0;
            // 
            // TravelerTableAdapter
            // 
            this.TravelerTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RepClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 583);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RepClient";
            this.Text = "Отчет по клиентам";
            this.Load += new System.EventHandler(this.RepClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TravelerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TravelerBindingSource;
        private TravelDataSet TravelDataSet;
        private TravelDataSetTableAdapters.TravelerTableAdapter TravelerTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}
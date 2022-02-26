namespace test
{
    partial class OtchetTransport
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
            this.TransportWithoutIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TravelDataSet = new test.TravelDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TransportWithoutIdTableAdapter = new test.TravelDataSetTableAdapters.TransportWithoutIdTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransportWithoutIdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TransportWithoutIdBindingSource
            // 
            this.TransportWithoutIdBindingSource.DataMember = "TransportWithoutId";
            this.TransportWithoutIdBindingSource.DataSource = this.TravelDataSet;
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
            reportDataSource1.Value = this.TransportWithoutIdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "test.transportwithoutid.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1135, 419);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // TransportWithoutIdTableAdapter
            // 
            this.TransportWithoutIdTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(964, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtchetTransport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OtchetTransport";
            this.Text = "Отчет по транспорту";
            this.Load += new System.EventHandler(this.OtchetTransport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransportWithoutIdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TransportWithoutIdBindingSource;
        private TravelDataSet TravelDataSet;
        private TravelDataSetTableAdapters.TransportWithoutIdTableAdapter TransportWithoutIdTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}
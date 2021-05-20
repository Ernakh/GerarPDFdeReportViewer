using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GerarPDFdeReportViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();

            ReportViewer Rv = new ReportViewer();
            //ReportParameter[] Rp = new ReportParameter[3];
            //BindingSource Bs = new BindingSource();
            //ReportDataSource Rds = new ReportDataSource();
            //DataTable Dt = new DataTable("Teste");
            //DataRow Dr;

            //Rp[0] = new ReportParameter("Name", "Name", true);
            //Rp[1] = new ReportParameter("Age", "Age", true);
            //Rp[2] = new ReportParameter("Phone", "Phone", true);

            //Dt.Columns.Add("Name", typeof(string));
            //Dt.Columns.Add("Age", typeof(string));
            //Dt.Columns.Add("Phone", typeof(string));

            //for (int i = 0; i < 5; i++)
            //{
            //    Dr = Dt.NewRow();
            //    Dr["Name"] = "Vini " + i * i + 2;
            //    Dr["Age"] = "12 " + i + i + Math.PI;
            //    Dr["Phone"] = "2134 " + i + i / 0.5;

            //    Dt.Rows.Add(Dr);
            //}
            //Bs.DataSource = Dt;
            //Rds.Name = Dt.TableName;
            //Rds.Value = Bs.DataSource;

            Rv.ProcessingMode = ProcessingMode.Local;
            Rv.LocalReport.ReportPath = @"D:\DropBox\Dropbox\Compartilhamento Professor Fabrício Londero\GerarPDFdeReportViewer\GerarPDFdeReportViewer\Report1.rdlc";
            //Rv.LocalReport.SetParameters(Rp);
            //Rv.LocalReport.DataSources.Add(Rds);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = Rv.LocalReport.Render(
            "Pdf", null, out mimeType, out encoding,
             out extension,
            out streamids, out warnings);

            FileStream fs = new FileStream(@"C:\Users\fisma\Desktop\output.pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            System.Diagnostics.Process.Start(@"C:\Users\fisma\Desktop\output.pdf");
        }
    }
}

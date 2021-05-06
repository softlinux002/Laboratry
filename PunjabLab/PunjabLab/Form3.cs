using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PunjabLab
{
    public partial class Form3 : Form
    {
        public static string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string datalogicFilePath = Path.Combine(StartupPath, "punjablab.sdf");
        public static string connectionString = string.Format("DataSource={0}", datalogicFilePath);
        SqlCeConnection con = new SqlCeConnection(connectionString);

        string constr = "Data Source=D:\\PunjabLab\\PunjabLab\\bin\\Debug\\punjablab.sdf;";

        public Form3()
        {
            InitializeComponent();
             
            reportViewer1.Height = this.Height - 20;
            reportViewer1.Width = this.Width - 2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ReportDataSet dsCustomers = Display();
            ReportDataSource datasource = new ReportDataSource("ReportDataSet", dsCustomers.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
            reportViewer1.Height = this.Height - 20;
            reportViewer1.Width = this.Width - 2;
        }


        public ReportDataSet Display()
        {
            string data = Form1.invoiceno;
            SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT TOP 1 [LDL] as LDL,[VLDL] as VLDL,[RBC] as RBC,* FROM report order by id desc", con);
            DataTable dt = new DataTable();
            //da.Fill(dt);
            using (ReportDataSet dsCustomers = new ReportDataSet())
            {
                da.Fill(dsCustomers, "ReportDataSet");
                return dsCustomers;
            }
        }

        //private ReportDataSet GetData()
        //{

        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM report order by id desc"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (ReportDataSet dsCustomers = new ReportDataSet())
        //                {
        //                    sda.Fill(dsCustomers, "ReportDataSet");
        //                    return dsCustomers;
        //                }
        //            }
        //        }
        //    }

            //using (punjablabEntities2 context = new punjablabEntities2())
            //{
            //    ReportDataSet dsCustomers = new ReportDataSet();
            //    DataTable dt = new DataTable();

            //    //dsCustomers = context.reports.ToList();
            //    report rep = new report();
            //    var data = (from z in context.reports orderby z.id descending select z).FirstOrDefault();
            //    dt=data.CopyToDataTable();
            //    dsCustomers.Tables.Add(dt);

            //    SqlDataAdapter sda = new SqlDataAdapter();

            //        sda.Fill(dt, "ReportDataSet");
            //        return dsCustomers;
                
            //}
        
    }
}

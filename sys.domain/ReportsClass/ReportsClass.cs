using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Windows.Forms;

namespace sys.domain
{
    public class ReportsClass
    {
        static string report_path = Application.StartupPath + "\\reports\\";
        //static string report_path = "D:\\Dir\\Terriniel Scales System\\EVERGREEN\\Weighing_System_v.1c.0\\sys.domain\\ReportsFile\\";

        public static void print_ticket(long id, sys.domain.connection_string conn, sys.domain.Validation.TransactionValidation.TICKET_STATE state)
       {
           string str = "";
           string mate_str;
           string client_str = "";
         //  string origin_str = "";
           using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(conn))
           {
               str = dbx.Transactions.Where(EF_expressions.wh_id(id)).AsQueryable().ToTraceQuery();
               var t = dbx.Transactions.Where(EF_expressions.wh_id(id)).FirstOrDefault();
               mate_str = dbx.Raw_materials.Where(a=>a.mate_code==t.mate_code).AsQueryable().ToTraceQuery();
               client_str = dbx.Clients.Where(a => a.client_code == t.client_code).AsQueryable().ToTraceQuery();
           }
            sys.domain.ReportsDataSource.ReportsDataSource rr = new sys.domain.ReportsDataSource.ReportsDataSource();
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(conn.connection);
            System.Data.SqlClient.SqlDataAdapter sq = new System.Data.SqlClient.SqlDataAdapter(str, sc);
            sq.Fill(rr, "Transactions");

            sq = new System.Data.SqlClient.SqlDataAdapter(mate_str, sc);
            //Clipboard.SetText(qry);
            sq.Fill(rr, "Raw_materials");


            sq = new System.Data.SqlClient.SqlDataAdapter(client_str, sc);
            //Clipboard.SetText(qry);
            sq.Fill(rr, "Clients");

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(report_path + "tkt.rpt");

           switch (state)
           {
               case Validation.TransactionValidation.TICKET_STATE.WEIGH_IN:
                   rpt.DataDefinition.FormulaFields["is_WEIGH_IN"].Text = "true"; 
                   rpt.DataDefinition.FormulaFields["is_WEIGH_OUT"].Text = "false";
                   break;
               case Validation.TransactionValidation.TICKET_STATE.WEIGH_OUT:
                   rpt.DataDefinition.FormulaFields["is_WEIGH_IN"].Text = "false";
                   rpt.DataDefinition.FormulaFields["is_WEIGH_OUT"].Text = "true";
                   break;
               case Validation.TransactionValidation.TICKET_STATE.ALL: 
                    rpt.DataDefinition.FormulaFields["is_WEIGH_IN"].Text = "true"; 
                    rpt.DataDefinition.FormulaFields["is_WEIGH_OUT"].Text = "true";
                    break;

           }
            
 
            //sys.domain.ReportsFile.tkt rpt = new sys.domain.ReportsFile.tkt();
            rpt.SetDataSource(rr);

            System.Windows.Forms.PrintDialog  printPrompt= new System.Windows.Forms.PrintDialog();

            printPrompt.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            printPrompt.AllowSomePages = true;

            //printPrompt.PrinterSettings.PrinterName = "Send To OneNote 2013"
            //printPrompt.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"

            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            //rpt.Refresh();
            rpt.PrintToPrinter(printPrompt.PrinterSettings, printPrompt.PrinterSettings.DefaultPageSettings, false);
       }

        public static void export_to_pdf(long id, sys.domain.connection_string conn, sys.domain.Validation.TransactionValidation.TICKET_STATE state)
        {
            string str = "";
            string mate_str;
            string client_str = "";
            string origin_str = "";
            sys.domain.trns.Transactions t = new trns.Transactions();
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(conn))
            {
                str = dbx.Transactions.Where(EF_expressions.wh_id(id)).AsQueryable().ToTraceQuery();
                t = dbx.Transactions.Where(EF_expressions.wh_id(id)).FirstOrDefault();
                mate_str = dbx.Raw_materials.Where(a => a.mate_code == t.mate_code).AsQueryable().ToTraceQuery();
                client_str = dbx.Clients.Where(a => a.client_code == t.client_code).AsQueryable().ToTraceQuery();
            }
            sys.domain.ReportsDataSource.ReportsDataSource rr = new sys.domain.ReportsDataSource.ReportsDataSource();
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(conn.connection);
            System.Data.SqlClient.SqlDataAdapter sq = new System.Data.SqlClient.SqlDataAdapter(str, sc);
            sq.Fill(rr, "Transactions");

            sq = new System.Data.SqlClient.SqlDataAdapter(mate_str, sc);
            //Clipboard.SetText(qry);
            sq.Fill(rr, "Raw_materials");


            sq = new System.Data.SqlClient.SqlDataAdapter(client_str, sc);
            //Clipboard.SetText(qry);
            sq.Fill(rr, "Clients");

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(report_path + "exp.rpt");

            //sys.domain.ReportsFile.tkt rpt = new sys.domain.ReportsFile.tkt();
            rpt.SetDataSource(rr);

            System.Windows.Forms.PrintDialog printPrompt = new System.Windows.Forms.PrintDialog();

            printPrompt.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            printPrompt.AllowSomePages = true;

            //printPrompt.PrinterSettings.PrinterName = "Send To OneNote 2013"
            //printPrompt.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"

            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            printPrompt.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            //rpt.Refresh();
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\PDF FILES\\" + t.receipt_no + "(" + t.license_plate + ")");
            //rpt.PrintToPrinter(printPrompt.PrinterSettings, printPrompt.PrinterSettings.DefaultPageSettings, false);
        }


        public static void print_gen(string qry, sys.domain.connection_string conn, ref CrystalDecisions.Windows.Forms.CrystalReportViewer crviewer)
        {
            sys.domain.ReportsDataSource.ReportsDataSource rr = new sys.domain.ReportsDataSource.ReportsDataSource();

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(conn.connection);
            System.Data.SqlClient.SqlDataAdapter sq = new System.Data.SqlClient.SqlDataAdapter(qry, sc);
            //Clipboard.SetText(qry);
            sq.Fill(rr, "Transactions");
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(report_path + "gen.rpt");
            rpt.SetDataSource(rr);
            crviewer.ReportSource = rpt;

            //sys.domain.ReportsFile.gen gen = new sys.domain.ReportsFile.gen();
            //gen.SetDataSource(rr);
            //crviewer.ReportSource = gen;



        }

        public static void print_tracker(string qry, sys.domain.connection_string conn, ref CrystalDecisions.Windows.Forms.CrystalReportViewer crviewer)
        {
            ReportsDataSource.ReportsDataSource rr = new sys.domain.ReportsDataSource.ReportsDataSource();
            sys.domain.ReportsFile.tracker tracker = new sys.domain.ReportsFile.tracker();
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(conn.connection);
            System.Data.SqlClient.SqlDataAdapter da;

            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(conn))
            {
                da = new System.Data.SqlClient.SqlDataAdapter(qry, sc);
                da.Fill(rr, "Transactions");

                string tracker_qry = dbx.Tracker_time.Select(a => a).AsQueryable().ToTraceQuery();
                da = new System.Data.SqlClient.SqlDataAdapter(tracker_qry, sc);
                da.Fill(rr, "Tracker_time");
            }

            rpt.Load(report_path + "tracker.rpt");


            rpt.SetDataSource(rr);

            //tracker.SetDataSource(rr);
            crviewer.ReportSource = rpt;
        }
    }

    public static class Iext
    {
        public static string ToTraceQuery<T>(this IQueryable<T> query)
        {
            ObjectQuery<T> objectQuery = GetQueryFromQueryable(query);

            var result = objectQuery.ToTraceString();
            foreach (var parameter in objectQuery.Parameters)
            {
                var name = "@" + parameter.Name;
                var value = "'" + parameter.Value.ToString() + "'";
                result = result.Replace(name, value);
            }
            return result;
        }

        private static System.Data.Entity.Core.Objects.ObjectQuery<T> GetQueryFromQueryable<T>(IQueryable<T> query)
        {
            var internalQueryField = query.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("_internalQuery")).FirstOrDefault();
            var internalQuery = internalQueryField.GetValue(query);
            var objectQueryField = internalQuery.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("_objectQuery")).FirstOrDefault();
            return objectQueryField.GetValue(internalQuery) as System.Data.Entity.Core.Objects.ObjectQuery<T>;
        }

        public static string ToTraceString<T>(this IQueryable<T> query)
        {
            ObjectQuery<T> objectQuery = GetQueryFromQueryable(query);

            var traceString = new StringBuilder();

            traceString.AppendLine(objectQuery.ToTraceString());
            traceString.AppendLine();

            foreach (var parameter in objectQuery.Parameters)
            {
                traceString.AppendLine(parameter.Name + " [" + parameter.ParameterType.FullName + "] = " + parameter.Value);
            }

            return traceString.ToString();
        }
    }
}

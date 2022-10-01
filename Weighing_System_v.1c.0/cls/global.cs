using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weighing_System_v._1c._0
{

    public class global
    {
        public static void select_next_control(MetroFramework.Forms.MetroForm frm, KeyEventArgs e)
        {
            if (e.Alt | e.Control | e.Shift == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (frm.ActiveControl is MetroFramework.Controls.MetroButton) return;
                    frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
                }
            }
        }

        public static cl2_init.stp settings = new cl2_init.stp { acspp = "mijochanel122208" };
        public static sys.domain.connection_string main_conn_str = new sys.domain.connection_string { datasource = settings.INI_SERVERNAME, catalog = settings.INI_CATALOG, user_id = settings.INI_SQLUID, password = settings.INI_SQLPWD, integrated_security = false };

        //public static mfr_mn Mfr_mn = new mfr_mn();

        public static cl2_g3n_._crpt0MD5 crypter = new cl2_g3n_._crpt0MD5("JOJO");
    
        public static sys.domain.adm.Users logged_in_user;
        public static sys.domain.dbs.Stations station;
    }


    public static class exntensions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable EQToDataTable(System.Collections.IEnumerable parIList)
        {
            System.Data.DataTable ret = new System.Data.DataTable();
            try
            {
                System.Reflection.PropertyInfo[] ppi = null;
                if (parIList == null)
                    return ret;
                foreach (var itm in parIList)
                {
                    if (ppi == null)
                    {
                        ppi = ((System.Type)itm.GetType()).GetProperties();
                        foreach (System.Reflection.PropertyInfo pi in ppi)
                        {
                            System.Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (object.ReferenceEquals(colType.GetGenericTypeDefinition(), typeof(System.Nullable<>))))
                                colType = colType.GetGenericArguments()[0];
                            ret.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
                        }
                        if (ppi.Count() == 0)
                        {
                            //if (typeof() is 
                            // {

                            // }
                        }
                    }

                    System.Data.DataRow dr = ret.NewRow();
                    foreach (System.Reflection.PropertyInfo pi in ppi)
                    {
                        dr[pi.Name] = pi.GetValue(itm, null) == null ? DBNull.Value : pi.GetValue(itm, null);
                    }
                    ret.Rows.Add(dr);
                }
                //foreach (System.Data.DataColumn c in ret.Columns)
                //{
                //    //c.ColumnName = c.ColumnName.Replace("_", " ");
                //}
            }
            catch
            {
                ret = new System.Data.DataTable();
            }
            return ret;
        }
     
    }

    public static class gen_method
    {

        public static void srch_db(ref MetroFramework.Controls.MetroGrid dg, string vle, string fld1,string fld2)
        {
            if (vle == string.Empty)
            {
                return;
            };

            //if (fld == string.Empty)
            //{
            //    return;
            //};

            if (dg.Rows.Count == 0) return;
            DataGridViewRow drw = (DataGridViewRow)dg.Rows.Cast<DataGridViewRow>()
                .Where(r => (String)r.Cells[fld1].Value.ToString() == vle || r.Cells[fld2].Value.ToString().Contains(vle)).FirstOrDefault();

            if ((drw == null))
            {
                dg.Rows[0].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = 0;
                dg.CurrentCell = dg.Rows[0].Cells[fld1];
            }
            else
            {
                dg.Rows[drw.Index].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = drw.Index;
                dg.CurrentCell = dg.Rows[drw.Index].Cells[fld1];
            }
        }

        public static void upd_dg(MetroFramework.Controls.MetroGrid dg, DataTable upd)
        {
            foreach (DataColumn s in upd.Columns)
            {
                if (s.DataType.ToString() == "System.Boolean") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<bool>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.String") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<string>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.Int16") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<Int16>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.Int32") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<Int32>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.Int64") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<Int64>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.DateTime") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<DateTime>(s.ColumnName).ToString(); }
                if (s.DataType.ToString() == "System.Double") { dg.CurrentRow.Cells[s.ColumnName].Value = upd.Rows[0].Field<double>(s.ColumnName).ToString(); }
            };
        }

        public static int GetLengthLimit(object obj, string field)
        {
            int dblenint = 0;   // default value = we can't determine the length

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            // Find the Linq 'Column' attribute
            // e.g. [Column(Storage="_FileName", DbType="NChar(256) NOT NULL", CanBeNull=false)]
            object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
            // Assume there is just one
            if (info.Length == 1)
            {
                ColumnAttribute ca = (ColumnAttribute)info[0];
                string dbtype = ca.TypeName;

                if (dbtype.StartsWith("NChar") || dbtype.StartsWith("NVarChar"))
                {
                    int index1 = dbtype.IndexOf("(");
                    int index2 = dbtype.IndexOf(")");
                    string dblen = dbtype.Substring(index1 + 1, index2 - index1 - 1);
                    int.TryParse(dblen, out dblenint);
                }
            }
            return dblenint;
        }

        public static int ComputeAge(DateTime bday)
        {
            DateTime dt_now;
            dt_now = System.DateTime.Now;
            TimeSpan result = dt_now.Subtract(bday);

            int myage = dt_now.Year - bday.Year;

            int comparer = dt_now.Month - bday.Month;

            if (comparer == 0)
            {
                if ((dt_now.Day - bday.Day) < 0)
                {
                    myage = myage - 1;
                }
            }
            else if (comparer < 0)
            {
                myage = myage - 1;
            }

            return myage;

        }

        public static byte[] cnvrt_img(Image myImage)
        {
            if (myImage != null)
            {
                System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                myImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] myBytes = new byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(myBytes, 0, Convert.ToInt32(mstream.Length));
                return myBytes;
            }
            else
            {
                return null;
            }
        }

        public static void sv_phto(Image img, string tbl, string pic_fld, string k_id, string k_val, string cstm = "")
        {
            if ((img == null))
                return;
            string src = "UPDATE " + tbl + " set " + pic_fld + "=(@ImageData) where " + k_id + "= " + k_val + "";
            if (!string.IsNullOrEmpty(cstm))
                src = cstm;

            //System.Data.SqlServerCe.SqlCeCommand cmd = new System.Data.SqlServerCe.SqlCeCommand(src, global.connectCE1());
            //System.Data.SqlServerCe.SqlCeParameter param = new System.Data.SqlServerCe.SqlCeParameter("@ImageData", SqlDbType.VarBinary);
            //byte[] ImageData = cnvrt_img(img);
            //param.Value = ImageData;
            //cmd.Parameters.Add(param);
            //cmd.ExecuteNonQuery();
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    return ms.ToArray();
                }
            }
            else
            {
                return null;
            }

        }

        public static void clear_mem(object[] objs)
        {
            GC.Collect();
            GC.Collect();
            foreach (object obj in objs)
            {
                GC.SuppressFinalize(obj);
                if (obj is MetroFramework.Forms.MetroForm) { MetroFramework.Forms.MetroForm mfr = (MetroFramework.Forms.MetroForm)obj; mfr.Dispose(); };
            }
        }
    }


}

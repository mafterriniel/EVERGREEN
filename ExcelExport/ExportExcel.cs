using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;

namespace ExcelExport
{
    public class ExportExcel
    {

        public System.Windows.Forms.Label lbl { get; set; }
        public string excel_file_path { get; set; }

        private Microsoft.Office.Interop.Excel.Application _excel_app = default(Microsoft.Office.Interop.Excel.Application);
        private Microsoft.Office.Interop.Excel.Workbook _work_book;
        private Microsoft.Office.Interop.Excel.Worksheet _work_sheet;
        public Microsoft.Office.Interop.Excel.Worksheet work_sheet
        {
            get { return _work_sheet; }
            set { _work_sheet = value; }
        }
        public sys.domain.connection_string connection_string { get; set; }
        public void save()
        {
            try
            {
                if (_work_book == null) return;
                _work_book.Save();
            }
            catch (Exception ex)
            {
                releaseObjects();
                throw new Exception(ex.Message);
            }
        }

        public Expression trans_expression { get; set; }
        private List<sys.domain.trns.Transactions> _transaction_records;
        public List<sys.domain.trns.Transactions> transaction_records
        {
            get { return _transaction_records; }
            set { _transaction_records = value; }
        }


        private bool verify_access_to_file()
        {
            bool res = true;
            _excel_app = new Microsoft.Office.Interop.Excel.Application();
            _excel_app.DisplayAlerts = false;
            FileStream stream = null;
            try
            {
                stream = System.IO.File.Open(excel_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                stream.Close();
                return res;
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task update_excel_delivery_tracker()
        {
            try
            {
                if (!verify_access_to_file()) return;

                excel_file_path = System.IO.Path.GetTempPath() + "\\mm.xlsx";
                System.IO.File.Delete(excel_file_path);
                byte[] buf = ExcelExport.Properties.Resources.Delivery_tracker;
                System.IO.File.WriteAllBytes(excel_file_path, buf);

                _excel_app = new Microsoft.Office.Interop.Excel.Application();
                _excel_app.DisplayAlerts = false;
                _work_book = _excel_app.Workbooks.Open(excel_file_path);
                _work_sheet = (Microsoft.Office.Interop.Excel.Worksheet)_work_book.Worksheets.get_Item(1);

                long rec_count = 1;
                string rn = "4";

                await Task.Run(() =>
                    {
                        foreach (var t in transaction_records)
                        {
                            if (transaction_records.Count() != rec_count)
                            {
                                Range RngToCopy = _work_sheet.get_Range("A" + rn).EntireRow;
                                Range RngToInsert = _work_sheet.get_Range("A" + (Convert.ToDouble(rn) + 1).ToString()).EntireRow;
                                RngToInsert.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, RngToCopy.Copy(Type.Missing));
                            }

                            _work_sheet.Range["A" + rn].Value = rec_count;
                            _work_sheet.Range["B" + rn].Value = t.client_code;
                            _work_sheet.Range["C" + rn].Value = t.receipt_no;
                            _work_sheet.Range["D" + rn].Value = t.truckscale_no;
                            _work_sheet.Range["E" + rn].Value = t.license_plate;
                            _work_sheet.Range["F" + rn].Value = t.driver_name;
                            _work_sheet.Range["G" + rn].Value = t.mate_code;
                            _work_sheet.Range["H" + rn].Value = t.reg_dt.Value.ToString("HH:mm");
                            _work_sheet.Range["I" + rn].Value = t.checker_name;

                          for (int i=t.time_reg_col.Value;i<t.dt_in_col.Value;i++)
                            {
                                  _work_sheet.Range[tracker_cell(i) + rn].Cells.Interior.Color = XlRgbColor.rgbRed;
                            }

                          if (t.dt_out_col == null)
                          {
                              _work_sheet.Range[tracker_cell(t.dt_in_col.Value) + rn].Cells.Interior.Color = XlRgbColor.rgbGreen;
                          }
                          else
                          {
                              for (int i = t.dt_in_col.Value; i < t.dt_out_col.Value; i++)
                              {
                                  _work_sheet.Range[tracker_cell(i) + rn].Cells.Interior.Color = XlRgbColor.rgbGreen;
                              }
                              _work_sheet.Range[tracker_cell(t.dt_out_col.Value) + rn].Cells.Interior.Color = XlRgbColor.rgbYellow;
                          }


                            rec_count += 1;
                            rn = (Convert.ToInt64(rn) + 1).ToString();

                            if (lbl != null)
                            {
                                if (lbl.InvokeRequired)
                                {
                                    lbl.Invoke(new MethodInvoker(delegate { lbl.Text = rec_count.ToString(); }));
                                }
                            }
                        }
                    });


                _work_book.Save();
                _work_book.Close(Type.Missing, Type.Missing, Type.Missing);
                releaseObjects();



                SaveFileDialog Ofp = new SaveFileDialog();
                Ofp.DefaultExt = "Excel File[*.xlsx]|";
                Ofp.AddExtension = false;
                Ofp.Filter = "Excel File [*.xlsx]|*.xlsx";

                if (Ofp.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

                if (string.IsNullOrEmpty(Ofp.FileName) == false)
                {
                    if (System.IO.File.Exists(Ofp.FileName))
                    {
                        System.IO.File.Replace(excel_file_path, Ofp.FileName, System.IO.Path.GetTempPath() + "\\tmp.xlsx");
                    }
                    else
                    {
                        System.IO.File.Copy(excel_file_path, Ofp.FileName);
                    }
                }


            }
            catch (Exception ex) { releaseObjects(); throw new Exception(ex.Message); }

        }

        public async Task update_master_sheet()
        {
            try
            {
                //if (!verify_access_to_file()) return;

                excel_file_path = System.IO.Path.GetTempPath() + "\\mm.xlsx";
                System.IO.File.Delete(excel_file_path);
                byte[] buf = ExcelExport.Properties.Resources.master_sheet;
                System.IO.File.WriteAllBytes(excel_file_path, buf);
                _excel_app = new Microsoft.Office.Interop.Excel.Application();
                _excel_app.DisplayAlerts = false;
                _work_book = _excel_app.Workbooks.Open(excel_file_path);
                _work_sheet = (Microsoft.Office.Interop.Excel.Worksheet)_work_book.Worksheets.get_Item(1);

                long rec_count = 1;
                string rn = "5";

                await Task.Run(() =>
                {
                    foreach (var t in transaction_records)
                    {
                        if (transaction_records.Count() != rec_count)
                        {
                            Range RngToCopy = _work_sheet.get_Range("A" + rn).EntireRow;
                            Range RngToInsert = _work_sheet.get_Range("A" + (Convert.ToDouble(rn) + 1).ToString()).EntireRow;
                            RngToInsert.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, RngToCopy.Copy(Type.Missing));
                        }

                        _work_sheet.Range["A" + rn].Value = t.dt_in.Value.ToString("MMM-dd-yyyy");
                        _work_sheet.Range["B" + rn].Value = t.receipt_no;
                        _work_sheet.Range["C" + rn].Value = t.truckscale_no;
                        _work_sheet.Range["D" + rn].Value = t.gate_pass;
                        _work_sheet.Range["E" + rn].Value = t.client_code;
                        _work_sheet.Range["F" + rn].Value = t.mate_code;
                        _work_sheet.Range["G" + rn].Value = t.origin_code;
                        _work_sheet.Range["H" + rn].Value = t.license_plate;
                        _work_sheet.Range["I" + rn].Value = t.driver_name;
                        _work_sheet.Range["J" + rn].Value = t.gross_wt;
                        _work_sheet.Range["K" + rn].Value = t.tare_wt;
                        _work_sheet.Range["L" + rn].Value = t.net_wt;
                        _work_sheet.Range["M" + rn].Value = t.reg_dt.Value.ToString("HH:mm");
                        _work_sheet.Range["N" + rn].Value = t.dt_in.Value.ToString("HH:mm");
                        _work_sheet.Range["O" + rn].Value = t.waiting_time;
                        _work_sheet.Range["P" + rn].Value = t.dt_out.HasValue ? t.dt_out.Value.ToString("HH:mm") : "";
                        _work_sheet.Range["Q" + rn].Value = t.elapsed_time;
                        _work_sheet.Range["R" + rn].Value = t.weigher_in;
                        _work_sheet.Range["S" + rn].Value = t.remarks;
                        _work_sheet.Range["U" + rn].Value = t.checker_name;
                        rec_count += 1;
                        rn = (Convert.ToInt64(rn) + 1).ToString();

                        if (lbl != null)
                        {
                            if (lbl.InvokeRequired)
                            {
                                lbl.Invoke(new MethodInvoker(delegate { lbl.Text = rec_count.ToString(); }));
                            }
                        }

                    }
                });
                _work_sheet.Range["I" + rn].Value = "=SUM(I5:I" + (Convert.ToInt64(rn) - 1).ToString() + ")";
                _work_sheet.Range["J" + rn].Value = "=SUM(J5:J" + (Convert.ToInt64(rn) - 1).ToString() + ")";
                _work_sheet.Range["K" + rn].Value = "=SUM(K5:K" + (Convert.ToInt64(rn) - 1).ToString() + ")";
               

                _work_book.Save();
                _work_book.Close(Type.Missing, Type.Missing, Type.Missing);
                releaseObjects();


                SaveFileDialog Ofp = new SaveFileDialog();
                Ofp.DefaultExt = "Excel File[*.xlsx]|";
                Ofp.AddExtension = false;
                Ofp.Filter = "Excel File [*.xlsx]|*.xlsx";

                if (Ofp.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

                if (string.IsNullOrEmpty(Ofp.FileName) == false)
                {
                    if (System.IO.File.Exists(Ofp.FileName))
                    {
                        System.IO.File.Replace(excel_file_path, Ofp.FileName, System.IO.Path.GetTempPath() + "\\tmp.xlsx");
                    }
                    else
                    {
                        System.IO.File.Copy(excel_file_path, Ofp.FileName);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(int handle, out int processId);

        public void releaseObjects()
        {
            try
            {
                int ProId;
                GetWindowThreadProcessId(_excel_app.Hwnd, out ProId);
                //to kill current process of excel
                Process[] AllProcesses = Process.GetProcessesByName("excel");
                foreach (Process ExcelProcess in AllProcesses)
                {
                    if (ExcelProcess.Id == ProId)
                    {
                        ExcelProcess.Kill();
                    }
                }
                AllProcesses = null;
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_work_sheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_work_book);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_excel_app);
                _excel_app = null;
                _work_book = null;
                _work_sheet = null;

                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                //_work_book.Close();
                //excel_app.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(excel_app); excel_app = null;
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(_work_book); _work_book = null;
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(_work_sheet); _work_sheet = null;
                //System.Runtime.InteropServices.Marshal.CleanupUnusedObjectsInCurrentContext();

                //GC.SuppressFinalize(_work_sheet);
                //GC.SuppressFinalize(_work_book);
                //GC.SuppressFinalize(excel_app);
                //GC.Collect();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //System.IO.File.Delete(xlspath);
        }

        private string tracker_cell(int cellno)
        {
            int i = 0;
            string tracker_lttr = "";
            i += 1; if (cellno == i) tracker_lttr = "J";
            i += 1; if (cellno == i) tracker_lttr = "K";
            i += 1; if (cellno == i) tracker_lttr = "L";
            i += 1; if (cellno == i) tracker_lttr = "M";
            i += 1; if (cellno == i) tracker_lttr = "N";
            i += 1; if (cellno == i) tracker_lttr = "O";
            i += 1; if (cellno == i) tracker_lttr = "P";
            i += 1; if (cellno == i) tracker_lttr = "Q";
            i += 1; if (cellno == i) tracker_lttr = "R";
            i += 1; if (cellno == i) tracker_lttr = "S";
            i += 1; if (cellno == i) tracker_lttr = "T";
            i += 1; if (cellno == i) tracker_lttr = "U";
            i += 1; if (cellno == i) tracker_lttr = "B";
            i += 1; if (cellno == i) tracker_lttr = "W";
            i += 1; if (cellno == i) tracker_lttr = "X";
            i += 1; if (cellno == i) tracker_lttr = "Y";
            i += 1; if (cellno == i) tracker_lttr = "Z";
            i += 1; if (cellno == i) tracker_lttr = "AA";
            i += 1; if (cellno == i) tracker_lttr = "AB";
            i += 1; if (cellno == i) tracker_lttr = "AC";
            i += 1; if (cellno == i) tracker_lttr = "AD";
            i += 1; if (cellno == i) tracker_lttr = "AE";
            i += 1; if (cellno == i) tracker_lttr = "AF";
            i += 1; if (cellno == i) tracker_lttr = "AG";
            i += 1; if (cellno == i) tracker_lttr = "AH";
            return tracker_lttr;

        }

 
        //=======================================================
        //Service provided by Telerik (www.telerik.com)
        //Conversion powered by NRefactory.
        //Twitter: @telerik
        //Facebook: facebook.com/telerik
        //=======================================================

    }

}

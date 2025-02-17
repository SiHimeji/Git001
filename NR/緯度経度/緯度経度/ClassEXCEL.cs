using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;　//COM 追加

namespace 緯度経度
{
    static public class ClassEXCEL
    {



        static public void Excel(string filename, System.Windows.Forms.TextBox tx)
        {

            double shop_ido = 0;
            double shop_keido = 0;
            double ido = 0;
            double keido = 0;
            double km = 0;
            int y = 2;
            string buf;
            //' EXCEL関連オブジェクトの定義
            Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Range Range = null;

            app = new Microsoft.Office.Interop.Excel.Application();
            book=  app.Workbooks.Open(filename);
            sheet = book.Worksheets[1];

            app.Visible = true;
            buf = sheet.Cells[y, 1].value;

            while (  buf  !="" || buf != null) {
                buf = sheet.Cells[y, 6].value;

                if ( buf.Trim() != "" ||  buf != null)
                {
                    buf = sheet.Cells[y, 12].value;
                    if (buf.Trim() != "" || buf != null)
                    {


                        ido = double.Parse(sheet.Cells[y, 6].value);
                        keido = double.Parse(sheet.Cells[y, 7].value);

                        shop_ido  = double.Parse(sheet.Cells[y, 12].value);
                        shop_keido = double.Parse(sheet.Cells[y, 13].value);


                        if (shop_ido != 0)
                        {
                            km = ClassDistance.cal_distance4(shop_ido, shop_keido, ido, keido);
                            sheet.Cells[y, 14].value = km.ToString();
                        }
                    }
                }
                y++;
                tx.Text=y.ToString();
                System.Windows.Forms.Application.DoEvents();
                buf = sheet.Cells[y, 1].value;
            }

            book.Save();
            book.Close();

            // EXCEL解放
            Marshal.ReleaseComObject(Range);
            Marshal.ReleaseComObject(book);
            Marshal.ReleaseComObject(app);
            Marshal.ReleaseComObject(sheet);
            Range = null;
            sheet = null;
            book = null;
            app = null;
            MessageBox.Show("END");
        }

    }
}

using spClassOracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 緯度経度
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eXCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Worksheets|*.xlsx;*.xls";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                    ClassEXCEL.Excel(filename,textBoxKyori);


                }
            }
        }

        private void oRACLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double km = 0;
            double shop_keido, shop_ido, keido, ido;
            ClassOracle classOracle = new ClassOracle();
            classOracle.SetDatabe();
            string strSQL = $@"
                        select city_section_cd,
                               j_ido8,
                               j_keido8,
                               shop_keido,
                               shop_ido,
                               km
                          from tb_idokeido2
                          where city_section_cd like '{textBoxken.Text}%'
                          and  shop_cd is not null
                    ";
            DataTable dt = null;
            dt = classOracle.SetDataTable(strSQL);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["shop_keido"].ToString().Trim() != "")
                {
                    if ( dr["j_ido8"].ToString().Trim() != "") { 

                        shop_keido = double.Parse(dr["shop_keido"].ToString());
                        shop_ido = double.Parse(dr["shop_ido"].ToString());
                        ido = double.Parse(dr["j_ido8"].ToString());
                        keido = double.Parse(dr["j_keido8"].ToString());
                        km = Math.Round(  ClassDistance.cal_distance4(shop_ido, shop_keido, ido, keido)/1000,3);

                    this.textBoxIdoFrom.Text = shop_ido.ToString();
                    this.textBoxKeidoFrom.Text = shop_keido.ToString();
                    this.textBoxKeidoTo.Text = keido.ToString();
                    this.textBoxIdoTo.Text = ido.ToString();

                    strSQL = $@"update tb_idokeido2 set km ='{km.ToString()}' where city_section_cd='{dr["city_section_cd"].ToString()}'";
                    classOracle.execSQL(strSQL);

                    this.textBoxKyori.Text = km.ToString();
                    System.Windows.Forms.Application.DoEvents();

                    }
                }

            }

        }
    }
}

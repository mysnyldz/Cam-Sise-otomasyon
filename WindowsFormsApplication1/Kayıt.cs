using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source=Y_kyt.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        DataTable tablo = new DataTable();
        DataSet dset = new DataSet();
        void listele()
        {
            tablo.Clear();
            con.Open();
            OleDbDataAdapter adpt = new OleDbDataAdapter("Select * From Y_kyt", con);
            adpt.Fill(tablo);
            adpt.Dispose();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("İlgili Yerleri Doldurunuz!", "Lütfen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen kullanıcı adını giriniz!", "",MessageBoxButtons.OK);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz!", "", MessageBoxButtons.OK);
            }
            else if (textBox3.Text!=textBox2.Text)
            {
                MessageBox.Show("şifreleriniz uyuşmamaktadır!", "", MessageBoxButtons.OK);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen gizli bir yanıt giriniz!", "", MessageBoxButtons.OK);
            }
            else
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ("INSERT INTO Y_kyt(K_adı,S_1,S_2,G_Yanit) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')");
                cmd.ExecuteNonQuery();
                con.Close();
                listele();
                MessageBox.Show("Kaydınız Başarıyla gerçekleştirildi!", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }
    }
}

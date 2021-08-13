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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Y_kyt.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader dr;
            OleDbDataAdapter dtadpt = new OleDbDataAdapter();
            con.Open();            
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Y_kyt WHERE K_adı='" + textBox1.Text + "' AND S_1='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (textBox1.Text=="admin" && textBox2.Text=="1453")
            {
                Yönetici frm = new Yönetici();
                frm.FormClosed += frm_FormClosed;
                frm.Show();
                this.Visible = false;
            }
            else if (dr.Read())
            {
                Müşteri müs = new Müşteri();
                müs.FormClosed += müs_FormClosed;
                müs.Show();
                this.Visible = false;
                
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış Tekrar Deneyiniz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        void müs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayıt kyt = new Kayıt();
            kyt.Show();
        }
    }
}

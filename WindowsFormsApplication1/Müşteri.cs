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
    public partial class Müşteri : Form
    {
        public Müşteri()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source=sipariş.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "JPEG Files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg|All Files (*.*)|*.*";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog2.FileName);
                    textBox5.Text = openFileDialog2.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg|All Files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                    textBox6.Text = openFileDialog1.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && maskedTextBox1.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("İlgili Yerleri Doldurunuz!", "Lütfen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Firmanızın adını giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Adresinizi giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen E-posta adresinizi giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen sipariş adedini giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else if (comboBox1.Text=="")
            {
                MessageBox.Show("Lütfen şişenizin materyalini giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Lütfen Cep telefonunuzu giriniz!", "Uyarı!", MessageBoxButtons.OK);
            }
            else
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ("INSERT INTO sipariş(F_ismi,C_tel,E_post,S_t,Adres,S_adedi,Pers,Etkt) VALUES ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + openFileDialog2.FileName + "','" + openFileDialog1.FileName + "')");
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ürününüz Elimize ulaşmıştır!", "Tamamlandı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

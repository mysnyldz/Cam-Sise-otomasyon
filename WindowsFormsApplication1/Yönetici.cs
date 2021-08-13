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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Yönetici : Form
    {
        public Yönetici()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source=sipariş.mdb");
        OleDbCommand cmd = new OleDbCommand();
        DataTable tablo = new DataTable();
        DataSet dset = new DataSet();
        public string Kimlik;

        void listele()
        {
            tablo.Clear();
            con.Open();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From sipariş", con);
            adptr.Fill(tablo);
            adptr.Fill(dset, "sipariş");
            adptr.Dispose();
            dataGridView1.DataSource = dset.Tables["sipariş"];
            con.Close();
        }


        private void btnekle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ("INSERT INTO sipariş(F_ismi,C_tel,E_post,S_t,Adres,S_adedi,Pers,Etkt) VALUES ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + openFileDialog1.FileName + "','" + openFileDialog2.FileName + "')");
            dataGridView1.Refresh();
            cmd.ExecuteNonQuery();   
            con.Close();
            MessageBox.Show("Ürününüz Elimize ulaşmıştır!", "Tamamlandı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.siparişTableAdapter2.Fill(this.siparişDataSet3.sipariş);
        }

        private void Yönetici_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'siparişDataSet3.sipariş' table. You can move, or remove it, as needed.
            this.siparişTableAdapter2.Fill(this.siparişDataSet3.sipariş);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            con.Open();
            string komut="DELETE from sipariş where Kimlik=@P1";
            cmd = new OleDbCommand(komut, con);
            cmd.Parameters.AddWithValue("@P1", Kimlik);
            cmd.ExecuteNonQuery();
            con.Close();
            this.siparişTableAdapter2.Fill(this.siparişDataSet3.sipariş);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btngun_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE sipariş set F_ismi='" + textBox1.Text + "',C_tel='" + maskedTextBox1.Text + "',E_post='" + textBox2.Text + "',S_adedi='" + textBox3.Text + "',S_t='" + comboBox1.Text + "',Adres='" + textBox4.Text + "',Pers='" + textBox5.Text + "',Etkt='" + textBox6.Text + "' Where Kimlik=" + Kimlik + "";
            cmd.ExecuteNonQuery();
            con.Close();
            this.siparişTableAdapter2.Fill(this.siparişDataSet3.sipariş);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Kimlik = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = textBox5.Text;
            pictureBox2.ImageLocation = textBox6.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg|All Files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    textBox5.Text = openFileDialog1.FileName.ToString();
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
                openFileDialog2.Filter = "JPEG Files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg|All Files (*.*)|*.*";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog2.FileName);
                    textBox6.Text = openFileDialog2.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}

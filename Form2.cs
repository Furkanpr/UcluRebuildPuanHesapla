using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rebuild
{
    public partial class Form2 : Form
    {
        int Toplam;
        int ligGol, ligAsist, ligKaleci;
        int avrupaGol, avrupaAsist ,avrupaKaleci;
        int verim , verimGol, verimAsist,verimKaleci;
        public string kullanıcı;

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand guncelle = new SqlCommand("Update Table_1 Set  Verim = @a2, GolVerim = @a3, AsistVerim = @a4, KaleciVerim = @a5 where KullanıcıAd=@a6  ", sql);
            guncelle.Parameters.AddWithValue("@a2",txtverim.Text);
            guncelle.Parameters.AddWithValue("@a3",txtgol.Text);
            guncelle.Parameters.AddWithValue("@a4",txtasist.Text);
            guncelle.Parameters.AddWithValue("@a5",txtkaleci.Text);
            guncelle.Parameters.AddWithValue("@a6",kullanıcı);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");

            sql.Close();
        }

        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=Furkan\\MSSQLSERVER01;Initial Catalog=Rebuild;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            cmbliggol.Text = 0.ToString();
            cmbligasist.Text = 0.ToString();
            cmbligkaleci.Text = 0.ToString();

            cmbavrupagol.Text = 0.ToString();
            cmbavrupaasist.Text = 0.ToString();
            cmbavrupakaleci.Text = 0.ToString();

            txtverim.Text= 0.ToString();
            txtgol.Text= 0.ToString();
            txtasist.Text= 0.ToString();
            txtkaleci.Text= 0.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ligGol= Convert.ToInt16(cmbliggol.Text);
            ligAsist=Convert.ToInt16(cmbligasist.Text);
            ligKaleci=Convert.ToInt16(cmbligkaleci.Text);

            avrupaGol=Convert.ToInt16(cmbavrupagol.Text);
            avrupaAsist=Convert.ToInt16(cmbavrupaasist.Text);
            avrupaKaleci=Convert.ToInt16(cmbavrupakaleci.Text);

            verim=Convert.ToInt16(txtverim.Text);
            verimGol=Convert.ToInt16(txtgol.Text);
            verimAsist=Convert.ToInt16(txtasist.Text);
            verimKaleci=Convert.ToInt16(txtkaleci.Text);
            Toplam = ((ligGol + ligAsist + ligKaleci)  + (avrupaGol + avrupaAsist + avrupaKaleci) + (verim));
            label18.Text=Toplam.ToString();

            Form3 frm = new Form3();
            frm.ShowDialog();
            this.Close();

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }
    }
}

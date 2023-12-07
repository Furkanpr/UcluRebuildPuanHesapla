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
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ToplamPuan;
        int ligSıralama, ligPuan, ligAveraj;
        int kupa = 0;
        int faCup = 0;
        int sampiyonlarLigiGruplar = 0, sampiyonlarligiElemeler;
        
        SqlConnection sql = new SqlConnection("Data Source=Furkan\\MSSQLSERVER01;Initial Catalog=Rebuild;Integrated Security=True");
        
        
      
        private int LigSıralamahesapla()
        {
            if (comboBox1.Text == "1.")
             ligSıralama = 250;
            else if (comboBox1.Text == "2.")
                ligSıralama = 150;
            else if (comboBox1.Text == "3.")
                ligSıralama = 100;
            else if (comboBox1.Text == "4.")
                ligSıralama = 50;
            else if (comboBox1.Text == "5.")
                ligSıralama = 25;
            else if (comboBox1.Text == "6+")
                ligSıralama = 0;

            return ligSıralama;
        } 
        private int elemeTurları()
        {


            if (comboBox5.Text == "Son 16")
                sampiyonlarligiElemeler = 50;
            else if (comboBox5.Text == "Çeyrek Final")
                sampiyonlarligiElemeler = 100;
            else if (comboBox5.Text == "Yarı Final")
                sampiyonlarligiElemeler = 150;
            else if (comboBox5.Text == "Final")
                sampiyonlarligiElemeler = 250;
            else if (comboBox5.Text == "Şampiyon")
                sampiyonlarligiElemeler = 500;
            else if (comboBox5.Text == "0")
                sampiyonlarligiElemeler = 0;

            return sampiyonlarligiElemeler;
        }
        private int KupaHesapla()
        {
            if (comboBox2.Text == "Şampiyon")
                kupa=50;
            else if (comboBox2.Text == "İkinci")
                kupa = 25;
            else if (comboBox2.Text == "Yarı Final")
                kupa = 10;
               else if (comboBox2.Text == "0")
                kupa = 0;


            return kupa;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text != "")
            {


                Form2 frm = new Form2();
                frm.kullanıcı = comboBox10.Text;
                frm.ShowDialog();
                this.Close();
            }    
        }

        private int FACupHesapla()
        {
            if (comboBox3.Text == "Şampiyon")
                faCup=50;
            else if (comboBox3.Text == "İkinci")
                faCup= 25;
            else if (comboBox3.Text == "Yarı Final")
                faCup= 10;
            else if (comboBox3.Text == "0")
                faCup= 0;

            return faCup;
        }
      


        private void button1_Click(object sender, EventArgs e)
        {
         
           
            label12.Text=LigSıralamahesapla().ToString();
            ligPuan = Convert.ToInt16(textBox1.Text);
            ligAveraj= Convert.ToInt16(textBox2.Text);
            label13.Text = ligPuan.ToString();
            label14.Text = ligAveraj.ToString();
           label16.Text = KupaHesapla().ToString();
            label17.Text = FACupHesapla().ToString();
            label19.Text=elemeTurları().ToString();
            sampiyonlarLigiGruplar =Convert.ToInt16(comboBox4.Text);
            label18.Text=sampiyonlarLigiGruplar.ToString();

            ToplamPuan = ligPuan + ligAveraj + ligSıralama+kupa+faCup+sampiyonlarLigiGruplar + sampiyonlarligiElemeler;
            label15.Text=ToplamPuan.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label11.Text = "Yarı final öncesi eleme turlarında \n elendiğiniz takım Şampiyon Oldumu ?";
            label23.Text = "Yarı final öncesi eleme turlarında \n elendiğiniz takım Şampiyon Oldumu ?";
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            comboBox5.Text = 0.ToString();
            comboBox4.Text = 0.ToString();
            comboBox3.Text = 0.ToString();
            comboBox2.Text = 0.ToString();
            comboBox1.Text = 0.ToString();


        }
    }
}

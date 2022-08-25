using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormApp
{
    public partial class Form2 : Form
    {
        DataTable tablo = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                dataGridView1.Refresh();
            }
            timer1.Start();

            tablo.Columns.Add("ID", typeof(int));
            tablo.Columns.Add("USERNAME", typeof(object));
            tablo.Columns.Add("PASSWORD", typeof(object));
            tablo.Columns.Add("GENDER", typeof(string));
            tablo.Columns.Add("AGE", typeof(int));
            

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tablo;


            MessageBox.Show("Login Successful!\n\nWelcome");

        }

        public void button1_Click(object sender, EventArgs e)
        {
            tablo.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            dataGridView1.DataSource = tablo;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill in all blank fields!");
            }

            else
            {
                MessageBox.Show("Adding Successful!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Please select registration");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {           //Harf dışında herhangi bir sayı veya özel karakter girilememesi için
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar);
            
            //IsLetter--> Belirtilen unicode karakterinin unicode harfi olarak kategorilere ayrılmadığını gösterir
            //IsControl--> Belirtilen unicode karakterinin bir denetim karakteri olarak kategorilere ayrılmadığını gösterir
            //IsSeparator--> Belirtilen dizedeki karakterinin ayırıcı karakter olarak kategorilere ayrılmadığını gösterir
        }
    }
}

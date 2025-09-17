using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gun1_25._08
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string dosyaYolu2 = @"C:\Veriler\siniflar.txt";
            richTextBox1.Text = File.ReadAllText(dosyaYolu2);

            string dosyaYolu = @"C:\Bilgiler\siniflar2.txt";
            richTextBox2.Text = File.ReadAllText(dosyaYolu);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JakaGrafia
{
    public partial class Form1 : Form
    {
        //show first window
        public Form1()
        {
            InitializeComponent();
        }

        // przycisk do rankingu
        private void button1_Click(object sender, EventArgs e)
        {
            KlasyfikacjaKrytriow ClassificationCriteria = new KlasyfikacjaKrytriow();
            ClassificationCriteria.Show();
        }

        //przycisk do konfigu
        private void button2_Click(object sender, EventArgs e)
        {
            config windowConfig = new config();
            windowConfig.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // przycisk od kontaku
        private void button3_Click(object sender, EventArgs e)
        {
            // tu tworzy obekt z nowym oknem i go wyswietla
            Contact windowContact = new Contact();
            windowContact.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

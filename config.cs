using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JakaGrafia
{
    public partial class config : Form
    {
        // table string graphiics card
        string[] listGraphics;

        // table textBox
        TextBox[] listTextBox;

        // object to read stream from file
        StreamReader sr = new StreamReader("graphicsCard.txt");
        
        public config()
        {
            InitializeComponent();
            listGraphics = new string[20] ;
            try
            {
                // make obejct to read stream from file
                sr = new StreamReader("graphicsCard.txt");
                
                //Continue to read until you reach end of file
                for (int i = 0; i < 20; i++)
                {
                    listGraphics[i] = sr.ReadLine();
                }
                sr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("błąd odczytu pliku");

                listGraphics = new string[] {
                                            "Zotac GeForce GTX 1080 Arctic Storm 8GB GDDR5X (256 Bit)",
                                            "Asus GeForce GTX 1050 TI 4GB GDDR5 (128 Bit)",
                                            "Gigabyte GeForce GTX 1060 Windforce OC 6GB GDDR5 (192 Bit)",
                                            "Gigabyte GeForce GTX 1070 8GB GDDR5 (256 bit)",
                                            "Gigabyte Radeon RX 460 Windforce OC 2GB GDDR5 (128 Bit)",
                                            "Asus GeForce GTX 950 STRIX 2GB GDDR5 (128 bit)",
                                            "Asus GeForce GTX 1060 DUAL OC 3GB GDDR5 (192 Bit)",
                                            "Palit GeForce GTX 1060 Dual 6GB GDDR5",
                                            "Gigabyte GeForce GTX 1060 6GB GDDR5",
                                            "Asus GeForce GTX 1060 6GB GDDR5 (192 bit)",
                                            "Palit GeForce GTX 1070 GameRock 8GB GDDR5 (256 bit)",
                                            "MSI GeForce GTX 1070 GAMING X 8GB GDDR5 (256 bit)",
                                            "Asus GeForce GTX 1070 ROG 8GB GDDR5 (256 bit)",
                                            "Gigabyte Radeon R7 360 OC 2GB DDR5 (128 bit)",
                                            "Gigabyte Radeon R9 380X 4GB GDDR5 (256 bit)",
                                            "Asus R9 FURY X 4GB HBM (4096 bit)",
                                            "MSI GeForce GTX 750Ti 2GB GDDR5 (128 bit)",
                                            "EVGA GeForce GTX 1080 SC Gaming 8GB GDDR5X (256 Bit)",
                                            "Power Color Radeon R9 Nano 4 GB HBM (4096 bit)",
                                            "Club 3D R9 390X Royal Queen 8GB GDDR5 (512 bit)",
                                            };
            }

            listTextBox = new TextBox[] {
                                        textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
                                        textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20,
                                        };

            for (int i=0; i<20; i++)
            {
                listTextBox[i].Text = listGraphics[i];
            }
        }

        // button to save new card
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    listGraphics[i] = listTextBox[i].Text;
                }
                listGraphics = listGraphics;

                string[] lines = { "First line", "Second line", "Third line" };
                System.IO.File.WriteAllLines(@"graphicsCard.txt", listGraphics);
            }
            catch(Exception ee)
            {
                MessageBox.Show("błąd zapisu pliku");
            }

            this.Close();
        }
    }
}

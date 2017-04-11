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
    public partial class KlasyfikacjaKrytriow : Form
    {
        //declarate matrix preferences
        double[,] preferencesMatrix;

        // count of matrix preferences
        int countMatrix = 12;

        // declarate list with comboBox
        List<ComboBox> ListComboBox;

        //to calculate sum in columns
        double[] sumColumn;

        //to calculate mean in row
        double[] meanRow;

        //to normalized matrix
        double[,] normalizedMatriz;

        //declarate to calculate lambda max
        double lambdaMax;

        // declarate CI
        double CI, RI, CR;

        double[,] matrixWydajnosc;

        // porównań = comparisons
        // declarate matrix comparison
        List<double[,]> comparisonsMatrices = new List<double[,]>();

        // delcarate varibles to calculate best variant
        double[] r;

        // string list to show ranking
        string listRanking;

        // list with graphics card
        string[] listGraphics;

        // declarate varibles temporary;
        double doubleTemp;
        string stringTemp;

        // object to read stream from file
        StreamReader sr = new StreamReader("graphicsCard.txt");

        public KlasyfikacjaKrytriow()
        {
            InitializeComponent();

            doubleTemp = new double();
            //stringTemp = new string();

            //make matrix preferences
            preferencesMatrix = new double[countMatrix, countMatrix];

            //make list with combobox
            ListComboBox = new List<ComboBox> {
                comboBox1,comboBox2,comboBox3,comboBox4,comboBox5,comboBox6,comboBox7,comboBox8,comboBox9,comboBox10,
                comboBox11,comboBox12,comboBox13,comboBox14,comboBox15,comboBox16,comboBox17,comboBox18,comboBox19,comboBox20,
                comboBox21,comboBox22,comboBox23,comboBox24,comboBox25,comboBox26,comboBox27,comboBox28,comboBox29,comboBox30,
                comboBox31,comboBox32,comboBox33,comboBox34,comboBox35,comboBox36,comboBox37,comboBox38,comboBox39,comboBox40,
                comboBox41,comboBox42,comboBox43,comboBox44,comboBox45,comboBox46,comboBox47,comboBox48,comboBox49,comboBox50,
                comboBox51,comboBox52,comboBox53,comboBox54,comboBox55,comboBox56,comboBox57,comboBox58,comboBox59,comboBox60,
                comboBox61,comboBox62,comboBox63,comboBox64,comboBox65,comboBox66
            };

            listGraphics = new string[20];
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
            // values to preferences
            int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //add values do comboBox
            int j = 0;
            for (int i = 0; i < ListComboBox.Count; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    ListComboBox[i].Items.Add(list[j]);
                }
            }

            // set deflaut value in comboBox
            for(int i=0; i< ListComboBox.Count; i++)
            {
                ListComboBox[i].SelectedIndex = 0;
            }
            //comboBox1.SelectedIndex = 0;
        }

        //button to calculate
        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            int nr = 0;
            //read value from combobox and make matrix preferences
            for (int i = 0; i < 12; i++)
            {
                for (j = 1 + i; j < 12; j++)
                {
                    preferencesMatrix[i, j] = double.Parse(ListComboBox[nr].SelectedItem.ToString());
                    preferencesMatrix[j, i] = (1 / double.Parse(ListComboBox[nr].SelectedItem.ToString()));
                    nr++;
                }
            }
            //preferencesMatrix = preferencesMatrix;

            // set 1 in 1:1, 2:2
            for (int i = 0; i < 12; i++)
            {
                preferencesMatrix[i, i] = 1;
                preferencesMatrix[i, i] = 1;
            }
            preferencesMatrix = preferencesMatrix;

            sumColumn = new double[12];
            //calculate sum in column
            for (int i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    sumColumn[i] += preferencesMatrix[j, i];
                }
            }
            sumColumn = sumColumn;
            
            //make normalized matrix
            normalizedMatriz = new double[12, 12];

            //calculate normalized matrix
            for (int i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    normalizedMatriz[j, i] = preferencesMatrix[j, i] / sumColumn[i];
                }
            }
            normalizedMatriz = normalizedMatriz;

            meanRow = new double[12];
            //calculate mean in row
            for (int i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    meanRow[i] += normalizedMatriz[i, j];
                }
                meanRow[i] = meanRow[i] / 12;
            }
            meanRow = meanRow;

            //calculate lambda max
            lambdaMax = new double();
            lambdaMax = 0;

            //to calculate lambda max
            for (int i = 0; i < 12; i++)
            {
                lambdaMax += meanRow[i] * sumColumn[i];
            }
            lambdaMax = lambdaMax;

            //liczenie spojnosci
            // declarate and calculate CI
            CI = new double();

            // calculate CI
            CI = (lambdaMax - 12) / 11;

            // make varibles RI
            RI = new double();
            RI = 1.48;

            // make varibles CR
            CR = new double();

            CR = CI / RI;
            
            // cohesion = spojnosc
            // check cohesion
            if (CR <= 0.1)
            {
                //matrixWydajnosc = new double[20,20];
                //matrixWydajnosc = loadMatrix("wydajnosc.csv");

                //preferenceMatrices = new List<double[,]>();

                // tablice preferencji wedlug kryteriow
                comparisonsMatrices.Add(loadMatrix("wydajnosc.csv"));
                comparisonsMatrices.Add(loadMatrix("cena.csv"));
                comparisonsMatrices.Add(loadMatrix("iloscPamieciRam.csv"));
                comparisonsMatrices.Add(loadMatrix("rodzajPamieciRam.csv"));
                comparisonsMatrices.Add(loadMatrix("szynaDanych.csv"));
                comparisonsMatrices.Add(loadMatrix("typZlacza.csv"));
                comparisonsMatrices.Add(loadMatrix("taktowanieRdzenia.csv"));
                comparisonsMatrices.Add(loadMatrix("taktowaniePamieci.csv"));
                comparisonsMatrices.Add(loadMatrix("laczenieKart.csv"));
                comparisonsMatrices.Add(loadMatrix("rozdzielczosc.csv"));
                comparisonsMatrices.Add(loadMatrix("obslugiwaneStandardy.csv"));
                comparisonsMatrices.Add(loadMatrix("technlogie.csv"));

                //comparisonsMatrices[0] = comparisonsMatrices[0];

                // srednia w pierwszej tabeli
                //meanRow

                // calculate best variant
                r = new double[20];

                double[] meanComparison;

                // tablica ze srednimi
                double[,] sredniaTablic = new double[20, 12];

                // tablia pomocnicza
                double[,] tablicaPomocnicza = new double[20, 20];

                double suma = 0;

                //obliczanie srednich w tablicach
                for (int i = 0; i < 12; i++) // zmienia tablice
                {
                    //dwuwymiarowa kopia tablicy z ocena kryteri
                    tablicaPomocnicza = comparisonsMatrices[i];
                    for (int k = 0; k < 20; k++) // zmienia wiersz
                    {
                        for (j = 0; j < 20; j++)
                        {
                            suma += tablicaPomocnicza[i, j];
                        }
                        sredniaTablic[k, i] = suma / 20;
                    }
                }
                //sredniaTablic = sredniaTablic;

                // obliczanie r
                for (j = 0; j < 20; j++)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        r[j] += meanRow[i] * sredniaTablic[j, i];//tutaj ma liczyc srednia w wierszu
                    }
                }
                //r = r;

                // sort list with grapics card
                for (int write = 0; write < 20; write++)
                {
                    for (int sort = 0; sort < 19; sort++)
                    {
                        if (r[sort] < r[sort + 1])
                        {
                            doubleTemp = r[sort + 1];
                            r[sort + 1] = r[sort];
                            r[sort] = doubleTemp;
                            stringTemp = listGraphics[sort + 1];
                            listGraphics[sort + 1] = listGraphics[sort];
                            listGraphics[sort] = stringTemp;
                        }
                    }
                }

                listRanking = "";
                // make list to show
                for (int i = 0; i < 20; i++)
                {
                    listRanking += (i + 1).ToString() + ". " + listGraphics[i] + " \n";
                }

                MessageBox.Show("Ranking najlepszych kart graficznych dla ciebie to: \n" + listRanking);

            }
            else // check cohesion
            {
                MessageBox.Show("macierz preferencji nie jest spojna, zmien kryteria");
            }
            //comparisonsMatrices = comparisonsMatrices;
            //preferencesMatrix = preferencesMatrix;
            //MessageBox.Show(a.ToString());
        }
        
        //
        private double[] computeMeansVector(double[,] matrix)
        {
            double[] vector = new double[matrix.GetLength(0)];
            double sum = 0.0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[i, j];
                }
                vector[i] = sum / (matrix.GetLength(0));
                sum = 0.0;
            }
            return vector;
        }

        // read data form file csv
        private double[,] loadMatrix(string filename)
        {
            double[,] result = new double[20, 20];

            string[] lines = System.IO.File.ReadAllLines(@filename);

            for (int i = 0; i < 20; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < 20; j++)
                {
                    try
                    {
                        values[j].Replace(",", ".");
                        result[i, j] = Double.Parse(values[j]);
                    }
                    catch (Exception ex) { continue; }
                }
            }
            return result;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

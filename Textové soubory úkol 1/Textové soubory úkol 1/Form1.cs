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

namespace Textové_soubory_úkol_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string cisla = "123456789";
            OpenFileDialog soubor = new OpenFileDialog();
            if (soubor.ShowDialog() == DialogResult.OK)
            {
                int soucet = 0, pocetL = 0, pocetS = 0;
                StreamReader ctenar = new StreamReader(soubor.FileName);
                while (!ctenar.EndOfStream)
                {
                    listBox1.Items.Add(ctenar.ReadLine());
                }
                ctenar.Close();
                StreamWriter zapis = new StreamWriter(soubor.FileName, true);
                zapis.WriteLine("");
                foreach (string i in listBox1.Items)
                {
                    soucet = 0;
                    if (i != "")
                    {
                        foreach (char c in i)
                        {
                            if (cisla.Contains(c))
                            {
                                soucet += Convert.ToInt32(c) - 48;
                                if (Convert.ToInt32(c) % 2 == 0)
                                {
                                    pocetS++;
                                }
                                else
                                {
                                    pocetL++;
                                }
                            }
                        }
                        zapis.WriteLine(soucet);
                    }
                }
                zapis.WriteLine("");
                zapis.WriteLine(pocetL);
                zapis.WriteLine(pocetS);
                zapis.Close();
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            OpenFileDialog soubor = new OpenFileDialog();
            if (soubor.ShowDialog() == DialogResult.OK)
            {
                StreamReader ctenar2 = new StreamReader(soubor.FileName);
                while (!ctenar2.EndOfStream)
                {
                    listBox2.Items.Add(ctenar2.ReadLine());
                }
                ctenar2.Close();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LawnGreen;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.LawnGreen;
        }
    }
}

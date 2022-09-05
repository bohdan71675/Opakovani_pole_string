using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opakovani_pole_string
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int pocetRadku = textBox1.Lines.Count();
            string[] p = new string[pocetRadku];
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                string radek = textBox1.Lines[i];
                char[] separator = { ' ', ',', '.' };
                string[] str = radek.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string nejkratsi = str[0];

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j].Length < nejkratsi.Length)
                    {
                        nejkratsi = str[j];
                    }
                }
                p[i] = nejkratsi;
                listBox1.Items.Add(p[i]);
            }
        }

        void ZpracujPole(string[] pole, string podretezec, out string prvniCifra, out string konciPodRetezcem)
        {
            prvniCifra = "";
            konciPodRetezcem = "";
            bool nalezenaCifra = false;
            for (int i = 0; i < pole.Length; i++)
            {
                string slovo = pole[i];
                for (int j = 0; j < slovo.Length && !nalezenaCifra; j++)
                {
                    if (char.IsDigit(slovo[j]))
                    {
                        prvniCifra = slovo;
                        nalezenaCifra = true;
                    }
                }
                if (slovo.Contains(podretezec))
                {
                    konciPodRetezcem = slovo;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] pole = { "Ananas", "Banan", "Jablko", "Hruska" };
            string podretezec = "nan";
            string prvniCifra = "";
            string konciPodRetezcem = "";
            ZpracujPole(pole, podretezec, out prvniCifra, out konciPodRetezcem);
            MessageBox.Show("\n\nPrvní slovo s cifrou je: " + prvniCifra
                + "\n\nPosledni retezec ktery konci podretezcem " + konciPodRetezcem);
        }
    }
}

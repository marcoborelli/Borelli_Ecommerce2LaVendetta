using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borelli_Ecommerce
{
    public partial class Form1 : Form
    {
        int contRapid = 0;
        bool firsTime = true;
        Prodotto[] prod = new Prodotto[999];
        Carrello carrello = new Carrello("CARRELLO1");
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (firsTime)//solo la prima volta che apro il programma
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                firsTime = false;

                listView1.Columns.Add("ID", 60);
                listView1.Columns.Add("NOME", 80);
                listView1.Columns.Add("PRODUTTORE", 80);
                listView1.Columns.Add("DESCRIZIONE", 220);
                listView1.Columns.Add("PREZZO", 50);
                listView1.Columns.Add("QTA", 40);
            }
            StampaElementi(listView1, carrello);
        }
        private void button2_Click(object sender, EventArgs e)//inserimento rapido
        {
            prod[contRapid] = new Prodotto($"ID{contRapid}", $"NOME{contRapid}", $"PRODUTTORE{contRapid}", $"PRODOTTO MOLTO BELO{contRapid}", rand.Next(0,999));
            carrello.Aggiungi(prod[contRapid]);
            contRapid++;
            Form1_Load(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)//inserisci normale
        {
            if (textBox1.Text!=String.Empty&&textBox2.Text!=String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty)
            {
                try
                {
                    float.Parse(textBox5.Text);
                }
                catch
                {
                    throw new Exception("Inserire un float nel prezzo");
                }
                
                
                prod[contRapid] = new Prodotto($"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text));
                carrello.Aggiungi(prod[contRapid]);
                contRapid++;
            }
            else
            {
                MessageBox.Show("Inserire prima i valori");
            }
            Form1_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)//eliminazione
        {
            //MessageBox.Show(prod[0].ToString());
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    Prodotto p = CreaProdTemp(listView1.SelectedItems[i].SubItems[0].Text, listView1.SelectedItems[i].SubItems[1].Text, listView1.SelectedItems[i].SubItems[2].Text, listView1.SelectedItems[i].SubItems[3].Text, float.Parse(listView1.SelectedItems[i].SubItems[4].Text));
                    carrello.Rimuovi(p);
                }
                Form1_Load(sender, e);
            }
        }
        private void button4_Click(object sender, EventArgs e)//svuota
        {
            carrello.Svuota();
            Form1_Load(sender, e);
        }

        public Prodotto CreaProdTemp(string id, string nome,string prod,string descr,float prezz)
        {
            Prodotto p = new Prodotto(id, nome, prod, descr, prezz);
            return p;
        }

        public static void StampaElementi(ListView listino, Carrello carr)
        {
            listino.Items.Clear();
            Prodotto[] prod = carr.Prod;
            int i = 0;
            while (prod[i]!=null)
            {
                int qta = carr.VisualizzaQtaProdotti(i);
                string[] temp = new string[] { prod[i].Id, prod[i].Nome, prod[i].Produttore, prod[i].Descrizione, $"{prod[i].Prezzo}", $"{qta}" };
                ListViewItem item = new ListViewItem(temp);
                listino.Items.Add(item);
                i++;
            }
        }


    }
}

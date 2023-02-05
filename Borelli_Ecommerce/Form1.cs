using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borelli_Ecommerce {
    public partial class Form1 : Form {
        int contRapid = 0;
        bool firsTime = true;
        ProdottoGenerico[] prod = new ProdottoGenerico[999];
        Carrello carrello = new Carrello("CARRELLO1");
        Random rand = new Random();

        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            if (firsTime) {//solo la prima volta che apro il programma
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                firsTime = false;

                listView1.Columns.Add("ID", (int)(listView1.Width * 0.05));
                listView1.Columns.Add("NOME", (int)(listView1.Width * 0.15));
                listView1.Columns.Add("PRODUTTORE", (int)(listView1.Width * 0.15));
                listView1.Columns.Add("DESCRIZIONE", (int)(listView1.Width * 0.20));
                listView1.Columns.Add("PREZZO", (int)(listView1.Width * 0.10));
                listView1.Columns.Add("PREZZO SCONT", (int)(listView1.Width * 0.10));
                listView1.Columns.Add("EXTRA", (int)(listView1.Width * 0.15));
                listView1.Columns.Add("QTA", (int)(listView1.Width * 0.10));

                labelData.Visible = labelInfoAggiuntive.Visible = textInfoAggiuntive.Visible = monthCalendar1.Visible = false;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Items.Add("ProdottoElettorinico");
                comboBox1.Items.Add("ProdottoAlimentare");
                comboBox1.Items.Add("Penna");
                comboBox1.Items.Add("FoglioDiCarta");

            }
            StampaElementi(listView1, carrello);
        }
        private void button2_Click(object sender, EventArgs e) {//inserimento rapido
            prod[contRapid] = new ProdottoElettronico($"ID{contRapid}", $"NOME{contRapid}", $"PRODUTTORE{contRapid}", $"PRODOTTO MOLTO BELO{contRapid}", rand.Next(0, 999), $"SPECIFICO{contRapid}");
            carrello.Aggiungi(prod[contRapid]);
            contRapid++;
            Form1_Load(sender, e);
        }
        private void button1_Click(object sender, EventArgs e) {//inserisci normale
            if (!String.IsNullOrWhiteSpace(comboBox1.Text)) { /*se ho selezionato la combobox*/

                if (comboBox1.Text == "ProdottoElettorinico") {
                    prod[contRapid] = new ProdottoElettronico($"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text), $"{textInfoAggiuntive.Text}");
                } 
                else if (comboBox1.Text == "ProdottoAlimentare") {
                    string[] temp = textInfoAggiuntive.Text.Split('\n');//creo array splittando grazie al ritorno a capo
                    DateTime d = monthCalendar1.SelectionRange.Start;
                    prod[contRapid] = new ProdottoAlimentare($"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text), d, temp);
                } 
                else if (comboBox1.Text == "Penna") {
                    prod[contRapid] = new Penne($"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text), $"{textInfoAggiuntive.Text}");
                } 
                else if (comboBox1.Text == "FoglioDiCarta") {
                    prod[contRapid] = new FogliDiCarta($"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text), float.Parse(textInfoAggiuntive.Text));
                }

                carrello.Aggiungi(prod[contRapid]);
                contRapid++;

            } else {
                MessageBox.Show("Selezionare prima il tipo di prodotto");
            }
            Form1_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e) {//eliminazione
            //MessageBox.Show(prod[0].ToString());
            if (listView1.SelectedItems.Count > 0) {
                for (int i = 0; i < listView1.SelectedItems.Count; i++) {
                    ProdottoGenerico p = new ProdottoGenerico(listView1.SelectedItems[i].SubItems[0].Text, listView1.SelectedItems[i].SubItems[1].Text);
                    carrello.Rimuovi(p);
                }
                Form1_Load(sender, e);
            }
        }
        private void button4_Click(object sender, EventArgs e) {//svuota
            carrello.Svuota();
            Form1_Load(sender, e);
        }

        public static void StampaElementi(ListView listino, Carrello carr) {
            listino.Items.Clear();
            ProdottoGenerico[] prod = carr.Prod;
            int[] qta = carr.Qta;

            for (int i = 0; i < prod.Length; i++) {
                string[] temp = prod[i].ToString().Split(';');
                string[] def = new string[temp.Length + 1];

                for (int j = 0; j < temp.Length; j++) {
                    def[j] = temp[j];
                }

                def[temp.Length] = $"{qta[i]}";
                ListViewItem item = new ListViewItem(def);
                listino.Items.Add(item);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e) {
            if (textInfoAggiuntive.Text[textInfoAggiuntive.Text.Length - 1] == '\n') {
                textInfoAggiuntive.Height += (int)Font.GetHeight();
                monthCalendar1.Location = new Point(monthCalendar1.Location.X, monthCalendar1.Location.Y + (int)Font.GetHeight());
                labelData.Location = new Point(labelData.Location.X, labelData.Location.Y + (int)Font.GetHeight());
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
            string temp = monthCalendar1.SelectionRange.Start.ToString();
            labelData.Text = temp.Substring(0, temp.Length - 9);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            labelData.Visible = monthCalendar1.Visible = false;

            if (comboBox1.Text == "ProdottoElettorinico") {
                labelInfoAggiuntive.Text = "CODICE SPECIFICO";
            } else if (comboBox1.Text == "ProdottoAlimentare") {
                labelInfoAggiuntive.Text = "INGRED [MAX 10] [ENTER]";
                labelData.Visible = monthCalendar1.Visible = true;
            } else if (comboBox1.Text == "Penna") {
                labelInfoAggiuntive.Text = "FUNZIONAMENTO";
            } else if (comboBox1.Text == "FoglioDiCarta") {
                labelInfoAggiuntive.Text = "GRAMMATURA";
            }

            labelInfoAggiuntive.Visible = textInfoAggiuntive.Visible = true;
        }
    }
}

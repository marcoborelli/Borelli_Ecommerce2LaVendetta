using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borelli_Ecommerce {
    public class ProdottoAlimentare : ProdottoGenerico {
        private DateTime _dataScadenza;
        private const int MAXX = 10;
        private float _numeroIngredienti;
        private string[] _ingredienti;

        public ProdottoAlimentare(string id, string nome, string produt, string descr, float prezzo, DateTime dataScad, string[] ingred) : base(id, nome, produt, descr, prezzo) {
            _ingredienti = new string[MAXX];
            this.DataScadenza = dataScad;
            this.Sconto = 50;
            AggiungiIngredienti(ingred);
        }

        //properties
        public DateTime DataScadenza {
            get {
                return _dataScadenza;
            }
            set {
                if (value != null) {
                    _dataScadenza = value;
                } else {
                    throw new Exception("Inserire una data di scadenza valida");
                }
            }
        }
        public float NumeroIngredienti {
            get {
                return _numeroIngredienti;
            }
            private set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref _numeroIngredienti, value, "Numero Ingredienti", 10);
            }
        }
        public string[] Ingredienti {
            get {
                string[] temp = new string[(int)this.NumeroIngredienti];
                for (int i = 0; i < temp.Length; i++) {
                    temp[i] = _ingredienti[i];
                }

                return temp;
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        public bool Equals(ProdottoAlimentare p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                if (p.Nome != this.Nome || p.Id != this.Id || p.Ingredienti.Length != this.Ingredienti.Length) {
                    return false;
                } else {
                    string[] ingrP = p.Ingredienti; /*faccio così di modo che li calcoli solo una volta, se lo facessi inline ogni volta starebbe a ricalcolarmi l'array*/
                    for (int i = 0; i < NumeroIngredienti; i++) {
                        if (_ingredienti[i] != ingrP[i])
                            return false;
                    }
                    return true; /*se sono arrivato fino a qui vuol dire che sono tutti uguali*/
                }
            }
        }
        public override string ToString() {
            string temp = "";
            for (int i = 0; i < NumeroIngredienti; i++) {
                temp += $"{_ingredienti[i]},";
            }
            temp = temp.Substring(0, temp.Length - 1);/*per togliere virgola finale*/

            return $"{base.ToString()};{temp} SCADE IL:{DataScadenza}";
        }
        /*fine funzioni generali*/

        //funzioni specifiche
        public int CalcolaGiorniDifferenza() {
            var oggi = DateTime.Now;
            var differenza = oggi - this.DataScadenza;

            return (int)differenza.Days;
        }
        public override float CalcolaPrezzoFinale() {
            float temp = base.CalcolaPrezzoFinale();
            if (CalcolaGiorniDifferenza() > 7) {
                return temp * ((100 - this.Sconto) / 100);
            }
            return temp;
        }
        public void AggiungiIngredienti(string ingr) {
            if (this.NumeroIngredienti < MAXX) {
                InserisciSeStringaValida(ref _ingredienti[(int)NumeroIngredienti], ingr, $"Ingrediente singolo");
                this.NumeroIngredienti++;
            } else {
                throw new Exception("Limite array superato in positivo");
            }
        }

        public void AggiungiIngredienti(string[] ingredienti) {
            for (int i = 0; i < MAXX && i < ingredienti.Length; i++) {
                InserisciSeStringaValida(ref _ingredienti[i], ingredienti[i], $"Ingrediente {i}");
                this.NumeroIngredienti++;
            }
        }


    }
}

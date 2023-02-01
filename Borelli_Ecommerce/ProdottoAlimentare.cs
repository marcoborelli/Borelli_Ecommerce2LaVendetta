using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                SettaSeMaggioreDiZeroMinoreDiMax(ref _numeroIngredienti, value, "Numero Ingredienti", 9999);
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

        //funzioni specifiche
        public int CalcolaGiorniDifferenza() {
            var oggi = DateTime.Now;
            var differenza = oggi - this.DataScadenza;

            return (int)differenza.Days;
        }
        public override float CalcolaPrezzoFinale() {
            if (CalcolaGiorniDifferenza() < 7) {
                return this.Prezzo - ((this.Sconto * this.Prezzo) / 100);
            } else {
                return this.Prezzo;
            }
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
            for (int i = 0; i < this.NumeroIngredienti; i++) {
                if (this.NumeroIngredienti < MAXX) {
                    InserisciSeStringaValida(ref _ingredienti[i], ingredienti[i], $"Ingrediente {i}");
                    this.NumeroIngredienti++;
                } else {
                    throw new Exception("Limite array superato in positivo");
                }
            }
        }
        

    }
}

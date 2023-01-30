using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class ProdottoAlimentare : ProdottoGenerico {
        private DateTime _dataScadenza;
        private const int MAXX = 10;
        private int _numeroIngredienti;
        private string[] _ingredienti;

        public ProdottoAlimentare(string id, string nome, string produt, string descr, float prezzo, DateTime dataScad, string[] ingred) : base(id, nome, produt, descr, prezzo) {
            _ingredienti = new string[MAXX];
            this.DataScadenza = dataScad;
            AggiungiIngredienti(ingred);
            GestisciPrezzo();
        }

        protected int CalcolaGiorniDifferenza() {
            var oggi = DateTime.Now;
            var differenza = oggi - this.DataScadenza;

            return (int)differenza.Days;
        }
        private void GestisciPrezzo() {
            if (CalcolaGiorniDifferenza() > 7) {
                this.Prezzo /= 2;
            }
        }
        public void AggiungiIngredienti(string ingr) {
            if (this.NumeroIngredienti < MAXX) {
                InserisciSeStringaValida(ref _ingredienti[NumeroIngredienti], ingr, $"Ingrediente singolo");
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

        public int NumeroIngredienti {
            get {
                return _numeroIngredienti;
            }
            private set {
                if (value >= 0) {
                    _numeroIngredienti = value;
                } else {
                    throw new Exception("Limite array superato in negativo");
                }
            }
        }
        public string[] Ingredienti {
            get {
                string[] temp = new string[this.NumeroIngredienti];
                for (int i = 0; i < temp.Length; i++) {
                    temp[i] = _ingredienti[i];
                }

                return temp;
            }
        }

    }
}

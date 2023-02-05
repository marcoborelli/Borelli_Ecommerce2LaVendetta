using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class Carrello {
        private string _id;
        private const int MAX = 999;
        private ProdottoGenerico[] _prod;
        private int[] _qta;
        private int _numProdotti;

        public Carrello(string id) {
            this.Id = id;
            _prod = new ProdottoGenerico[MAX];
            _qta = new int[MAX];
            Svuota();//inizializzo il vettore vuoto
        }

        /*properties*/
        private int NumProdotti {
            get {
                return _numProdotti;
            }
            set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref  _numProdotti, value, "Numero Prodotti", MAX);
            }
        }
        public string Id {
            get {
                return _id;
            }
            private set {
                InserisciSeStringaValida(ref _id, value, "Id");
            }
        }
        public int[] Qta {
            get {
                int[] temp = new int[NumProdotti];
                for (int i = 0; i < NumProdotti; i++) {
                    temp[i] = _qta[i];
                }
                return temp;
            }
        }
        public ProdottoGenerico[] Prod {
            get {
                ProdottoGenerico[] temp = new ProdottoGenerico[NumProdotti];
                for (int i = 0; i < NumProdotti; i++) {
                    temp[i] = _prod[i];
                }
                return temp;
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        /*fine funzioni generali*/

        /*funzioni specifiche*/
        public void Aggiungi(ProdottoGenerico p) {
            if (p != null) {
                int ind1 = Esiste(p);//prima verifico se già esiste

                if (ind1 != -1) {
                    _qta[ind1]++;
                } else {

                    if (p.GetType() == typeof(ProdottoAlimentare)) {
                        ProdottoAlimentare pa = (ProdottoAlimentare)p;
                        if (pa.CalcolaGiorniDifferenza() > 0) {
                            throw new Exception("Non si può inserire un prodotto scaduto");
                        }
                    }

                    _prod[this.NumProdotti] = p;
                    _qta[this.NumProdotti] = 1;
                    this.NumProdotti++;
                }
            } else {
                throw new Exception("Inserire un prodotto valido");
            }
        }
        public void Rimuovi(ProdottoGenerico p) {
            int ind1 = Esiste(p);
            if (ind1 != -1) {
                for (int i = ind1; i < _prod.Length - 1; i++) {
                    _prod[i] = _prod[i + 1];
                    _qta[i] = _qta[i + 1];
                }

                _prod[_prod.Length - 1] = null;
                _qta[_qta.Length - 1] = 0;

                this.NumProdotti--;
            } else {
                throw new Exception("Inserire un prodotto valido");
            }
        }
        public void Svuota() {
            for (int i = 0; i < NumProdotti; i++) {
                _prod[i] = null;
                _qta[i] = 0;
            }
            this.NumProdotti = 0;
        }
        public int VisualizzaQtaProdotti(int ind) {
            if (_qta[ind] != 0) {
                return _qta[ind];
            } else {
                throw new Exception("Non è presente nessun valore a questo indice");
            }
        }
        /*fine funzioni specifiche*/

        private int Esiste(ProdottoGenerico q) {
            for (int i = 0; i < NumProdotti; i++) {
                if (_prod[i].Equals(q))
                    return i;
            }
            return -1;
        }
        protected void InserisciSeStringaValida(ref string campo, string val, string perErrore) {
            if (!String.IsNullOrWhiteSpace(val)) {
                campo = val;
            } else {
                throw new Exception($"Inserire il campo \"{perErrore}\" valido");
            }
        }

        protected void SettaSeMaggioreDiZeroMinoreDiMax(ref int campo, int val, string nomeCampo, int max) {
            if (val >= 0 && val < max) {
                campo = val;
            } else {
                throw new Exception($"Il campo \"{nomeCampo}\" deve essere maggiore di 0 e minore di {max}");
            }
        }
    }
}

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

        public void Svuota() {
            for (int i = 0; i < _prod.Length; i++) {
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

        public void Aggiungi(ProdottoGenerico p) {
            if (p != null) {
                int ind1 = Esiste(p);
                if (ind1 != -1 && p.Equals(_prod[ind1])) {
                    _qta[ind1]++;
                } else if (ind1 != -1 && !p.Equals(_prod[ind1])) {
                    throw new Exception("Non si possono metere due id uguali ma prodotti con caratteristiche diverse");
                } else {
                    if (p.GetType() == typeof(ProdottoAlimentare)) {
                        ProdottoAlimentare pa = (ProdottoAlimentare)p;
                        if (pa.CalcolaGiorniDifferenza() > 0) {
                            _prod[this.NumProdotti] = pa;
                            _qta[this.NumProdotti] = 1;
                            this.NumProdotti++;
                        } else {
                            throw new Exception("Non si può inserire un prodotto scaduto");
                        }
                    } else {
                        _prod[this.NumProdotti] = p;
                        _qta[this.NumProdotti] = 1;
                        this.NumProdotti++;
                    }
                }

            } else {
                throw new Exception("Inserire un prodotto valido");
            }
        }

        private int NumProdotti {
            get {
                return _numProdotti;
            }
            set {
                if (value < MAX && value >=0) {
                    _numProdotti = value;
                } else {
                    throw new Exception("Limite array superato in positivo o negativo");
                }
            }
        }
        public int[] Qta {
            get {
                return _qta;
            }
        }
        public string Id {
            get {
                return _id;
            }
            private set {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Inserire un id correggiuto");
            }
        }

        public ProdottoGenerico[] Prod {
            get {
                return _prod;
            }
        }

        private int Esiste(ProdottoGenerico q) {
            for (int i = 0; i < _prod.Length; i++) {
                if (_prod[i] != null && _prod[i].Id == q.Id)
                    return i;
            }
            return -1;
        }

    }
}

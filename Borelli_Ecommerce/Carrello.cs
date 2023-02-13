using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class Carrello {
        private string _id;
        private List<ProdottoCarrello> _lista = new List<ProdottoCarrello>();

        public Carrello(string id) {
            this.Id = id;
            Svuota();
        }

        /*properties*/
        public string Id {
            get {
                return _id;
            }
            private set {
                InserisciSeStringaValida(ref _id, value, "Id");
            }
        }
        public ProdottoCarrello[] Prod {
            get {
                return _lista.ToArray();
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        /*fine funzioni generali*/

        /*funzioni specifiche*/
        public void Aggiungi(ProdottoGenerico p) {
            if (p != null) {
                ProdottoCarrello pc = new ProdottoCarrello(p);/*devo trovare un modo migliore per farlo*/
                
                int indice = _lista.IndexOf(pc);

                if (indice != -1) {
                    _lista[indice].Qta++;
                } else {

                    if (p.GetType() == typeof(ProdottoAlimentare)) {
                        ProdottoAlimentare pa = (ProdottoAlimentare)p;
                        if (pa.CalcolaGiorniDifferenza() > 0) {
                            throw new Exception("Non si può inserire un prodotto scaduto");
                        }
                    }

                    _lista.Add(pc);
                }

            } else {
                throw new Exception("Inserire un prodotto valido");
            }
        }
        public void Rimuovi(ProdottoGenerico p) {
            ProdottoCarrello pc = new ProdottoCarrello(p);
            int indice= _lista.IndexOf(pc);
            if (indice != -1) {
                _lista.RemoveAt(indice);
            } else {
                throw new Exception("Inserire un prodotto valido");
            }
        }
        public void Svuota() {
            _lista.Clear();
        }
        public float VisualizzaQtaProdotti(int ind) {
            if (ind < _lista.Count) {
                return _lista[ind].Qta;
            } else {
                throw new Exception("Indice oltre il numero attuale di prodotti");
            }
        }
        /*fine funzioni specifiche*/

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

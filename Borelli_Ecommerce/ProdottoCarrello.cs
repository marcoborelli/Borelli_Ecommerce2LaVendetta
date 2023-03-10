using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class ProdottoCarrello : IEquatable<ProdottoCarrello> {
        private float _qta;
        ProdottoGenerico _prodotto;

        /*costruttore*/
        public ProdottoCarrello(ProdottoGenerico prod) {
            this.Qta = 1;
            this._prodotto = prod;
        }

        /*properties*/
        public float Qta {
            get {
                return _qta;
            }
            set {
                if (value > 0) {
                    _qta = value;
                } else {
                    throw new Exception("Inserire una quantità valida");
                }
            }
        }
        public ProdottoGenerico Prodotto {
            get {
                return _prodotto;
            }
            set {
                if (value != null) {
                    _prodotto = value;
                } else {
                    throw new Exception("Inserire un prodotto valido");
                }
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        public override string ToString() {
            return $"{Prodotto.ToString()};{Qta}";
        }
        public bool Equals(ProdottoCarrello p) {
            return Prodotto.Equals(p.Prodotto);
        }
        /*fine funzioni generali*/
    }
}

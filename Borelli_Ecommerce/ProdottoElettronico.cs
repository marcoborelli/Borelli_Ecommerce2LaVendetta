using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class ProdottoElettronico : ProdottoGenerico {
        private string _codiceModello;

        public ProdottoElettronico(string id, string nome, string produttore, string descr, float prezzo, string _codiceMod) : base(id, nome, produttore, descr, prezzo) {
            this.CodiceModello = _codiceMod;
            this.Sconto = 5;
        }

        /*property*/
        public string CodiceModello {
            get {
                return _codiceModello;
            }
            set {
                InserisciSeStringaValida(ref _codiceModello, value, "Codice Modello");
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        public bool Equals(ProdottoElettronico p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                return (p.Nome == this.Nome && p.Id == this.Id && p.CodiceModello == this.CodiceModello);
            }
        }
        public override string ToString() {
            return $"{base.ToString()};{CodiceModello}";
        }
        /*fine funzioni generali*/

        public override float CalcolaPrezzoFinale() {
            DateTime d = DateTime.Now;
            float temp = base.CalcolaPrezzoFinale();

            if ($"{d.DayOfWeek}" == "Monday") {
                return temp * ((100 - this.Sconto) / 100);
            }
            return temp;

        }

    }
}

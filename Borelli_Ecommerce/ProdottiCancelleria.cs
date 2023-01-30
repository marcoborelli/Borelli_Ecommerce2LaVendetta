using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public abstract class ProdottiCancelleria : ProdottoGenerico {
        public ProdottiCancelleria(string id, string nome, string produt, string descr, float prezzo) : base(id, nome, produt, descr, prezzo) {
            this.Sconto = 3;
            GestisciPrezzo(this.Sconto);
        }

        private int CalcolaGiorno() {
            DateTime d = DateTime.Now;

            return (int)d.DayOfYear;
        }

        private void GestisciPrezzo(float sconto) {
            if (CalcolaGiorno() % 2 == 0) {
                this.Prezzo -= (sconto * this.Prezzo) / 100;
            }
        }
    }
}

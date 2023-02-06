using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public abstract class ProdottiCancelleria : ProdottoGenerico {
        public ProdottiCancelleria(string id, string nome, string produt, string descr, float prezzo) : base(id, nome, produt, descr, prezzo) {
            this.Sconto = 3;
        }
        public override float CalcolaPrezzoFinale() {
            float temp = base.CalcolaPrezzoFinale();

            if (CalcolaGiorno() % 2 == 0) {
                return temp * ((100 - this.Sconto) / 100);
            }
            return temp;
        }

        private int CalcolaGiorno() {
            DateTime d = DateTime.Now;
            return (int)d.Day;
        }
    }
}

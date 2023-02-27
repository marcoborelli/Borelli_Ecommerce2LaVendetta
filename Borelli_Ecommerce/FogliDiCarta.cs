using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class FogliDiCarta : ProdottiCancelleria/*, IEquatable<FogliDiCarta>*/ {
        private float _grammatura;
        public FogliDiCarta(string id, string nome, string produt, string descr, float prezzo, float grammat) : base(id, nome, produt, descr, prezzo) {
            this.Grammatura = grammat;
        }

        /*properties*/
        public float Grammatura {
            get {
                return _grammatura;
            }
            set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref _grammatura, value, "Grammatura", 9999);
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        public bool Equals(FogliDiCarta p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                return (p.Nome == this.Nome && p.Id == this.Id && p.Grammatura == this.Grammatura);
            }
        }
        public override string ToString() {
            return $"{base.ToString()};{Grammatura}";
        }
        /*fine funzioni generali*/
    }
}

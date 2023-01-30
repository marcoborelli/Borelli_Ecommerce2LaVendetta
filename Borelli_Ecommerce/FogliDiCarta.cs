using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class FogliDiCarta : ProdottiCancelleria {
        private float _grammatura;
        public FogliDiCarta(string id, string nome, string produt, string descr, float prezzo, float grammat) : base(id, nome, produt, descr, prezzo) {
            this.Grammatura = grammat;
        }

        public float Grammatura {
            get {
                return _grammatura;
            }
            set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref _grammatura, value, "Grammatura", 9999);
            }
        }
    }
}

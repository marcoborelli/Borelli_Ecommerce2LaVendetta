using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class Penne : ProdottiCancelleria{
        private string _funzionamento;
        public Penne(string id, string nome, string produt, string descr, float prezzo, string funz) : base(id, nome, produt, descr, prezzo) {

        }

        public string Funzionamento {
            get {
                return _funzionamento;
            }
            set {
                InserisciSeStringaValida(ref _funzionamento, value, "Funzionamento");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class Penne : ProdottiCancelleria{
        private string _funzionamento;
        public Penne(string id, string nome, string produt, string descr, float prezzo, string funz) : base(id, nome, produt, descr, prezzo) {
            this.Funzionamento = funz;
        }

        //properties
        public string Funzionamento {
            get {
                return _funzionamento;
            }
            set {
                InserisciSeStringaValida(ref _funzionamento, value, "Funzionamento");
            }
        }
        /*fine properties*/

        /*funzioni generali*/
        public bool Equals(Penne p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                return (p.Nome == this.Nome && p.Id == this.Id && p.Funzionamento == this.Funzionamento);
            }
        }
        public override string ToString() {
            return $"{base.ToString()};{Funzionamento}";
        }
        /*fine funzioni generali*/
    }
}

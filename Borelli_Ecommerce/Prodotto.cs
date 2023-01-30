using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class Prodotto {
        private string _id, _nome, _produttore, _descrizione;
        private float _prezzo;

        public Prodotto(string id, string nome, string prod, string descr, float prezzo) {
            Id = id;
            Nome = nome;
            Produttore = prod;
            Descrizione = descr;
            Prezzo = prezzo;
        }

        public float Prezzo {
            get {
                return _prezzo;
            }
            set {
                if (value > 0) {
                    _prezzo = value;
                } else {
                    throw new Exception("Il prezzo deve essere positivo");
                }
            }
        }

        public string Id {
            get {
                return _id;
            }
            private set {
                if (value != null) {
                    _id = value;
                } else {
                    throw new Exception("Inserire un id correggiuto");
                }
            }
        }

        public string Nome {
            get {
                return _nome;
            }
            private set {
                if (value != null) {
                    _nome = value;
                } else {
                    throw new Exception("Inserire un nome correggiuto");
                }
            }
        }

        public string Produttore {
            get {
                return _produttore;
            }
            private set {
                if (value != null) {
                    _produttore = value;
                } else {
                    throw new Exception("Inserire un produttore correggiuto");
                }
            }
        }

        public string Descrizione {
            get {
                return _descrizione;
            }
            private set {
                if (value != null) {
                    _descrizione = value;
                } else {
                    throw new Exception("Inserire una descrizione correggiuta");
                }
            }
        }

        public bool Equals(Prodotto p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                return (p.Nome == this.Nome && p.Id == this.Id && p.Prezzo == this.Prezzo);
            }
        }
    }
}

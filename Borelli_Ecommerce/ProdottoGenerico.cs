using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class ProdottoGenerico {
        private string _id, _nome, _produttore, _descrizione;
        private float _prezzo, _sconto;

        public ProdottoGenerico(string id, string nome, string produt, string descr, float prezzo) {
            Id = id;
            Nome = nome;
            Produttore = produt;
            Descrizione = descr;
            Prezzo = prezzo;
        }

        public ProdottoGenerico(string id, string nome):this(id, nome, "N/A", "N/A", 1) {

        }

        //properties
        public float Prezzo {
            get {
                return _prezzo;
            }
            set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref _prezzo, value, "Prezzo", int.MaxValue);
            }
        }
        public float Sconto {
            get {
                return _sconto;
            }
            set {
                SettaSeMaggioreDiZeroMinoreDiMax(ref _sconto, value, "Sconto",100);
            }
        }
        public string Id {
            get {
                return _id;
            }
            private set {
                InserisciSeStringaValida(ref _id, value, "Id");
            }
        }
        public string Nome {
            get {
                return _nome;
            }
            private set {
                InserisciSeStringaValida(ref _nome, value, "Nome");
            }
        }
        public string Produttore {
            get {
                return _produttore;
            }
            private set {
                InserisciSeStringaValida(ref _produttore, value, "Produttore");
            }
        }
        public string Descrizione {
            get {
                return _descrizione;
            }
            private set {
                InserisciSeStringaValida(ref _descrizione, value, "Descrizione");
            }
        }
        //funzioni generali
        public bool Equals(ProdottoGenerico p) {
            if (p == null) {
                return false;
            } else if (p == this) {
                return true;
            } else {
                return (p.Nome == this.Nome && p.Id == this.Id);
            }
        }

        public virtual float CalcolaPrezzoFinale() {
            return this.Prezzo;
        }

        protected void InserisciSeStringaValida(ref string campo, string val, string perErrore) {
            if (!String.IsNullOrWhiteSpace(val)) {
                campo = val;
            } else {
                throw new Exception($"Inserire il campo \"{perErrore}\" valido");
            }
        }

        protected void SettaSeMaggioreDiZeroMinoreDiMax(ref float campo, float val, string nomeCampo, int max) {
            if (val > 0 && val < max) {
                campo = val;
            } else {
                throw new Exception($"Il campo \"{nomeCampo}\" deve essere maggiore di 0 e minore di {max}");
            }
        }
    }
}

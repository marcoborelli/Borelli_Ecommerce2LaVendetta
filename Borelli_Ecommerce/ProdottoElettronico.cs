﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce {
    public class ProdottoElettronico : ProdottoGenerico {
        private string _codiceModello;

        public ProdottoElettronico(string id, string nome, string produttore, string descr, float prezzo, string _codiceMod) :base(id, nome, produttore, descr, prezzo) {
            this.CodiceModello = _codiceMod;
            GestisciPrezzo();
        }
        public string CodiceModello {
            get {
                return _codiceModello;
            }
            set {
                InserisciSeStringaValida(ref _codiceModello, value, "Codice Modello");
            }
        }

        public void GestisciPrezzo() {
            DateTime d = DateTime.Now;
            if ($"{d.DayOfWeek}" == "Monday") {
                this.Prezzo -= (5 * this.Prezzo) / 100; 
            }
        }

    }
}

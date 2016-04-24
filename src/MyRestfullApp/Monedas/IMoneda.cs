using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfullApp.Monedas
{
    public interface IMoneda
    {
        /// <summary>
        /// Calcula la cotización según la moneda seleccionada
        /// </summary>
        void Cotizar();
    }
}
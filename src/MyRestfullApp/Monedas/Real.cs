using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfullApp.Monedas
{
    public sealed class Real : IMoneda
    {
        #region Atributos
        private static volatile Real instance;
        private static object syncRoot = new Object();
        private decimal _compra;
        private decimal _venta;
        private string _ultimaActualizacion;
        #endregion

        #region Propiedades
        public decimal Compra
        {
            get { return _compra; }
            set { _compra = value; }
        }
        public decimal Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }
        public string UltimaActualizacion
        {
            get { return _ultimaActualizacion; }
            set { _ultimaActualizacion = value; }
        }
        #endregion

        #region Singleton
        private Real(){}
        public static Real Instance
        {
            get 
              {
                 if (instance == null) 
                 {
                    lock (syncRoot) 
                    {
                       if (instance == null) 
                          instance = new Real();
                    }
                 }

                 return instance;
              }
        }
        #endregion

        #region Metodos
        public void Cotizar()
        {
            //El real no cotiza nada
            throw new HttpException(401, "Unauthorized access");
        }
        #endregion
    }
}
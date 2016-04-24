using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MyRestfullApp.Monedas
{
    public sealed class Dolar : IMoneda
    {
        #region Atributos
        private static volatile Dolar instance;
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
        private Dolar(){}
        public static Dolar Instance
        {
            get 
              {
                 if (instance == null) 
                 {
                    lock (syncRoot) 
                    {
                       if (instance == null) 
                          instance = new Dolar();
                    }
                 }

                 return instance;
              }
        }
        #endregion

        #region Metodos
        public void Cotizar() 
        {
            //Busco la URL de la cotización del dolar en la configuración

            string url = ConfigurationManager.AppSettings["CotizacionDolarURL"];
            //Si no se encuentra en la configuración, uso una default
            if(string.IsNullOrEmpty(url))
                url = "http://www.bancoprovincia.com.ar/Principal/dolar";
            string serializedString = string.Empty;
            //Creo request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                //Busco una respuesta y la cargo en un string serializado
                WebResponse response = (WebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    serializedString = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                //
                WebResponse jsonResponse = ex.Response;
                using (Stream responseStream = jsonResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    serializedString = reader.ReadToEnd();
                }
            }
            object[] cot = (object[])(new JavaScriptSerializer().Deserialize(serializedString, typeof(object)));

            this._compra = decimal.Parse(cot[0].ToString().Replace('.',','));
            this._venta = decimal.Parse(cot[1].ToString().Replace('.', ','));
            this._ultimaActualizacion = cot[2].ToString();
        }
        #endregion

    }
}
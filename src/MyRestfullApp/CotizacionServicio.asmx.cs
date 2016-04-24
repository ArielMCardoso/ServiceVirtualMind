using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Linq;
using System.Web;
using MyRestfullApp.Monedas;
using System.Configuration;
using Data;

namespace MyRestfullApp
{
    [WebService]
    public class CotizacionServicio
    {
        
        [WebMethod(CacheDuration=120,
            Description="Devuelve la cotización actual de la moneda deseada.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CotizacionObtener(String NombreMoneda)
        {
            switch(NombreMoneda.ToUpper())
            {
                case "DOLAR":
                case "DOLARES":
                    {
                        Dolar.Instance.Cotizar();
                        return new JavaScriptSerializer().Serialize(Dolar.Instance);
                    }
                case "PESO":
                case "PESOS":
                    {
                        Peso.Instance.Cotizar();
                        return new JavaScriptSerializer().Serialize(Peso.Instance);
                    }
                case "REAL":
                case "REALES":
                    {
                        Real.Instance.Cotizar();
                        return new JavaScriptSerializer().Serialize(Real.Instance);
                    }
                default:
                    {
                        throw new HttpException(401, "Unauthorized access");
                    }
            }
        }
        [WebMethod(Description="Devuelve una lista de Usuarios")]
        public List<Users> ListarUsuarios()
        {
            UsersAccess usersAccess = new UsersAccess();
            return usersAccess.ListarUsuarios();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        private string CotizacionObtenerDolar()
        {
            Dolar.Instance.Cotizar();
            return new JavaScriptSerializer().Serialize(Dolar.Instance);
        }
    }
}
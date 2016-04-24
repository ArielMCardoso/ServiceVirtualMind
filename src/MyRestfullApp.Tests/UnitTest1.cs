using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRestfullApp.Monedas;
using Data;

namespace MyRestfullApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DolarTestNoCotizado()
        {
            Assert.IsTrue(Dolar.Instance.Compra == 0);
            Assert.IsTrue(Dolar.Instance.Venta == 0);
            Assert.IsTrue(string.IsNullOrEmpty(Dolar.Instance.UltimaActualizacion));
        }
        [TestMethod]
        public void DolarTestCotizado()
        {
            Dolar.Instance.Cotizar();
            Assert.IsTrue(Dolar.Instance.Compra!=0);
            Assert.IsTrue(Dolar.Instance.Venta!=0);
            Assert.IsTrue(!string.IsNullOrEmpty(Dolar.Instance.UltimaActualizacion));
        }
        [TestMethod]
        public void PesoTest()
        {
            Assert.IsTrue(Peso.Instance.Compra == 0);
            Assert.IsTrue(Peso.Instance.Venta == 0);
            Assert.IsTrue(string.IsNullOrEmpty(Peso.Instance.UltimaActualizacion));
            try { Peso.Instance.Cotizar(); }
            catch { }
            finally
            {
                Assert.IsTrue(Peso.Instance.Compra == 0);
                Assert.IsTrue(Peso.Instance.Venta == 0);
                Assert.IsTrue(string.IsNullOrEmpty(Peso.Instance.UltimaActualizacion));
            }
        }
        [TestMethod]
        public void RealTest()
        {
            Assert.IsTrue(Real.Instance.Compra == 0);
            Assert.IsTrue(Real.Instance.Venta == 0);
            Assert.IsTrue(string.IsNullOrEmpty(Real.Instance.UltimaActualizacion));
            try { Real.Instance.Cotizar(); }
            catch { }
            finally
            {
                Assert.IsTrue(Real.Instance.Compra == 0);
                Assert.IsTrue(Real.Instance.Venta == 0);
                Assert.IsTrue(string.IsNullOrEmpty(Real.Instance.UltimaActualizacion));
            }
        }
        /// <summary>
        /// Testeo de la conexion a la base de usuarios
        /// </summary>
        [TestMethod]
        public void BaseUsuariosConexionTest()
        {
            UsersAccess usersAccess = new UsersAccess();
            Assert.IsTrue(usersAccess.TestConnection());
        }
        /// <summary>
        /// Testeo que la base usuarios contenga usuarios
        /// </summary>
        [TestMethod]
        public void BaseUsuariosContenidoTest()
        {
            UsersAccess usersAccess = new UsersAccess();
            Assert.IsTrue(!string.IsNullOrEmpty(usersAccess.ListarUnUsuario().Nombre));
        }
    }
}

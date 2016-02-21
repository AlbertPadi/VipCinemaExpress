using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Tests
{
    [TestClass()]
    public class CartelerasTests
    {
        [TestMethod()]
        public void CartelerasTest()
        {
            
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Carteleras cartelera = new Carteleras();
            cartelera.PeliculaId = 0;
            Assert.IsTrue(cartelera.Insertar());
        }

        [TestMethod()]
        public void EditarTest()
        {
            Carteleras cartelera = new Carteleras();
            cartelera.CarteleraId = 1;
            cartelera.PeliculaId = 1;
            Assert.IsTrue(cartelera.Editar());
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Carteleras cartelera = new Carteleras();
            cartelera.CarteleraId = 1;
            Assert.IsTrue(cartelera.Editar());
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListadoTest()
        {
            Assert.Fail();
        }
    }
}
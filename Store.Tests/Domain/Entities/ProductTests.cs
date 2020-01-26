using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Entities;
using Store.Domain.Enums;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
namespace Store.Tests.Domain.Entities
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        [TestCategory("Product")]
        public void Criando_produto_sem_erros()
        {
            string _nome = "Produto 1";
            decimal _preco = 10;
            bool _active = true;

            var _product = new Product(_nome, _preco, _active);

            Assert.AreEqual(_product.Title, _nome);
            Assert.AreEqual(_product.Price, _preco);
            Assert.AreEqual(_product.Active, _active);

        }

        [TestMethod]
        [TestCategory("Product")]
        public void Criando_produto_sem_titulo_com_status()
        {
            string _nome = null;
            decimal _preco = 10;
            bool _active = true;

            var _product = new Product(_nome, _preco, _active);

            if (_product.Notifications != null)
            {
                return;
            }

        }

        [TestMethod]
        [TestCategory("Product")]
        public void Criando_produto_com_titulo_sem_status()
        {
            string _nome = null;
            decimal _preco = 0;
            bool _active = false;

            var _product = new Product(_nome, _preco, _active);

            if (_product.Notifications != null)
            {
                return;
            }

        }

    }
}

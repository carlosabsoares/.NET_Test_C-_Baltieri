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
    public class OrderItemTests
    {

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_product_e_quantidade_preenchidos()
        {
            var _product = new Product("Produto 1", 10, true);
            int quantidade = 10;

            var ordemItem = new OrderItem(_product, quantidade);


            Assert.AreEqual(ordemItem.Product, _product);
            Assert.AreEqual(ordemItem.Quantity, quantidade);
        }

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_com_product_preenchido_e_sem_quantidade_preenchidos()
        {
            var _product = new Product("Produto 1", 10, true);
            int quantidade = 0;

            var ordemItem = new OrderItem(_product, quantidade);

            Assert.AreEqual(ordemItem.Valid, false);

            //if (ordemItem.Notifications != null)
            //    return;

        }

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_sem_product_preenchido_e_com_quantidade_preenchidos()
        {
            Product _product = null;
            int quantidade = 10;

            var ordemItem = new OrderItem(_product, quantidade);

            Assert.AreEqual(ordemItem.Valid, false);

            //if (ordemItem.Notifications != null)
            //    return;
        }

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_sem_product_preenchido_e_sem_quantidade_preenchidos()
        {
            Product _product = null;
            int quantidade = 0;

            var ordemItem = new OrderItem(_product, quantidade);

            if (ordemItem.Notifications != null)
                return;
        }

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_calculo_de_taxa_retorno_igual()
        {
            var _product = new Product("Produto 1", 10, true);
            var quantidade = 10;

            var ordemItem = new OrderItem(_product, quantidade);

            var totalItem = ordemItem.Total();

            Assert.AreEqual(totalItem,100);

        }

        [TestMethod]
        [TestCategory("OrderItem")]
        public void valida_calculo_de_taxa_retorno_diferente()
        {
            var _product = new Product("Produto 1", 10, true);
            var quantidade = 10;

            var ordemItem = new OrderItem(_product, quantidade);

            var totalItem = ordemItem.Total();

            Assert.AreNotEqual(totalItem, 1000);

        }

    }
}

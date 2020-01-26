using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Domain.Entities
{
    [TestClass]
    public class CustumerTests
    {
        //private readonly Customer _customer = new Customer("André Baltieri", "andre@balta.io");

        [TestMethod]
        [TestCategory("Customer")]
        public void valida_custumer_com_nome_e_email_preenchidos()
        {

            string _nome = "Carlos";
            string _email = "carlosabsoares@gmail.com";

            var _customer = new Customer(_nome, _email);

            Assert.AreEqual(_customer.Name,_nome);

        }

        [TestMethod]
        [TestCategory("Customer")]
        public void valida_custumer_com_nome_preenchido_e_sem_email_preenchidos()
        {
            string _nome = "Carlos";
            string _email = null;

            var _customer = new Customer(_nome, _email);

            if (_customer.Notifications != null)
            {
                return;
            }
            Assert.AreEqual(_customer.Name, _nome);

        }

        [TestMethod]
        [TestCategory("Customer")]
        public void valida_custumer_sem_nome_preenchido_e_com_email_preenchidos()
        {
            string _nome = null;
            string _email = "carlosabsoares@gmail.com";

            var _customer = new Customer(_nome, _email);

            if (_customer.Notifications != null)
            {
                return;
            }
            Assert.AreEqual(_customer.Name, _nome);
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void valida_custumer_sem_nome_preenchido_e_sem_email_preenchidos()
        {
            string _nome = null;
            string _email = null;

            var _customer = new Customer(_nome, _email);

            if (_customer.Notifications != null)
            {
                return;
            }
            Assert.AreEqual(_customer.Name, _nome);
        }
    }
}

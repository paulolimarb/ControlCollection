﻿using ControlCollection.API.Controllers;
using ControlCollection.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ControlCollection.API.Tests.Controllers
{
    [TestClass]
    public class CollectionControllerTest
    {
        //ContactController ct = new ContactController(new Infra.Repository.ContactRepository());
        //Contact ObCont;7

        /// <summary>
        /// Verificar_Se_Numero_De_Telefone_Esta_Completo
        /// </summary>
        [TestMethod]
        public void VerifyPhoneTest()
        {

            //ViewResult result = ct.Create() as ViewResult;

            //ct.Create();
            //var result = Col.
        }


        [TestMethod]
        public void GetAllItems()
        {
            // Arrange
            var Item = new ItemCollection { Id = "xxxxxx", Name = "Sonho Grande", Author = "Cristiane", Type = "Livro", Location = "BHS5" };

            //var controller = new CollectionController();
                        
            //var result = controller.GetAll();

            //// Assert
            //Assert.AreSame(, result);
        }


    }
}

﻿
using ExpressionSerialization;
using Newtonsoft.Json;
using R2.Disaster.CoreEntities;
using R2.Disaster.Repository;
using R2.Disaster.Service;
using SignalRChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Xml.Linq;
using R2.Disaster.WebFramework.Mvc.Filter;
//using System.Web.Mvc;
using System.Web;

namespace ProductsApp.Controllers
{
    public class TestController : ApiController
    {
        private IBookService _bookService;
        //ProductRepository repsoitory = new ProductRepository();
        //Product[] products = new Product[] 
        //{ 
        //    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
        //    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
        //    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        //};
        [HttpGet]
        [NotImplExceptionFilter]
        public void Index()
        {
            throw new NotImplementedException();
        }

        public void Index(string name)
        {
            //return null;
        }
    }
}

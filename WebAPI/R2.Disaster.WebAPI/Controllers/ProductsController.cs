﻿
using R2.Disaster.CoreEntities;
using R2.Disaster.Repository;
using R2.Disaster.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        private IBookService _bookService;
        //ProductRepository repsoitory = new ProductRepository();
        //Product[] products = new Product[] 
        //{ 
        //    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
        //    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
        //    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        //};

        public ProductsController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        public ProductsController()
        {
        }

        public Book GetAllProducts()
        {
            // BookService service = new BookService(new BookRepository(new R2.Disaster.Data.R2DisasterContext()));
            return this._bookService.GetById(1);
        }

        public Book GetProduct(int id)
        {
            //var product = repsoitory.FindByID(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            //return Ok(product);
            return this._bookService.GetById(1);
        }
    }
}

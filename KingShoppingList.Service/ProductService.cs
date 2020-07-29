using AutoMapper;
using KingShoppingList.Contract;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using KingShoppingList.Model.Repositories;
using KingShoppingList.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service
{
    public class ProductService : IProductService
    {

       
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        public List<Product> getAll()
        {
            return _productRepository.getAll();

            
        }
    }
}

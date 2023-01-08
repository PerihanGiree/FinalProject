using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Global değişkenleri genellikle alt çizgiile veririz
       List<Product> _products;
        //Constructor kısayolu ctor ..
        public InMemoryProductDal()
        {
            //Bir veri tabanından geliyormuş gibi veriler oluşturduk..
            _products = new List<Product> {

             new Product{  ProductId=1,CategoryId=1,ProductName="Bardak ",UnitPrice=15,UnitsInStock=15},
             new Product{  ProductId=2,CategoryId=1,ProductName="Kamera ",UnitPrice=500,UnitsInStock=3},
             new Product{  ProductId=3,CategoryId=1,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
             new Product{  ProductId=4,CategoryId=1,ProductName="Klavye ",UnitPrice=150,UnitsInStock=65},
             new Product{  ProductId=5,CategoryId=1,ProductName="Fare",UnitPrice=85,UnitsInStock=1},


            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete=null;
            /*foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            //LINQ 
            //SingleOrDefault tek bir eleman bulmaya yarar Liste veri içinde tek tek gezer..
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            //Veri tabanındaki datayı business a vermem lazım
            return _products;
        }

        public List<Product> GetAllCategory(int categoryId)
        {
            //Where verdiğimiz ürünleri alır ve yeni bir listeye atar..
           return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
          Product  productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }
    }
}

using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObligatoriskOppgave1August.Controllers;
using ObligatoriskOppgave1August.Models;
using ObligatoriskOppgave1August.Models.Entities;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {

        private Mock<IProductRepository> _repository;

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange 
            _repository = new Mock<IProductRepository>();

            List<Product> fakeProducts = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Category ="Verktøy"},
                new Product {Name="Melk", Price=14.50m, Category ="Dagligvarer"},
                new Product {Name="Kjøttkaker", Price=32.00m, Category ="Dagligvarer"},
                new Product {Name="Brød", Price=25.50m, Category ="Dagligvarer"}
            }; _repository.Setup(x => x.GetAll()).Returns(fakeProducts);
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert 

            Assert.IsNotNull(result, "View Result is null");


        }

        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange 

            _repository = new Mock<IProductRepository>();

            List<Product> fakeProducts = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Category ="Verktøy"},
                new Product {Name="Melk", Price=14.50m, Category ="Dagligvarer"},
                new Product {Name="Kjøttkaker", Price=32.00m, Category ="Dagligvarer"},
                new Product {Name="Brød", Price=25.50m, Category ="Dagligvarer"}
            }; _repository.Setup(x => x.GetAll()).Returns(fakeProducts);
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = (ViewResult)controller.Index();

            // Assert 
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model,
                typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number of products");

        }
        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            // Arrange 
            _repository = new Mock<IProductRepository>();
            _repository.Setup(x => x.Save(It.IsAny<Product>()));
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Create(new Product());

            // Assert 
            _repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger 
            //_repository.Verify(x => x.save(It.IsAny<Product>()), Times.Exactly(1)); 

        }
    }
}
using Company.API.DataLayer.DTO;
using Company.API.DataLayer.Interfaces;
using Company.API.LogicLayer.Layers;
using Company.API.LogicLayer.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.LogicLayer.Tests
{
    [TestFixture]
    public class LogicDrinkLayerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void LogicDrinkLayer_GetAllDrinks_ReturnsTwoDifferentObjects()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.GetAllDrinks()).Returns(new List<Drink>
            {
                new Drink { Id = 1, Name = "test", Price = 1, Type = DrinkType.Hot },
                new Drink { Id = 2, Name = "test2", Price = 2, Type = DrinkType.Hot }
            });
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);
            var drinks = layer.GetAllDrinks();
            dataLayer.Verify(mock => mock.GetAllDrinks(), Times.Once());

            Assert.AreEqual(2, drinks.Count());
            Assert.AreNotEqual(drinks.First().Id, drinks.Last().Id);
            Assert.AreNotEqual(drinks.First().Name, drinks.Last().Name);
            Assert.AreNotEqual(drinks.First().Price, drinks.Last().Price);
            Assert.AreEqual(drinks.First().Type, drinks.Last().Type);
        }

        [Test]
        public void LogicDrinkLayer_GetDrink_ReturnsOneDrink()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.GetDrinkById(1)).Returns(new Drink { Id = 1, Name = "test" });
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);
            var drink = layer.GetDrink(1);
            dataLayer.Verify(mock => mock.GetDrinkById(1), Times.Once());

            Assert.NotNull(drink);
        }

        [Test]
        public void LogicDrinkLayer_GetDrink_ShouldNotReturnDrink()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.GetDrinkById(1)).Returns(new Drink { Id = 1, Name = "test" });
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);
            var drink = layer.GetDrink(2);
            dataLayer.Verify(mock => mock.GetDrinkById(2), Times.Once());

            Assert.Null(drink);
        }

        [Test]
        public void LogicDrinkLayer_InsertDrink_ShouldInsertDrink()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.InsertDrink(It.IsAny<Drink>())).Returns(1);
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);
            var drink = new DrinkLogic
            {
                Id = 1,
                Name = "n",
                Price = 1,
                Type = DrinkLogicType.Hot
            };


            var result = layer.InsertDrink(drink);
            dataLayer.Verify(mock => mock.InsertDrink(It.IsAny<Drink>()), Times.Once());

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void LogicDrinkLayer_UpdateDrink_ShouldUpdateDrink()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.UpdateDrink(It.IsAny<Drink>())).Returns(1);
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);
            var drink = new DrinkLogic
            {
                Id = 1,
                Name = "n",
                Price = 1,
                Type = DrinkLogicType.Hot
            };

            var result = layer.UpdateDrink(drink);
            dataLayer.Verify(mock => mock.UpdateDrink(It.IsAny<Drink>()), Times.Once());

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void LogicDrinkLayer_DeleteDrink_ShouldDeleteDrinkDrink()
        {
            var dataLayer = new Mock<IDataDrinkLayer>();
            dataLayer.Setup(x => x.DeleteDrink(It.IsAny<int>())).Returns(1);
            var userLayer = new Mock<IDataUserLayer>();
            var layer = new LogicDrinkLayer(dataLayer.Object, userLayer.Object);

            var result = layer.DeleteDrink(1);
            dataLayer.Verify(mock => mock.DeleteDrink(It.IsAny<int>()), Times.Once());

            Assert.AreEqual(result, 1);
        }

    }
}

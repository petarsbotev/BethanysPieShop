using BethanysPieShop.Controllers;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies() 
        {
            // Arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);
            // Act
            var result = pieController.List();
            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, model.Pies.Count());
        }
    }
}

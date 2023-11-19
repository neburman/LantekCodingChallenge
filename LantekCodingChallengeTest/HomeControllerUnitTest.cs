using LantekCodingChallenge.Controllers;
using LantekCodingChallenge.Helpers;
using LantekCodingChallenge.Models.Responses;
using LantekCodingChallenge.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Assert = Xunit.Assert;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace LantekCodingChallenge.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task IndexAsync_WithTechnologyFilter2_ReturnsViewWithCuttingMachines()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var configurationMock = new Mock<IConfiguration>();

            configurationMock.SetupGet(x => x["LantekApiCrendentials:Username"]).Returns("your-username");
            configurationMock.SetupGet(x => x["LantekApiCrendentials:Password"]).Returns("your-password");

            var controller = new HomeController(loggerMock.Object, configurationMock.Object);

            // Act
            var result = await controller.IndexAsync(2);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
        }


        [Fact]
        public async Task IndexAsync_WithTechnologyFilter5_ReturnsViewWithCuttingMachines()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var configurationMock = new Mock<IConfiguration>();

            configurationMock.SetupGet(x => x["LantekApiCrendentials:Username"]).Returns("your-username");
            configurationMock.SetupGet(x => x["LantekApiCrendentials:Password"]).Returns("your-password");

            var controller = new HomeController(loggerMock.Object, configurationMock.Object);

            // Act
            var result = await controller.IndexAsync(5);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
        }
    }
}

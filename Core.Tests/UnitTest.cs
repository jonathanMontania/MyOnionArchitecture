using Core.Application.Services;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Core.Tests
{
    public class UnitTest
    {
        private readonly Mock<IProductoRepository>  _repositoryMock;
        private readonly ProductoService _productoService;

        public UnitTest() 
        {
            _repositoryMock = new Mock<IProductoRepository>();
            _productoService = new ProductoService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CASO_OK_RETORNA_PRODUCTOS()
        {
            var productos = new List<Producto> { new Producto { Id = 1, Nombre = "Producto 1" } };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(productos);

            var result = await _productoService.GetAllProductosAsync(); ;

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Producto 1", result.First().Nombre);

            _repositoryMock.Verify(s => s.GetAllAsync(), Times.Once);
        }
    }
}
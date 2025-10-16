using Archive.Application.Features.Save;
using Archive.Controllers;
using Archive.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Archive.Test
{
    public class ArchiveControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<ArchiveController>> _mockLogger;
        private readonly ArchiveController _controller;

        public ArchiveControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<ArchiveController>>();
            _controller = new ArchiveController(_mockMediator.Object, _mockLogger.Object);
        }

        /// Тест успешного выполнения
        [Fact]
        public async Task Save_ValidRequest_ReturnsOk()
        {
            // Подготовка
            var request = new SaveRequest
            {
              
                ActivityKey = "testKey",
                Name = "Test Name",
                Reason = "Test Reason"
            };

            // Настройка мок-объекта для имитации успешной отправки
            _mockMediator.Setup(m => m.Send(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Выполнение
            var result = await _controller.Save(request);

            // Проверка, что метод Send был вызван с конкретным request и любым токеном отмены
            _mockMediator.Verify(m => m.Send(request, It.IsAny<CancellationToken>()), Times.Once);

            //Проверка, что результат выполнения метода имеет тип Ok
            Assert.IsType<OkObjectResult>(result);
            
        }
       
        // Тест с некорректными данными
        [Fact]
        public async Task Save_InvalidRequest()
        {
            // Подготовка
            SaveRequest request = new SaveRequest
            {
                ActivityKey = null,
                Name = "Test Name",
                Reason = "Test Reason"
            };

            // Выполнение
            var result = await _controller.Save(request);

            // Проверка
            Assert.Equal(false, (result as OkObjectResult).Value);
        }

    }
}

using JobCandidateHub.API.Controllers;
using JobCandidateHub.Interface;
using JobCandidateHub.Model;
using JobCandidateHub.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JobCandidateHub.Test
{
    public class CandidateControllerTests
    {
        private readonly Mock<ICandidateService<CandidateModel>> _mockCandidateService;
        private readonly CandidateController _controller;

        public CandidateControllerTests()
        {
            _mockCandidateService = new Mock<ICandidateService<CandidateModel>>();
            _controller = new CandidateController(_mockCandidateService.Object);
        }

        [Fact]
        public async Task Post_ValidCandidate_ShouldCallCreateServiceAndReturnSuccessResponse()
        {
            // Arrange
            var candidateModel = new CandidateModel
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@example.com",
                Comment = "This is Test comment",
            };
            var response = new ResponseModel<CandidateModel>
            {
                SuccessStatus = true,
                StatusCode = StatusCodes.Status200OK,
                Data = candidateModel
            };

            _mockCandidateService.Setup(service => service.IsExist(candidateModel.Email))
                .ReturnsAsync(false);
            _mockCandidateService.Setup(service => service.Create(candidateModel))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Post(candidateModel) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.True(((ResponseModel<CandidateModel>)result.Value).SuccessStatus);
        }

        [Fact]
        public async Task Post_ExistingCandidate_ShouldCallUpdateServiceAndReturnSuccessResponse()
        {
            // Arrange
            var candidateModel = new CandidateModel
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@example.com",
                Comment = "This is Test comment",
            };
            var response = new ResponseModel<CandidateModel>
            {
                SuccessStatus = true,
                StatusCode = StatusCodes.Status200OK,
                Data = candidateModel
            };

            _mockCandidateService.Setup(service => service.IsExist(candidateModel.Email))
                .ReturnsAsync(true);
            _mockCandidateService.Setup(service => service.Update(candidateModel))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Post(candidateModel) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.True(((ResponseModel<CandidateModel>)result.Value).SuccessStatus);
        }

        [Fact]
        public async Task Post_InvalidModelState_ShouldReturnBadRequestWithErrors()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Email is required");

            var candidateModel = new CandidateModel();

            // Act
            var result = await _controller.Post(candidateModel) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = (ResponseModel<CandidateModel>)result.Value;
            Assert.False(response.SuccessStatus);
            Assert.Contains("Email is required", response.ErrorMessage);
        }

        [Fact]
        public async Task Post_ServiceThrowsException_ShouldReturnBadRequestWithErrorMessage()
        {
            // Arrange
            var candidateModel = new CandidateModel
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@example.com",
                Comment = "This is Test comment",
            };

            _mockCandidateService.Setup(service => service.IsExist(candidateModel.Email))
                .ThrowsAsync(new System.Exception("Service error"));

            // Act
            var result = await _controller.Post(candidateModel) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = (ResponseModel<CandidateModel>)result.Value;
            Assert.False(response.SuccessStatus);
            Assert.Contains("Service error", response.ErrorMessage);
        }
    }
}
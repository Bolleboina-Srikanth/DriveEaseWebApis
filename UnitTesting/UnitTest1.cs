using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<CarContext> _mockDbContext;
        [TestMethod]
        public void SignUpTestCase1()
        {
            
            private readonly Mock<CarContext> _mockDbContext;
            private readonly UserController _userController;

            public UserControllerTests()
            {
                // Initialize mock database context
                _mockDbContext = new Mock<CarContext>();

                // Initialize UserController with the mock database context
                _userController = new UserController(_mockDbContext.Object);
            }

            [TestMethod]
            public async Task Registeration_Successful()
            {
                // Arrange
                var model = new UserRegisterationModel { /* Populate with valid user data */ };

                // Act
                var result = await _userController.Registeration(model) as OkObjectResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
                Assert.IsTrue((bool)result.Value["success"]);
                Assert.AreEqual("Registration successful", result.Value["message"]);
                // Add more assertions as needed
            }

            // Add more test methods for different scenarios
        }
    }
    }
}

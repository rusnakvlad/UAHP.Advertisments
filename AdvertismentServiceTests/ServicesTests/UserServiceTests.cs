using Advertisment.BLL.Services;
using Advertisment.DAL.IRepositories;
using Advertisment.DAL.UnitOfWork;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;

using static AdvertismentServiceTests.TestData.UsersTestData;
using Advertisment.DAL.Enteties;
using System.Collections.Generic;
using System.Linq;

namespace AdvertismentServiceTests.ServicesTests;

[TestFixture]
public class UserServiceTests
{
    private UserService userService;
    private const string expectedGetAllStoredProcedureName = "GetAllUsers";
    private const string expectedGetByIdStoredProcedureName = "GetUserById";
    private const string expectedConectionString = "Default";
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IUserRepository> mockUserRepository;

    [SetUp]
    public void SetUp()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        // Arrange
        mockUnitOfWork
            .Setup(uow => uow.UserRepository.GetAllAsync(expectedGetAllStoredProcedureName, expectedConectionString).Result)
            .Returns(GetUsersTestData);

        userService = new UserService(mockUnitOfWork.Object);

        var expectedResult = GetUsersTestData();

        // Act
        var actualResult = userService.GetAllAsync().Result;

        // Assert
        expectedResult.Should().BeEquivalentTo(actualResult);

    }

    //[Test]
    //public async Task GetByIdAsync_ShouldReturnUserById()
    //{
    //    const string userId = "1";
    //    var user = GetUsersTestData().ToList().FirstOrDefault(u => u.Id == userId);

    //    // Arrange
    //    mockUserRepository = new Mock<IUserRepository>();
    //    mockUserRepository.Setup(ur => ur.GetAsync(expectedGetByIdStoredProcedureName, It.IsAny<string>(), expectedConectionString).Result)
    //        .Returns(user);

    //    mockUnitOfWork
    //        .Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);

    //    userService = new UserService(mockUnitOfWork.Object);

    //    var expectedResult = GetUsersTestData().ToList().FirstOrDefault(u => u.Id == userId);

    //    // Act
    //    var actualResult = userService.GetByIdAsync(userId).Result;

    //    // Assert
    //    expectedResult.Should().BeEquivalentTo(actualResult);

    //}
}

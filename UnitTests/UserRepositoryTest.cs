﻿using Moq;


namespace UnitTests;
public class UserRepositoryTest
{

    //[Theory]
    //[InlineData(1, "TestUser")]
    //[InlineData(2, "AnotherUser")]
    //public async Task AddAsync(int id, string name)
    //{
    //    //var mockUserRepository = new Mock<IUserRepository>();
    //    //var user = new User(name);

    //    //mockUserRepository
    //    //    .Setup(repository => repository.AddAsync(It.IsAny<User>()))
    //    //    .Returns(Task.CompletedTask);

    //    //var userRepository = mockUserRepository.Object;

    //    //await userRepository.AddAsync(user);

    //    //mockUserRepository.Verify(
    //    //    repository => repository.AddAsync(It.Is<User>(u => u.Id == id && u.Name == name)),
    //    //    Times.Once
    //    //);

        
    //}

    //[Theory]
    //[InlineData(1, "TestUser")]
    //[InlineData(2, "AnotherUser")]
    //public async Task RemoveAsync(int id, string name)
    //{
    //    //var mockUserRepository = new Mock<IUserRepository>();

    //    //var user = new User(name);

    //    //mockUserRepository
    //    //     .Setup(repository => repository.DeleteAsync(id))
    //    //     .Returns(Task.FromResult(true));

    //    //var userRepository = mockUserRepository.Object;

    //    //var result = await userRepository.DeleteAsync(user.Id);

    //    //mockUserRepository.Verify(
    //    //repository => repository.DeleteAsync(It.Is<int>(i => i == user.Id)),
    //    //Times.Once
    //    //);

    //}

    //[Theory]
    //[InlineData(1, "TestUser")]
    //[InlineData(2, "AnotherUser")]
    //public async Task GetAsync(int id, string name)
    //{
    //    //var mockUserRepository = new Mock<IUserRepository>();

    //    //var user = new User(name);

    //    //mockUserRepository.Setup(repository =>
    //    //     repository.GetAsync(id))
    //    //    .ReturnsAsync(user);

    //    //var userRepository = mockUserRepository.Object;

    //    //var result = await userRepository.GetAsync(id);

    //    //mockUserRepository.Verify(repo => repo.GetAsync(It.Is<int>(i => i == user.Id)), Times.Once);

    //}
}

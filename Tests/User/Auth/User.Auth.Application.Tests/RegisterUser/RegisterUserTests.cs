using Microsoft.AspNetCore.Http;
using Moq;
using Security.Auth.Application.RegisterUser;
using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Domain.ValueObject;
using Security.Auth.Infrastructure.Security;

namespace User.Auth.Application.Tests.RegisterUser;

public class RegisterUserTests
{
    private Mock<UserSecurityRepository> _userSecurityRepositoryMock;
    private Mock<IPasswordHasher> _passwordHasher;

    public RegisterUserTests()
    {
        _userSecurityRepositoryMock = new Mock<UserSecurityRepository>();
        _passwordHasher = new Mock<IPasswordHasher>();
    }

    [Fact]
    public async Task Register_User_Already_Exist_ReturnsException()
    {
        var req = new RegisterUserCommand("tester@yopmail.com","Tester1223*", "SUPER_ADMIN", "198084301581");
        _userSecurityRepositoryMock.Setup(x => x.Find(It.IsAny<UserSecurityIdentification>(), CancellationToken.None)).ReturnsAsync(new UserSecurity());
        var registerUser = new RegisterUserUseCase(_userSecurityRepositoryMock.Object, _passwordHasher.Object);
        
        Assert.ThrowsAsync<BadHttpRequestException>(() => registerUser.Execute("tester@yopmail.com", "Tester1223*",
            "SUPER_ADMIN", "198084301581", CancellationToken.None));
    }
}
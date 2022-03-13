using Test.Models;
using Xunit;

namespace Tests;

public class LoginTest
{
    [Theory]
    [InlineData("user@email.com", "password")]
    public void ShouldAuthenticateValidUser(string email, string password)
    {
        var loginService = new LoginService();
        var isAuthenticated = loginService.Login(email, password);
        Assert.True(isAuthenticated);
    }

    [Theory]
    [InlineData("user@email.com2", "password")]
    [InlineData("user@email.com", "password2")]
    public void ShouldNotAuthenticateUserWithInvalidPasswordOrEmail(string email, string password)
    {
        var loginService = new LoginService();
        bool isAuthenticated = loginService.Login(email, password);
        Assert.False(isAuthenticated);
    }

    public class LoginService
    {
        public bool Login(string email, string password)
        {
            User user = new User
            {
                Email = "user@email.com",
                Password = "password"
            };

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;
            if (email.Equals(user.Email) && password.Equals(user.Password))
                return true;
            return false;
        }
    }
}
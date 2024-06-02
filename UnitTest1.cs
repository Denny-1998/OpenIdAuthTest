using NSubstitute;
using OpenIdAuthServer.Helper;
using OpenIdAuthServer.Models;
using OpenIdAuthServer.Repository;
using Xunit;
using Assert = Xunit.Assert;

namespace OpenIdAuthTest
{
    [TestClass]
    public class UnitTest1
    {
        [Theory]
        [InlineData("User1", "User1", true)]
        public void LoggedInUser_CompareUserName(string enteredUsername, string savedUsername, bool correctUser)
        {
            //arrange
            
            //create substitute
            var UserRepo = Substitute.For<IUserRepository>();
            string password = "Test1234";
            User user = new User
            {
                Email = "test@example.com",
                Username = savedUsername,
                UserId = 420,
                PasswordHash = "1234", 
                Salt="1234"
            };


            //set return values
            UserRepo.FindUser(enteredUsername).Returns(user);


            LoggedInUser userCredentials = new LoggedInUser(enteredUsername, password, UserRepo);


            //act
            bool CorrectUserName = userCredentials.checkUsername();



            //assert
            Assert.Equal(CorrectUserName, correctUser);

        }
        [Fact]
        public void TestTest()
        {
            bool test1=true;
            Assert.True(test1);
        }
    }
}
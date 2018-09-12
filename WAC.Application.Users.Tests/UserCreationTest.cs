using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAC.Contracts.Application.Users;
using WAC.Application.Users;
using WAC.Domain.Users;

namespace WAC.Application.Users.Tests
{
    [TestClass]
    public class UserCreationTest
    {
        private IUserService userService;
        private User user;

        [TestInitialize]
        public void SetUp()
        {
            user = GetUser();
            userService = new UserService();
        }

        private User GetUser()
        {
            var user = new User("User1", "Pass", 23);
            return user;
        }

        [TestMethod]
        public void SignUpTest()
        {
            userService.SignUp(user);
            Assert.AreEqual(user, userService.Get(user.Id));
        }

    }
}

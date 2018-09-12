using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WAC.Application.Users.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IUserService userService;

        [TestInitialize]
        public void SetUp()
        {
            user = GetUser();
            userService = new UserService(t);
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
            Assert.AreEquals(user, userService.Get(user));
        }

    }
}

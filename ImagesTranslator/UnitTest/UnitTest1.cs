using ImagesTranslator.Utility;
using ImagesTranslator.ViewModels;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Tests
    {
        private LoginViewModel vm;
        private RegisterViewModel rvm;
        private HomeViewModel hvm;
        private const string FINGERAUTH = "FINGERAUTH";


        [SetUp]
        public void Setup()
        {
            vm = new LoginViewModel();
            rvm = new RegisterViewModel();
            hvm = new HomeViewModel(new AzureService());

        }

        [Test]
        public async Task UserSignup()
        {
            var result = await rvm.UserSiginUp("Rusell Arnold", "982145", "111111111", "Programming", "s@mail.com", "123");
            Assert.IsTrue(result);
        }

        [Test]
        public async Task LoginWithEmailAndPassWord()
        {
            vm.Email = "s@mail.com";
            vm.Password = "123";

            var result = await vm.ChekUserCredetials();
            Assert.AreEqual(vm.Email, result.Email);
        }

        [Test]
        public async Task CheckAzureServer()
        {
            var result = await hvm.CheckAzureServer(@"C: \Users\User\Downloads\277594694_1899083370295440_2112161484201692271_n.jpg");
            Assert.AreEqual(result, "TEST PLAN TEMPLATE ");
        }

        [Test]
        public void FingerPrintMockTest()
        {
            Assert.AreEqual(FINGERAUTH, "FINGERAUTH");
        }

    }
}
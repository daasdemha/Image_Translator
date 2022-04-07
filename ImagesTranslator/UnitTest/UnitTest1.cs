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
            var result = await rvm.UserSiginUp("Rusell Arnold", "982145", "111111111", "Programming", "luqmanakram1234@gmail.com", "1234");
            Assert.IsTrue(result);
        }

        [Test]
        public async Task LoginWithEmailAndPassWord()
        {
            vm.Email = "luqmanakram1234@gmail.com";
            vm.Password = "1234";

            var result = await vm.ChekUserCredetials();
            Assert.AreEqual(vm.Email, result.Email);
        }

        [Test]
        public async Task CheckAzureServer()
        {
            var result = await hvm.CheckAzureServer(@"C:\Users\ASUS\Downloads\ImagesTranslator\ImagesTranslator\UnitTest\bin\Debug\277594694_1899083370295440_2112161484201692271_n.jpg");
            Assert.AreEqual(result, "TEST PLAN TEMPLATE ");
        }

        [Test]
        public void FingerPrintMockTest()
        {
            Assert.AreEqual(FINGERAUTH, "FINGERAUTH");
        }

    }
}
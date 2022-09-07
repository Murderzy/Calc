using Calc.App;

namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void CalcTest()
        {
            //Создаем объект главного класса
            Calc.App.Calc calc = new Calc.App.Calc();
            //Утверждение - должны получить не null результат, проверка на создание объекта
            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse1Digit()
        {
            Assert.AreEqual(1,RomanNumber.Parse("I"), "I == 1");
           
        }

        [TestMethod]
        public void RomanNumberParse2Digit()
        {
            
            Assert.AreEqual(4,RomanNumber.Parse("IV"), "IV == 4");
            Assert.AreEqual(15, RomanNumber.Parse("XV"), "XV == 15");
            
            Assert.AreEqual(900,RomanNumber.Parse("CM"), "CM == 900");
           
            Assert.AreEqual(400,RomanNumber.Parse("CD"), "CD == 400");
            
            Assert.AreEqual(55,RomanNumber.Parse("LV"), "LV == 55");
            Assert.AreEqual(40,RomanNumber.Parse("XL"), "XL == 40");
        }

        [TestMethod]
        public void RomanNumberParse3Digit()
        {
           
            Assert.AreEqual(30,RomanNumber.Parse("XXX"), "XXX == 30");
           
            Assert.AreEqual(1999,RomanNumber.Parse("MCMXCIX"), "MCMXCIX == 1999");
            
            Assert.AreEqual(401,RomanNumber.Parse("CDI"), "CDI == 4");
            
        }
    }
}
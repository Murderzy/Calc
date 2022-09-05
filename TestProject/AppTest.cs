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
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.Parse("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("LV"), 55);
            Assert.AreEqual(RomanNumber.Parse("XL"), 40);
        }
    }
}
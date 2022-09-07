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
            Assert.AreEqual(5, RomanNumber.Parse("V"), "I == 5");

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

        [TestMethod]
        public void RomanNumberInvalidDigit()
        {

            //с некоректной цифрой должен выдать исключение
            //Assert.AreEqual(0, RomanNumber.Parse("XXA")); - doesn't work -- fail test -- наше исключение воспринимается как ошибка
            //Сравнение типов исключений суровое 
            //Если ожидаемого исключение не будет, то и тест считается непройденным
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); });
            //сохраняем исключение,которое возникает во время тестирования
            var exp = new ArgumentException("Invalid char A");
            //ожидаемое исключение с предыдущего теста

            Assert.AreEqual(exp.Message, exc.Message);

            //Act()-выкидывает исколючение как это тестировать
            //Assert.SomeTest(Act()) - имеем вызов Act(), как следствие выброс исключения
            //как следствие остановка Assert.SomeTest() и провал теста как следствие
            //По этому действие с исключением оборачивают лямбдой (Action) и её передают на тест
            //Assert.SomeTest(()=>Act())
            //Assert.SomeTest(new Action(Act))
            //Аргумент метода SomeTest() - это действие, которое ещё не выполняется, в отличии от SomeTest(Act())
            //а значит это действие может быть выполненно средствами тестирования , в том числе с catch

        }
    }
}
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


            var exc1= Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1CMXCIX"); });
            var exc2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMHCIX"); });
            var exc3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMXCIф"); });
            var exc4 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1"); });

            var exp1 = new ArgumentException("Invalid char 1");
            var exp2 = new ArgumentException("Invalid char H");
            var exp3 = new ArgumentException("Invalid char ф");
            var exp4 = new ArgumentException("Invalid char 1");

            Assert.AreEqual(exp1.Message, exc1.Message);
            Assert.AreEqual(exp2.Message, exc2.Message);
            Assert.AreEqual(exp3.Message, exc3.Message);
            Assert.AreEqual(exp4.Message, exc4.Message);

            Assert.AreEqual(true, 
                Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }).Message.StartsWith("Invalid char"));
            //Assert.IsTrue( Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }).Message.StartsWith("Invalid char"))
        }


        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            //ArgumentException с сообщением "Empty string not allowed"
            Assert.AreEqual("Empty string not allowed",Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("")).Message);
            //ArgumentNullException без сообщения 
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }
        [TestMethod]
        public void RomanNumberNdigit()
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));// Daniel Test 
        }

        [TestMethod]
        public void RomanNumberCtor()
        {
            RomanNumber romanNumber = new RomanNumber();
            Assert.IsNotNull(romanNumber);

            romanNumber = new(10);
            Assert.IsNotNull(romanNumber);

            romanNumber = new(0);
            Assert.IsNotNull(romanNumber);
        }

        [TestMethod]
        public void RomanNumberToString()
        {
            RomanNumber romanNumber = new();
            Assert.AreEqual("N", romanNumber.ToString());



            romanNumber = new(10);
            Assert.AreEqual("X", romanNumber.ToString());



            romanNumber = new(90);
            Assert.AreEqual("XC", romanNumber.ToString());



            romanNumber = new(20);
            Assert.AreEqual("XX", romanNumber.ToString());



            romanNumber = new(1999);
            Assert.AreEqual("MCMXCIX", romanNumber.ToString());
        }

    }

}



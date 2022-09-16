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
            Assert.AreEqual(1, RomanNumber.Parse("I"), "I == 1");
            Assert.AreEqual(5, RomanNumber.Parse("V"), "I == 5");

        }

        [TestMethod]
        public void RomanNumberParse2Digit()
        {

            Assert.AreEqual(4, RomanNumber.Parse("IV"), "IV == 4");
            Assert.AreEqual(15, RomanNumber.Parse("XV"), "XV == 15");

            Assert.AreEqual(900, RomanNumber.Parse("CM"), "CM == 900");

            Assert.AreEqual(400, RomanNumber.Parse("CD"), "CD == 400");

            Assert.AreEqual(55, RomanNumber.Parse("LV"), "LV == 55");
            Assert.AreEqual(40, RomanNumber.Parse("XL"), "XL == 40");
        }

        [TestMethod]
        public void RomanNumberParse3Digit()
        {

            Assert.AreEqual(30, RomanNumber.Parse("XXX"), "XXX == 30");

            Assert.AreEqual(1999, RomanNumber.Parse("MCMXCIX"), "MCMXCIX == 1999");

            Assert.AreEqual(401, RomanNumber.Parse("CDI"), "CDI == 4");

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


            var exc1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1CMXCIX"); });
            var exc2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMHCIX"); });
            var exc3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMXCIф"); });
            var exc4 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1"); });

            var exp1 = new ArgumentException(Calc.App.Resources.GetInvalidCharMessage('1'));
            var exp2 = new ArgumentException(Calc.App.Resources.GetInvalidCharMessage('H'));
            var exp3 = new ArgumentException(Calc.App.Resources.GetInvalidCharMessage('ф'));
            var exp4 = new ArgumentException(Calc.App.Resources.GetInvalidCharMessage('1'));

            Assert.AreEqual(exp1.Message, exc1.Message);
            Assert.AreEqual(exp2.Message, exc2.Message);
            Assert.AreEqual(exp3.Message, exc3.Message);
            Assert.AreEqual(exp4.Message, exc4.Message);

            Assert.AreEqual(true,
                Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1X X1"); }).Message.StartsWith(Calc.App.Resources.GetInvalidCharMessage(' ').Substring(0,7)));
            //Assert.IsTrue( Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }).Message.StartsWith("Invalid char"))
        }


        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            // Будемо вимагати, щоб ще призводило до виключення
            // ArgumentException з повідомленням "Empty string not allowed"
            Assert.AreEqual(
                Calc.App.Resources.GetEmptyStringMessage(),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.Parse("")
                ).Message
            );

            // Parse(null!) буде ArgumentNullException без повідомлення
            Assert.ThrowsException<ArgumentNullException>(
                () => RomanNumber.Parse(null!)
            );
        }
        [TestMethod]
        public void RomanNumberNdigit()
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));// Daniel Test 
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XN"); });
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

        //0-2022
        [TestMethod]
        public void RomanNumberToStringParseCrosTest()
        {


            for (int n = 0; n <= 2022; ++n)
            {
                RomanNumber num = new(n);
                Assert.AreEqual(n, RomanNumber.Parse(num.ToString()));
            }
        }

        [TestMethod]
        public void RomanNumberTypeTest()
        {
            //RomanNumber rn1 = new() { Value = 10};
            //RomanNumber rn2 = rn1;
            //Assert.AreSame(rn1, rn2);//rn1 && rn2 ссылки на один объект 
            //RomanNumber rn3 = rn1 with { };//клонирование

            //Assert.AreNotSame(rn3, rn1);
            //Assert.AreEqual(rn3, rn1);
            //Assert.IsTrue(rn3== rn1);

            //RomanNumber rn4 = rn1 with { Value = 20};

            //Assert.AreNotSame(rn4, rn1);
            //Assert.AreNotEqual(rn4, rn1);
            //Assert.IsFalse(rn4 == rn1);

        }

        [TestMethod]
        public void RomanNumberNegativeDigitCrosTest()
        {
            //Parse test
            Assert.AreEqual(-400, RomanNumber.Parse("-CD"), "-CD == -400");

            Assert.AreEqual(-4, RomanNumber.Parse("-IV"), "-IV == -4");

            Assert.AreEqual(-10, RomanNumber.Parse("-X"), "-X == -10");

            Assert.AreEqual(-30, RomanNumber.Parse("-XXX"), "-XXX == -30");

            Assert.AreEqual(-1999, RomanNumber.Parse("-MCMXCIX"), "-MCMXCIX == -1999");

            //ToString test
            RomanNumber romanNumber = new(-10);
            Assert.AreEqual("-X", romanNumber.ToString());

            romanNumber = new(-1);
            Assert.AreEqual("-I", romanNumber.ToString());

            romanNumber = new(-90);
            Assert.AreEqual("-XC", romanNumber.ToString());

            romanNumber = new(-55);
            Assert.AreEqual("-LV", romanNumber.ToString());

            romanNumber = new(-120);
            Assert.AreEqual("-CXX", romanNumber.ToString());


            //error
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1CMXCIX-"); });
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("--1CMXCIX"); });
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("--1CMXCIX-"); });
        }
    }

    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void RomanNumberAddRNTest()
        {
            RomanNumber rn2 = new(2);
            RomanNumber rn5 = new(5);
            RomanNumber rn7 = new(7);
            RomanNumber rn10 = new() { Value = 10 };
            RomanNumber rn_5 = new() { Value = -5 };
            RomanNumber rn_7 = new() { Value = -7 };

            Assert.AreEqual(9, rn2.Add(rn7).Value);
            Assert.AreEqual(20, rn10.Add(rn10).Value);
            Assert.AreEqual(5, rn10.Add(rn_5).Value);
            Assert.AreEqual(3, rn10.Add(rn_7).Value);
            Assert.AreEqual(10, rn5.Add(rn5).Value);
            Assert.AreEqual(7, rn7.Add(new RomanNumber(0)).Value);
            Assert.AreEqual(5, rn5.Add(new RomanNumber()).Value);
            Assert.AreEqual(25, rn5.Add(new RomanNumber(20)).Value);
            Assert.AreEqual(6, rn5.Add(new RomanNumber(1)).Value);
            Assert.AreEqual(19, rn10.Add(new RomanNumber(9)).Value);
            Assert.AreEqual(-5, rn5.Add(new RomanNumber(-10)).Value);
            //Assert.AreEqual(rn7, rn2.Add(rn5));
            //Assert.AreEqual(rn_5, rn_7.Add(rn2));
            Assert.AreEqual("XVII", rn7.Add(rn10).ToString());
            Assert.AreEqual("III", rn_7.Add(rn10).ToString());
            //Assert.AreEqual("-V", rn_7.Add(rn2).ToString());
            Assert.AreEqual("-XII", rn_7.Add(rn_5).ToString());

            Assert.ThrowsException<ArgumentNullException>(() => rn2.Add((RomanNumber)null!));
        }

        [TestMethod]
        public void RomanNumberAddValueTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(20, rn.Add(10).Value);
            Assert.AreEqual("V", rn.Add(-5).ToString());
            //Assert.AreEqual(rn, rn.Add(0));

        }

        public void RomanNumberAddStringTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(30, rn.Add("XX").Value);
            Assert.AreEqual("-XL", rn.Add("-L").ToString());
            Assert.AreEqual(rn, rn.Add("N"));

            Assert.ThrowsException<ArgumentException>(() => rn.Add(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("-"));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("10"));
            Assert.ThrowsException<ArgumentNullException>(() => rn.Add((String)null!));
        }

        [TestMethod]
        public void AddStaticTest()
        {
            RomanNumber rn5 = RomanNumber.Add(2, 3);
            RomanNumber rn8 = RomanNumber.Add(rn5, 3);
            RomanNumber rn10 = RomanNumber.Add("I", "IX");
            RomanNumber rn9 = RomanNumber.Add(rn5, "IV");
            RomanNumber rn13 = RomanNumber.Add(rn5, rn8);
            // Задание: составить утверждения для тестирования RomanNumber.Add
            // Реализовать RomanNumber.Add и необходимые перегрузки
            // Расширить тесты с учетом исключительных ситуаций
            // ! В стиле ХР не делаем лишнего

            Assert.AreEqual(5, rn5.Value);
            Assert.AreEqual(8, rn8.Value);
            Assert.AreEqual(9, rn9.Value);
            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(13, rn13.Value);
        }

        [TestMethod]
        public void AddStaticObjectTest()
        {
            //тесты для фабричного метода с object параметрами
            object number1 = 2;
            object number2 = 3;

            object str1 = "IX";
            object str2 = "I";
            object str3 = "IV";

            RomanNumber rn5 = RomanNumber.Add(number1, number2);
            RomanNumber rn8 = RomanNumber.Add(rn5, number2);
            RomanNumber rn10 = RomanNumber.Add(str2, str1);
            RomanNumber rn9 = RomanNumber.Add(rn5, str3);
            RomanNumber rn13 = RomanNumber.Add(rn5, rn8);


            Assert.AreEqual(5, rn5.Value);
            Assert.AreEqual(8, rn8.Value);
            Assert.AreEqual(9, rn9.Value);
            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(13, rn13.Value);
        }

        [TestMethod]
        public void SubtractionStaticObjectTest()
        {
            //тесты для фабричного метода с object параметрами
            object number1 = 2;
            object number2 = 3;

            object str1 = "IX";
            object str2 = "I";
            object str3 = "IV";


            RomanNumber rn5 = RomanNumber.Sub(number1, number2); //-1
            RomanNumber rn8 = RomanNumber.Sub(rn5, number2); //  -4
            RomanNumber rn10 = RomanNumber.Sub(str2, str1); // -8
            RomanNumber rn9 = RomanNumber.Sub(rn5, str3); //  -5
            RomanNumber rn13 = RomanNumber.Sub(rn5, rn8); // -3


            Assert.AreEqual(-1, rn5.Value);
            Assert.AreEqual(-4, rn8.Value);
            Assert.AreEqual(-5, rn9.Value);
            Assert.AreEqual(-8, rn10.Value);
            Assert.AreEqual(3, rn13.Value);
        }


        [TestMethod]
        public void MultStaticObjectTest()
        {
            //тесты для фабричного метода с object параметрами
            object number1 = 2;
            object number2 = 3;

            object str1 = "IX";
            object str2 = "I";
            object str3 = "IV";


            RomanNumber rn5 = RomanNumber.Mult(number1, number2); //  6
            RomanNumber rn8 = RomanNumber.Mult(rn5, number2); //  18
            RomanNumber rn10 = RomanNumber.Mult(str2, str1); // 9
            RomanNumber rn9 = RomanNumber.Mult(rn5, str3); //  24
            RomanNumber rn13 = RomanNumber.Mult(rn5, rn8); // -3


            Assert.AreEqual(6, rn5.Value);
            Assert.AreEqual(18, rn8.Value);
            Assert.AreEqual(24, rn9.Value);
            Assert.AreEqual(9, rn10.Value);
            Assert.AreEqual(108, rn13.Value);
        }



        [TestMethod]
        public void EvalTest()
        {

            Assert.IsNotNull(CalcEnginee.EvalExpression("XI + IV"));
            //Assert.AreEqual(new RomanNumber(10), CalcEnginee.EvalExpression("XI - I"));
            Assert.ThrowsException<ArgumentException>(() => CalcEnginee.EvalExpression("2 + 3"));
        }

    }

}



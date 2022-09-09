using Calc.App;

namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void CalcTest()
        {
            //������� ������ �������� ������
            Calc.App.Calc calc = new Calc.App.Calc();
            //����������� - ������ �������� �� null ���������, �������� �� �������� �������
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

            //� ����������� ������ ������ ������ ����������
            //Assert.AreEqual(0, RomanNumber.Parse("XXA")); - doesn't work -- fail test -- ���� ���������� �������������� ��� ������
            //��������� ����� ���������� ������� 
            //���� ���������� ���������� �� �����, �� � ���� ��������� ������������
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); });
            //��������� ����������,������� ��������� �� ����� ������������
            var exp = new ArgumentException("Invalid char A");
            //��������� ���������� � ����������� �����

            Assert.AreEqual(exp.Message, exc.Message);

            //Act()-���������� ����������� ��� ��� �����������
            //Assert.SomeTest(Act()) - ����� ����� Act(), ��� ��������� ������ ����������
            //��� ��������� ��������� Assert.SomeTest() � ������ ����� ��� ���������
            //�� ����� �������� � ����������� ����������� ������� (Action) � � �������� �� ����
            //Assert.SomeTest(()=>Act())
            //Assert.SomeTest(new Action(Act))
            //�������� ������ SomeTest() - ��� ��������, ������� ��� �� �����������, � ������� �� SomeTest(Act())
            //� ������ ��� �������� ����� ���� ���������� ���������� ������������ , � ��� ����� � catch


            var exc1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1CMXCIX"); });
            var exc2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMHCIX"); });
            var exc3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MCMXCI�"); });
            var exc4 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("1"); });

            var exp1 = new ArgumentException("Invalid char 1");
            var exp2 = new ArgumentException("Invalid char H");
            var exp3 = new ArgumentException("Invalid char �");
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
            // ������ ��������, ��� �� ���������� �� ����������
            // ArgumentException � ������������ "Empty string not allowed"
            Assert.AreEqual(
                "Empty string not allowed",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.Parse("")
                ).Message
            );

            // Parse(null!) ���� ArgumentNullException ��� �����������
            Assert.ThrowsException<ArgumentNullException>(
                () => RomanNumber.Parse(null!)
            );
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
            //Assert.AreSame(rn1, rn2);//rn1 && rn2 ������ �� ���� ������ 
            //RomanNumber rn3 = rn1 with { };//������������

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
        }
    }

    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void RomanNumberAddRNTest()
        {
            RomanNumber rn1 = new() { Value = 5 };
            RomanNumber rn2 = new() { Value = 5 };

            Assert.AreEqual(10, (rn1.Add(rn2)).Value);
        }

        [TestMethod]
        public void RomanNumberAddTest()
        {
            var rn1 = new RomanNumber(10);
            Assert.AreEqual(20,rn1.Add(10).Value);
            Assert.AreEqual(30, rn1.Add("XX").Value);
            Assert.AreEqual("V", rn1.Add(-5).ToString());
            Assert.AreEqual("-XL", rn1.Add("-L").ToString());
        }
    }



}



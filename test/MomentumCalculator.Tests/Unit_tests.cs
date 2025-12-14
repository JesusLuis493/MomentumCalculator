namespace Tests
{
    using System.Buffers;
    using Operations;
    [TestClass]
    internal class unitTests
    {
        // Verificasion del metodo Validacion de Operations.cs
        [TestMethod]
        public void TestMethod1()
        {
            double result = Operations.Validacion("1234567890");
            Assert.AreEqual(1234567890, result);
        }

        // Verificasion del metodo CompX de Operations.cs
        [TestMethod]
        public void TestMethod2()
        {
            double result = Operations.CompX(600, 30);
            Assert.AreEqual(519.61, result);
        }
        // Verificasion del metodo CompY de Operations.cs
        [TestMethod]
        public void TestMethod2()
        {
            double result = Operations.CompY(600, 30);
            Assert.AreEqual(300, result);
        }

        // verificasion del metodo momentoX de Operations.cs
        [TestMethod]
        public void TestMethod4()
        {
            double result = Operations.MomentoX(80, 2);
            Assert.AreEqual(160, result);
        }

        // Verificasion del metodo momentoY de Operations.cs
        [TestMethod]
        public void TestMethod5()
        {
            double result = Operations.MomentoY(60, 5);
            Assert.AreEqual(300, result);
        }

        // verficasion del metodo ComponenteX de Operations.cs
        [TestMethod]
        public void TestMethod6()
        {
            double result = Operations.ComponenteX(600, 3, 5);
            Assert.AreEqual(360, result);
        }

        // verficasion del metodo ComponenteY de Operations.cs
        [TestMethod]
        public void TestMethod7()
        {
            double result = Operations.ComponenteY(600, 4, 5);
            Assert.AreEqual(480, result);
        }

        // verficasion del metodo Angulo de Operations.cs
        [TestMethod]
        public void TestMethod8()
        {
            double result = Operations.Angulo(60, 80);
            Assert.AreEqual(45, result);
        }
    }
}
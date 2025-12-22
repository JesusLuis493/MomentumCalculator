namespace Tests
{
    using Operations;
    [TestClass]
    internal class UnitTests
    {
        // Verificasion de comportamiento del metodo Validacion de Operations.cs
        [TestMethod]
        public void TestMethod_Validacion_input0()
        {
            double result = Operations.Validacion("1234567890");
            Assert.AreEqual(1234567890, result);
        }

        // Verificasion del metodo CompX de Operations.cs
        [TestMethod]
        public void TestMethod_CompX_correctCalculo()
        {
            double result = Operations.CompX(600, 30);
            Assert.AreEqual(519.61, result);
        }
        // Verificasion del metodo CompY de Operations.cs
        [TestMethod]
        public void TestMethod_CompY_correctCalculo()
        {
            double result = Operations.CompY(600, 30);
            Assert.AreEqual(300, result);
        }

        // verificasion del metodo momentoX de Operations.cs
        [TestMethod]
        public void TestMethod_MomentoX_correctCalculo()
        {
            double result = Operations.MomentoX(80, 2);
            Assert.AreEqual(160, result);
        }

        // Verificasion del metodo momentoY de Operations.cs
        [TestMethod]
        public void TestMethod_MomentoY_correctCalculo()
        {
            double result = Operations.MomentoY(60, 5);
            Assert.AreEqual(300, result);
        }

        // verficasion del metodo ComponenteX de Operations.cs
        [TestMethod]
        public void TestMethod_ComponenteX_correctCalculo()
        {
            double result = Operations.ComponenteX(600, 3, 5);
            Assert.AreEqual(360, result);
        }

        // verficasion del metodo ComponenteY de Operations.cs
        [TestMethod]
        public void TestMethod_ComponenteY_correctCalculo()
        {
            double result = Operations.ComponenteY(600, 4, 5);
            Assert.AreEqual(480, result);
        }

        // verficasion del metodo Angulo de Operations.cs
        [TestMethod]
        public void TestMethod_Angulo_correctCalculo()
        {
            double result = Operations.Angulo(60, 80);
            Assert.AreEqual(45, result);
        }
    }
}
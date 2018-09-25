using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionContainer;

namespace UnitTest
{
    [TestClass]
    public class ContainerUnitTest
    {
        public interface IA
        {
            string SayHello { get; set; }
        }

        public class A : IA
        {
            public string SayHello { get; set; }
        }


        [TestMethod]
        public void Resolve_TypeNotRegistered_ReturnsException()
        {
            // Arrange
            A myConcreteType = new A();
            IContainer container = new Container();
            container.Build();

            string expectedResult = String.Format("The requested Type: {0} has not been registered with this container.", typeof(IA));

            // Act
            var result = container.Resolve<IA>(LifeCycle.Transient);

            // Assert
            Assert.IsTrue(result.ToString().Contains(expectedResult));
        }
    }
}

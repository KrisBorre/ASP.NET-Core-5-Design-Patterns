﻿using Moq;
using Xunit;

namespace DecoratorPlain
{
    public class DecoratorBTest
    {
        public class Operation : DecoratorBTest
        {
            [Fact]
            public void Should_wrap_the_decorated_result()
            {
                // Arrange
                var componentMock = new Mock<IComponent>();
                componentMock.Setup(x => x.Operation()).Returns("Some value");
                var sut = new DecoratorB(componentMock.Object);

                // Act
                var result = sut.Operation();

                // Assert
                Assert.Equal("<DecoratorB>Some value</DecoratorB>", result);
            }
        }
    }
}

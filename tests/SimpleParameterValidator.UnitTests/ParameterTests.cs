using System;
using SimpleParameterValidator;
using Xunit;

namespace SimpleParameterValidation.UnitTests
{
    public class ParameterTests
    {
        [Fact]
        public void CannotBe_ArgumentNameNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentNullException>(() => target.CannotBe(new object(), null, _ => false));
        }

        [Fact]
        public void CannotBe_ExceptionMessageNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentNullException>(() => target.CannotBe(new object(), "parameter", null, _ => false));
        }

        [Fact]
        public void CannotBe_FunctionMatches_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBe(new object(), "parameter", _ => true));
        }

        [Fact]
        public void CannotBe_FunctionMatches_ValidationPasses()
        {
            var target = new Parameter();

            target.CannotBe(new object(), "parameter", _ => false);
        }

        [Fact]
        public void CannotBeNull_ArgumentNameNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNull(new object(), null));
        }

        [Fact]
        public void CannotBeNull_ArgumentNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNull(new object(), null));
        }

        [Fact]
        public void CannotBeNull_MessageNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNull(new object(), "parameter", null));
        }

        [Fact]
        public void CannotBeNull_ArgumentNotNull_ValidationPasses()
        {
            var target = new Parameter();

            target.CannotBeNull(new object(), "parameter");
        }

        [Fact]
        public void ShouldBe_ArgumentNameNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.ShouldBe(new object(), null, _ => true));
        }

        [Fact]
        public void ShouldBe_ExceptionMessageNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.ShouldBe(new object(), "parameter", null, _ => true));
        }

        [Fact]
        public void ShouldBe_FunctionMatches_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.ShouldBe(new object(), "parameter", _ => false));
        }

        [Fact]
        public void ShouldBe_FunctionMatches_ValidationPasses()
        {
            var target = new Parameter();

            target.ShouldBe(new object(), "parameter", _ => true);
        }
    }
}
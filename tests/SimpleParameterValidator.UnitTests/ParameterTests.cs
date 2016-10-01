using System;
using System.Collections;
using System.Collections.Generic;
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

        [Fact]
        public void CannotBeNullOrEmptyString_ArgumentNameNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty("string", null));
        }

        [Fact]
        public void CannotBeNullOrEmptyString_ExceptionMessageNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty("string", "parameter", null));
        }

        [Fact]
        public void CannotBeNullOrEmptyString_ParameterNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty((string)null, "parameter"));
        }

        [Fact]
        public void CannotBeNullOrEmptyString_ParameterEmptyString_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty(string.Empty, "parameter"));
        }

        [Fact]
        public void CannotBeNullOrEmptyString_FunctionMatches_ValidationPasses()
        {
            var target = new Parameter();

            target.CannotBeNullOrEmpty("string", "parameter");
        }

        [Fact]
        public void CannotBeNullOrEmptyIEnumerable_ArgumentNameNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty(new object[1], null));
        }

        [Fact]
        public void CannotBeNullOrEmptyIEnumerable_ExceptionMessageNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty(new object[1], "parameter", null));
        }

        [Fact]
        public void CannotBeNullOrEmptyIEnumerable_ParameterNull_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentNullException>(() => target.CannotBeNullOrEmpty((IEnumerable<object>)null, "parameter"));
        }

        [Fact]
        public void CannotBeNullOrEmptyIEnumerable_ParameterEmptyIEnumerable_ThrowsException()
        {
            var target = new Parameter();

            Assert.Throws<ArgumentException>(() => target.CannotBeNullOrEmpty(new object[0], "parameter"));
        }

        [Fact]
        public void CannotBeNullOrEmptyIEnumerable_FunctionMatches_ValidationPasses()
        {
            var target = new Parameter();

            target.CannotBeNullOrEmpty(new object[1], "parameter");
        }
    }
}
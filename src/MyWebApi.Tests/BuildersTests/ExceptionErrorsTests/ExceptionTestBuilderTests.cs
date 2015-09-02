﻿namespace MyWebApi.Tests.BuildersTests.ExceptionErrorsTests
{
    using System;
    using Exceptions;
    using NUnit.Framework;
    using Setups;
    using Setups.Controllers;

    [TestFixture]
    public class ExceptionTestBuilderTests
    {
        [Test]
        public void OfTypeShouldNotThrowExceptionWhenExceptionIsOfTheProvidedType()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.InternalServerErrorWithExceptionAction())
                .ShouldReturnInternalServerError()
                .WithException()
                .OfType<NullReferenceException>();
        }

        [Test]
        [ExpectedException(
            typeof(InvalidExceptionAssertionException),
            ExpectedMessage = "When calling InternalServerErrorWithExceptionAction action in WebApiController expected InvalidOperationException, but instead received NullReferenceException.")]
        public void OfTypeShouldThrowExceptionWhenExceptionIsNotOfTheProvidedType()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.InternalServerErrorWithExceptionAction())
                .ShouldReturnInternalServerError()
                .WithException()
                .OfType<InvalidOperationException>();
        }

        [Test]
        public void WithMessageShouldNotThrowExceptionWhenExceptionIsWithCorrectMessage()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.InternalServerErrorWithExceptionAction())
                .ShouldReturnInternalServerError()
                .WithException()
                .WithMessage("Test exception message")
                .AndAlso()
                .OfType<NullReferenceException>();
        }

        [Test]
        [ExpectedException(
            typeof(InvalidExceptionAssertionException),
            ExpectedMessage = "When calling InternalServerErrorWithExceptionAction action in WebApiController expected exception with message 'Exception message', but instead received 'Test exception message'.")]
        public void WithMessageShouldNotThrowExceptionWhenExceptionIsWithIncorrectMessage()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.InternalServerErrorWithExceptionAction())
                .ShouldReturnInternalServerError()
                .WithException()
                .OfType<NullReferenceException>()
                .AndAlso()
                .WithMessage("Exception message");
        }
    }
}

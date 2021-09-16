using FluentAssertions;
using System;
using Xunit;
using System.ComponentModel.DataAnnotations;
using dfd.DataAnnotations;
using dfd.DataAnnotations.Tests.Model;

namespace dfd.DataAnnotations.Tests
{
    public class ValidateAndThrowValidationExceptionTests
    {
        [Fact]
        public void DoesNotThrowErrorWithProperData()
        {
            var obj1 = new BasicObject() { RequiredField= "Value" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                .NotThrow("because the object has no validation errors");
        }

        [Fact]
        public void ThrowsErrorFromBuiltInAttributes()
        {
            var obj1 = new BasicObject() { RequiredField= "" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                .Throw<ValidationException>("because the RequiredField does not have a value.");
        }

        [Fact]
        public void ThrowsErrorFromCustomValidation()
        {
            var obj1 = new BasicObject() { RequiredField= "Value" , OptionalField="forcedError"};
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                .Throw<ValidationException>("because the OptionalField has an incorrect value  checked in the  Validate method.");
        }

        [Fact]
        public void ConfigDescriptionIncludedInErrorMessage()
        {
            var obj1 = new BasicObject() { RequiredField= null };
            Action action = () => obj1.ValidateAndThrowValidationException("CUSTOM CONFIG DESC!!!!");
            action.Should()
                  .Throw<ValidationException>("because the RequiredField does not have a value.")
                  .WithMessage("*CUSTOM CONFIG DESC!!!!*", "a custom config description was added");
        }


        [Fact]
           public void ValidatesAProperGuid()
        {
            var obj1 = new ObjectWithGuid() { Guid= "3d9851a2-ee7e-4da6-9bd0-a467ae30161f" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                .NotThrow("because the guid is a proper value");
        }

          [Fact]
           public void InValidatesAWrongGuid()
        {
            var obj1 = new ObjectWithGuid() { Guid= "3d9851a2-ee7e-4d-9bd0-a467ae30161f" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                 .Throw<ValidationException>("because the guid is not a proper value");
        }

        [Fact]
           public void IgnoresBlankGuid()
        {
            var obj1 = new ObjectWithGuid() { Guid= "" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                 .NotThrow("because the guid is blank and should pass unless required attribute is also added");
        }



         [Fact]
           public void ValidatesAnAlphaNumeric()
        {
            var obj1 = new ObjectWithAlphNumeric() { Value= "hjYYY1kah10aj" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                .NotThrow("because the AlphNumeric is a proper value");
        }

          [Theory]
          [InlineData("a b")]
          [InlineData("&")]
          [InlineData("=")]
          [InlineData("+")]
          [InlineData("3d9851a2-ee7e-4d-9bd0-a467ae30161f")]

           public void InValidatesAWrongAlphaNumeric(string value)
        {
            var obj1 = new ObjectWithAlphNumeric() { Value= value };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                 .Throw<ValidationException>($"because {value} is not a proper alphanumeric");
        }

        [Fact]
           public void IgnoresBlankALphaNumeric()
        {
            var obj1 = new ObjectWithAlphNumeric() { Value= "" };
            Action action = () => obj1.ValidateAndThrowValidationException();
            action.Should()
                 .NotThrow("because the AlphaNumeric is blank and should pass unless required attribute is also added");
        }


    }
}

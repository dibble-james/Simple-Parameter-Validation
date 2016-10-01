// <copyright file="Parameter.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SimpleParameterValidator
{
    using System;

    /// <summary>
    /// A simple set of method parameter validation methods.
    /// </summary>
    /// <seealso cref="SimpleParameterValidator.IValidateAParameter" />
    public class Parameter : IValidateAParameter
    {
        private static IValidateAParameter instance = new Parameter();

        /// <summary>
        /// Gets the <see cref="IValidateAParameter"/> instance.
        /// </summary>
        public static IValidateAParameter Validate { get; } = instance;

        /// <summary>
        /// Validate that the parameter does not match the <paramref name="validationExpression" />.
        /// </summary>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="argumentName">The name of the parameter being checked for use in exception.</param>
        /// <param name="validationExpression">The expression that validates the parameter.</param>
        public void CannotBe<TParam>(TParam parameter, string argumentName, Func<TParam, bool> validationExpression)
        {
            this.CannotBe(parameter, argumentName, $"{argumentName} failed parameter validation.", validationExpression);
        }

        /// <summary>
        /// Validate that the parameter does not match the <paramref name="validationExpression" />
        /// </summary>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        /// <param name="validationExpression">The expression that validates the parameter.</param>
        public void CannotBe<TParam>(TParam parameter, string parameterName, string exceptionMessage, Func<TParam, bool> validationExpression)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException(nameof(parameterName), $"{nameof(parameterName)} was not provided when validating parameter");
            }

            if (string.IsNullOrEmpty(exceptionMessage))
            {
                throw new ArgumentNullException(nameof(exceptionMessage), $"{nameof(exceptionMessage)} was not provided when validating parameter [{parameterName}]");
            }

            if (validationExpression(parameter))
            {
                throw new ArgumentException(exceptionMessage, parameterName);
            }
        }

        /// <summary>
        /// Validate that <paramref name="parameter" /> is not null.
        /// </summary>
        /// <param name="parameter">The parameter to validate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        public void CannotBeNull(object parameter, string parameterName)
        {
            this.CannotBeNull(parameter, parameterName, $"Parameter [{parameterName}] cannot be null.");
        }

        /// <summary>
        /// Validate that <paramref name="parameter" /> is not null.
        /// </summary>
        /// <param name="parameter">The parameter to validate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        public void CannotBeNull(object parameter, string parameterName, string exceptionMessage)
        {
            this.CannotBe(parameterName, nameof(parameterName), $"{nameof(parameterName)} was not provided when validating parameter", x => string.IsNullOrEmpty(x));
            this.CannotBe(exceptionMessage, nameof(exceptionMessage), $"{nameof(exceptionMessage)} was not provided when validating parameter [{parameterName}]", x => string.IsNullOrEmpty(x));

            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, exceptionMessage);
            }
        }

        /// <summary>
        /// Validate that the parameter matches the <paramref name="validationExpression" />
        /// </summary>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="argumentName">The name of the parameter being checked for use in exception.</param>
        /// <param name="validationExpression">The expression that validates the parameter.</param>
        public void ShouldBe<TParam>(TParam parameter, string argumentName, Func<TParam, bool> validationExpression)
        {
            this.ShouldBe(parameter, argumentName, $"{argumentName} failed parameter validation.", validationExpression);
        }

        /// <summary>
        /// Validate that the parameter matches the <paramref name="validationExpression" />
        /// </summary>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        /// <param name="validationExpression">The expression that validates the parameter.</param>
        public void ShouldBe<TParam>(TParam parameter, string parameterName, string exceptionMessage, Func<TParam, bool> validationExpression)
        {
            this.CannotBe(parameterName, nameof(parameterName), $"{nameof(parameterName)} was not provided when validating parameter", x => string.IsNullOrEmpty(x));
            this.CannotBe(exceptionMessage, nameof(exceptionMessage), $"{nameof(exceptionMessage)} was not provided when validating parameter [{parameterName}]", x => string.IsNullOrEmpty(x));

            if (!validationExpression(parameter))
            {
                throw new ArgumentException(exceptionMessage, parameterName);
            }
        }
    }
}

// <copyright file="IValidateAParameter.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SimpleParameterValidator
{
    using System;

    /// <summary>
    /// A simple set of method parameter validation methods.
    /// </summary>
    public interface IValidateAParameter
    {
        /// <summary>
        /// Validate that <paramref name="parameter"/> is not null.
        /// </summary>
        /// <param name="parameter">The parameter to validate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">The exception thrown if the validation fails.</exception>
        void CannotBeNull(object parameter, string parameterName);

        /// <summary>
        /// Validate that <paramref name="parameter"/> is not null.
        /// </summary>
        /// <param name="parameter">The parameter to validate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        /// <exception cref="System.ArgumentNullException">The exception thrown if the validation fails.</exception>
        void CannotBeNull(object parameter, string parameterName, string exceptionMessage);

        /// <summary>
        /// Validate that the parameter does not match the <paramref name="validationExpression"/>.
        /// </summary>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked for use in exception.</param>
        /// <param name="validationExpression">The expression that validates the argument.</param>
        /// <exception cref="ArgumentException">The parameter does not conform to the validation expression.</exception>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        void CannotBe<TParam>(TParam parameter, string parameterName, Func<TParam, bool> validationExpression);

        /// <summary>
        /// Validate that the parameter does not match the <paramref name="validationExpression"/>
        /// </summary>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        /// <param name="validationExpression">The expression that validates the argument.</param>
        /// <exception cref="ArgumentException">The parameter does not conform to the validation expression.</exception>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        void CannotBe<TParam>(TParam parameter, string parameterName, string exceptionMessage, Func<TParam, bool> validationExpression);

        /// <summary>
        /// Validate that the parameter matches the <paramref name="validationExpression"/>
        /// </summary>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked for use in exception.</param>
        /// <param name="validationExpression">The expression that validates the argument.</param>
        /// <exception cref="ArgumentException">The parameter does not conform to the validation expression.</exception>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        void ShouldBe<TParam>(TParam parameter, string parameterName, Func<TParam, bool> validationExpression);

        /// <summary>
        /// Validate that the parameter matches the <paramref name="validationExpression"/>
        /// </summary>
        /// <param name="parameter">The parameter to verify.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <param name="exceptionMessage">The message to put into the exception if the validation fails.</param>
        /// <param name="validationExpression">The expression that validates the argument.</param>
        /// <exception cref="ArgumentException">The parameter does not conform to the validation expression.</exception>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        void ShouldBe<TParam>(TParam parameter, string parameterName, string exceptionMessage, Func<TParam, bool> validationExpression);
    }
}
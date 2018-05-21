﻿using System.Net;

namespace VkNet.Utils
{
	/// <summary>
    /// The HTTP response.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class HttpResponse<TResponse>
    {
        /// <summary>
        /// Gets the value (object deserialized from response).
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TResponse Value { get; private set; }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the call resulted in success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is the call resulted in success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the request URI.
        /// </summary>
        /// <value>
        /// The request URI.
        /// </value>
        public string RequestUri { get; private set; }

        /// <summary>
        /// Creates the success response.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="value">The value.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>The HTTP response.</returns>
        public static HttpResponse<TResponse> Success(HttpStatusCode httpStatusCode, TResponse value, string requestUri = "")
        {
            return new HttpResponse<TResponse>
            {
                Value = value,
                IsSuccess = true,
                StatusCode = httpStatusCode,
                RequestUri = requestUri
            };
        }

        /// <summary>
        /// Creates the failed response.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="message">The message.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>
        /// The HTTP response.
        /// </returns>
        public static HttpResponse<TResponse> Fail(HttpStatusCode httpStatusCode, string message, string requestUri = "")
        {
            return new HttpResponse<TResponse>
            {
                Message = message,
                StatusCode = httpStatusCode,
                RequestUri = requestUri,
            };
        }
    }
}
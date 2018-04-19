using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Skeddly.Model;

namespace Skeddly
{
	/// <summary>
	/// Provides access to the Skeddly API.
	/// </summary>
	public partial class SkeddlyClient : ISkeddlyClient
    {
		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class.
		/// Configuration will be retrieved from the
		/// appSettings section.
		/// </summary>
		public SkeddlyClient()
		{
			SkeddlyOptions options = new SkeddlyOptions();

			// Try reading from the configuration
			options.AccessKeyId = Skeddly.Helpers.ConfigurationHelpers.AppSetting("SkeddlyAccessKeyId");
			if (String.IsNullOrEmpty(options.AccessKeyId))
				throw new Exception("SkeddlyAccessKeyId not set in configuration");

			options.EndPoint = Skeddly.Helpers.ConfigurationHelpers.AppSetting("SkeddlyEndPoint");
			
			Init(options);
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class using
		/// the supplied access key as credentials.
		/// </summary>
		/// <param name="accessKeyId">Access key ID to use as credentials.</param>
		public SkeddlyClient(string accessKeyId)
		{
			if (accessKeyId == null)
				throw new ArgumentNullException("accessKeyId");
			if (String.IsNullOrEmpty(accessKeyId))
				throw new ArgumentOutOfRangeException("accessKeyId");

			SkeddlyOptions options = new SkeddlyOptions()
			{
				AccessKeyId = accessKeyId,
			};

			Init(options);
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class
		/// using the supplied credentials.
		/// </summary>
		/// <param name="credentials">Credentials to use.</param>
		public SkeddlyClient(ISkeddlyCredentials credentials)
		{
			if (credentials == null)
				throw new ArgumentNullException("credentials");

			SkeddlyOptions options = new SkeddlyOptions()
			{
				Credentials = credentials,
			};

			Init(options);
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class.
		/// Configuration will be retrieved from the SkeddlyOptions object.
		/// </summary>
		public SkeddlyClient(SkeddlyOptions options)
		{
			Init(options);
		}

		/// <summary>
		/// Gets or sets the credentials used to authorized the API calls.
		/// </summary>
		public ISkeddlyCredentials Credentials { get; set; }

		/// <summary>
		/// Gets or sets the endpoint URL.
		/// </summary>
		public string EndPoint { get; set; }

		protected virtual void Init(SkeddlyOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			if (options.Credentials != null)
				this.Credentials = options.Credentials;
			else if (!String.IsNullOrEmpty(options.AccessKeyId))
				this.Credentials = new AccessKeyCredentials(options.AccessKeyId);
			else
				throw new InvalidOperationException("AccessKeyId or Credentials must be configured.");

			if (!String.IsNullOrEmpty(options.EndPoint))
				this.EndPoint = options.EndPoint;
			else
				this.EndPoint = "https://api.skeddly.com";
		}
		
		public void Dispose()
		{
			// Nothing to do for now
		}

		protected virtual HttpClient CreateHttpClient()
		{
			var client = new HttpClient();

			client.BaseAddress = new Uri(this.EndPoint);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			string authScheme = this.Credentials.GetAuthorizationScheme();
			if (!String.IsNullOrEmpty(authScheme))
			{
				string authParameter = this.Credentials.GetAuthorizationParameter();
				if (String.IsNullOrEmpty(authParameter))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authScheme);
				else
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authScheme, authParameter);
			}

			return client;
		}

		internal class ErrorResponse
		{
			public string Message { get; set; }
			public string ErrorCode { get; set; }
		}

		private Task<ResponseT> InvokeGetAsync<ResponseT>(string action)
		{
			return InvokeGetAsync<ResponseT>(action, null);
		}

		private async Task<ResponseT> InvokeGetAsync<ResponseT>(string action, IEnumerable<JsonConverter> jsonConverters)
		{	
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.GetAsync(action);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}

				if (jsonConverters != null &&
					jsonConverters.Any())
				{
					var formatters = new JsonMediaTypeFormatter[] 
					{
						new JsonMediaTypeFormatter 
						{
							SerializerSettings = new JsonSerializerSettings 
							{ 
								Converters = jsonConverters.ToList()
							} 
						}
					};

					return await httpResponse.Content.ReadAsAsync<ResponseT>(formatters);
				}
				else
				{
					return await httpResponse.Content.ReadAsAsync<ResponseT>();
				}

				
			}
		}

		private async Task<HttpResponseHeaders> InvokeGetAsync(string action, System.IO.Stream targetStream)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.GetAsync(action);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}

				await httpResponse.Content.CopyToAsync(targetStream);
				return httpResponse.Headers;
			}
		}

		private async Task InvokePostAsync<RequestT>(string action, RequestT request)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.PostAsJsonAsync(action, request);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}
			}
		}

		private Task<ResponseT> InvokePostAsync<ResponseT, RequestT>(string action, RequestT request)
		{
			return InvokePostAsync<ResponseT, RequestT>(action, request, null);
		}

		private async Task<ResponseT> InvokePostAsync<ResponseT, RequestT>(string action, RequestT request, IEnumerable<JsonConverter> jsonConverters)
		{
			using (var client = CreateHttpClient())
			{
				// If we ever need to format the JSON into camelCase, then
				// here's how to do it:

				//var jsonSerializerSettings = new JsonSerializerSettings();
				//var jsonFormatter = new JsonMediaTypeFormatter()
				//	{
				//		SerializerSettings = new JsonSerializerSettings()
				//		{
				//			ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
				//		}
				//	};

				//HttpResponseMessage httpResponse = await client.PostAsync(action, request, jsonFormatter);
				
				HttpResponseMessage httpResponse = await client.PostAsJsonAsync(action, request);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}

				if (jsonConverters != null &&
					jsonConverters.Any())
				{
					var formatters = new JsonMediaTypeFormatter[] 
					{
						new JsonMediaTypeFormatter 
						{
							SerializerSettings = new JsonSerializerSettings 
							{ 
								Converters = jsonConverters.ToList()
							} 
						}
					};

					return await httpResponse.Content.ReadAsAsync<ResponseT>(formatters);
				}
				else
				{
					return await httpResponse.Content.ReadAsAsync<ResponseT>();
				}
			}
		}

		private Task<ResponseT> InvokePutAsync<ResponseT, RequestT>(string action, RequestT request)
		{
			return InvokePutAsync<ResponseT, RequestT>(action, request, null);
		}

		private async Task<ResponseT> InvokePutAsync<ResponseT, RequestT>(string action, RequestT request, IEnumerable<JsonConverter> jsonConverters)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.PutAsJsonAsync(action, request);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}

				if (jsonConverters != null &&
					jsonConverters.Any())
				{
					var formatters = new JsonMediaTypeFormatter[] 
					{
						new JsonMediaTypeFormatter 
						{
							SerializerSettings = new JsonSerializerSettings 
							{ 
								Converters = jsonConverters.ToList()
							} 
						}
					};

					return await httpResponse.Content.ReadAsAsync<ResponseT>(formatters);
				}
				else
				{
					return await httpResponse.Content.ReadAsAsync<ResponseT>();
				}
			}
		}

		private async Task InvokePutAsync(string action)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.PutAsync(action, null);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}
			}
		}

		private async Task InvokeDeleteAsync(string action)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.DeleteAsync(action);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}
			}
		}
	}
}

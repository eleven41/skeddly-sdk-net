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
		/// Access key credentials will be retrieved from the SkeddlyAccessKeyId
		/// appSettings value.
		/// </summary>
		public SkeddlyClient()
		{
			// Try reading from the configuration
			string accessKeyId = System.Configuration.ConfigurationManager.AppSettings["SkeddlyAccessKeyId"];
			if (String.IsNullOrEmpty(accessKeyId))
				throw new Exception("SkeddlyAccessKeyId not set in configuration");
			
			this.Credentials = new AccessKeyCredentials(accessKeyId);
			
			Init();
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class using
		/// the supplied access key as credentials.
		/// </summary>
		/// <param name="accessKeyId">Access key ID to use as credentials.</param>
		public SkeddlyClient(string accessKeyId)
		{
			this.Credentials = new AccessKeyCredentials(accessKeyId);

			Init();
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class
		/// using the supplied credentials.
		/// </summary>
		/// <param name="credentials">Credentials to use.</param>
		public SkeddlyClient(ISkeddlyCredentials credentials)
		{
			this.Credentials = credentials;

			Init();
		}

		/// <summary>
		/// Gets or sets the credentials used to authorized the API calls.
		/// </summary>
		public ISkeddlyCredentials Credentials { get; set; }

		/// <summary>
		/// Gets or sets the endpoint URL.
		/// </summary>
		public string EndPoint { get; set; }

		protected virtual void Init()
		{
			string endPoint = System.Configuration.ConfigurationManager.AppSettings["SkeddlyEndPoint"];
			if (!String.IsNullOrEmpty(endPoint))
				this.EndPoint = endPoint;
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
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				this.Credentials.GetAuthorizationScheme(),
				this.Credentials.GetAuthorizationParameter());

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

		private async Task<ResponseT> InvokePutAsync<ResponseT, RequestT>(string action, RequestT request)
		{
			using (var client = CreateHttpClient())
			{
				HttpResponseMessage httpResponse = await client.PutAsJsonAsync(action, request);

				if (!httpResponse.IsSuccessStatusCode)
				{
					var response = await httpResponse.Content.ReadAsAsync<ErrorResponse>();
					throw CreateLocalException(httpResponse.StatusCode, response);
				}

				return await httpResponse.Content.ReadAsAsync<ResponseT>();
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

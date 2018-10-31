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

			Init(options);

			this.HttpClientProvider = new Providers.DefaultHttpClientProvider();
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

			this.HttpClientProvider = new Providers.DefaultHttpClientProvider();
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

			this.HttpClientProvider = new Providers.DefaultHttpClientProvider();
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class.
		/// Configuration will be retrieved from the SkeddlyOptions object.
		/// </summary>
		public SkeddlyClient(SkeddlyOptions options)
		{
			Init(options);

			this.HttpClientProvider = new Providers.DefaultHttpClientProvider();
		}

		/// <summary>
		/// Initializes a new instance of the SkeddlyClient class.
		/// Configuration will be retrieved from the SkeddlyOptions object.
		/// </summary>
		public SkeddlyClient(SkeddlyOptions options, Providers.IHttpClientProvider httpClientProvider)
		{
			Init(options);

			this.HttpClientProvider = httpClientProvider;
		}

		/// <summary>
		/// Gets or sets the credentials used to authorized the API calls.
		/// </summary>
		public ISkeddlyCredentials Credentials { get; set; }

		/// <summary>
		/// Gets or sets the endpoint URL.
		/// </summary>
		public string EndPoint { get; set; }

		private Providers.IHttpClientProvider _httpClientProvider;

		/// <summary>
		/// Gets or sets the HttpClient provider. Mainly used for unit testing
		/// </summary>
		public Providers.IHttpClientProvider HttpClientProvider
		{
			get
			{
				return _httpClientProvider;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("HttpClientProvider");
				_httpClientProvider = value;
			}
		}

		private void Init(SkeddlyOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			if (options.Credentials != null)
				this.Credentials = options.Credentials;
			else if (!String.IsNullOrEmpty(options.AccessKeyId))
				this.Credentials = new AccessKeyCredentials(options.AccessKeyId);
			else
			{
				string accessKeyId = Skeddly.Helpers.ConfigurationHelpers.AppSetting("SkeddlyAccessKeyId");
				if (!String.IsNullOrEmpty(accessKeyId))
					this.Credentials = new AccessKeyCredentials(accessKeyId);
				else
					throw new Exception("SkeddlyAccessKeyId not set in configuration");
			}

			if (!String.IsNullOrEmpty(options.EndPoint))
				this.EndPoint = options.EndPoint;
			else
			{
				string endPoint = Skeddly.Helpers.ConfigurationHelpers.AppSetting("SkeddlyEndPoint");
				if (!String.IsNullOrEmpty(endPoint))
					this.EndPoint = endPoint;
				else
					this.EndPoint = "https://api.skeddly.com";
			}
		}

		#region IDisposable

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				// Nothing for now
			}
		}

		#endregion

		protected virtual HttpClient CreateHttpClient()
		{
			var client = this.HttpClientProvider.CreateHttpClient();

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
					if (httpResponse.Content == null)
						throw new Skeddly.Model.SkeddlyException(httpResponse.ReasonPhrase);

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

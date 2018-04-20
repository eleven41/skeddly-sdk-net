using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RichardSzalay.MockHttp;
using Skeddly;
using Skeddly.Providers;

namespace SkeddlySDK.UnitTests
{
    [TestClass]
    public class SkeddlyClient_GetActions_Tests
    {
		const string DEFAULT_ENDPOINT = "http://localhost:8080";

		MockHttpMessageHandler _mockHttp;
		Mock<IHttpClientProvider> _httpClientProvider;
		SkeddlyOptions _options;

		[TestInitialize]
		public void InitializeTest()
		{
			_mockHttp = new MockHttpMessageHandler();
			_httpClientProvider = new Mock<IHttpClientProvider>(MockBehavior.Strict);
			_httpClientProvider.Setup(p => p.CreateHttpClient())
				.Returns(() => _mockHttp.ToHttpClient());

			_options = new SkeddlyOptions();
			_options.AccessKeyId = "sk_123";
			_options.EndPoint = DEFAULT_ENDPOINT;
		}

		#region Helpers

		public ISkeddlyClient CreateClient()
		{
			// Create our Skeddly client
			return new SkeddlyClient(_options, _httpClientProvider.Object);
		}

		#endregion

		[TestMethod]
		public async Task no_options()
		{
			// Setup
			DateTime utcNow = DateTime.UtcNow;

			var expectedAction = new Skeddly.Model.Action()
			{
				ActionId = "a-1",
				ActionType = "amazon-start-ec2-instance",
				ActionVersionId = "av-1",
				IsCurrentVersion = true,
				IsEnabled = true,
				Schedule = new Skeddly.Model.ActionSchedule()
				{
					ScheduleType = "none",
					Parameters = new Skeddly.Model.NoneScheduleParameters(),
				},
				State = "active",
				Name = "name1",
			};

			_mockHttp.Expect(DEFAULT_ENDPOINT + "/api/Actions/a-1")
				.WithAuthorizationHeader(_options)
				.RespondJson(expectedAction);

			var client = CreateClient();

			// Execute
			var response = await client.GetActionAsync(new Skeddly.Model.GetActionRequest()
			{
				ActionId = "a-1",
			});

			// Check results

			{
				var action = response.Action;
				Assert.AreEqual(expectedAction.ActionId, action.ActionId);
				Assert.AreEqual(expectedAction.ActionType, action.ActionType);
				Assert.AreEqual(expectedAction.IsCurrentVersion, action.IsCurrentVersion);
				Assert.AreEqual(expectedAction.IsEnabled, action.IsEnabled);
				Assert.IsNull(action.Parameters);

				Assert.IsNotNull(action.Schedule);
				Assert.AreEqual("none", action.Schedule.ScheduleType);
				Assert.IsInstanceOfType(action.Schedule.Parameters, typeof(Skeddly.Model.NoneScheduleParameters));
			}
		}

		[TestMethod]
		public async Task with_parameters()
		{
			// Setup
			DateTime utcNow = DateTime.UtcNow;

			var expectedAction = new Skeddly.Model.Action()
			{
				ActionId = "a-1",
				ActionType = "amazon-start-ec2-instance",
				ActionVersionId = "av-1",
				IsCurrentVersion = true,
				IsEnabled = true,
				Parameters = new Skeddly.Model.AmazonStartEc2InstanceParameters()
				{
					InstanceIdentificationMethod = "by-instance-id",
				},
				Schedule = new Skeddly.Model.ActionSchedule()
				{
					ScheduleType = "none",
					Parameters = new Skeddly.Model.NoneScheduleParameters(),
				},
				State = "active",
				Name = "name1",
			};

			_mockHttp.Expect(DEFAULT_ENDPOINT + "/api/Actions/a-1")
				.WithQueryString("include", "Parameters")
				.WithAuthorizationHeader(_options)
				.RespondJson(expectedAction);

			var client = CreateClient();

			// Execute
			var response = await client.GetActionAsync(new Skeddly.Model.GetActionRequest()
			{
				ActionId = "a-1",
				Include = new List<Skeddly.Model.ActionIncludes>() { Skeddly.Model.ActionIncludes.Parameters },
			});

			// Check results

			{
				var action = response.Action;
				Assert.AreEqual(expectedAction.ActionId, action.ActionId);
				Assert.AreEqual(expectedAction.ActionType, action.ActionType);
				Assert.AreEqual(expectedAction.IsCurrentVersion, action.IsCurrentVersion);
				Assert.AreEqual(expectedAction.IsEnabled, action.IsEnabled);

				var parameters = action.Parameters as Skeddly.Model.AmazonStartEc2InstanceParameters;
				Assert.IsNotNull(parameters);

				Assert.AreEqual("by-instance-id", parameters.InstanceIdentificationMethod);
			}
		}
	}
}

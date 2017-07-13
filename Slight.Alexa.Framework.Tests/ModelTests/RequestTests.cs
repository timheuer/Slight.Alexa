using System.IO;

using Newtonsoft.Json;

using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;

using Xunit;

namespace Slight.Alexa.Framework.Tests.ModelTests
{
    public class RequestTests
    {
        private readonly string ExamplesPath = @"ModelTests" + System.IO.Path.DirectorySeparatorChar + "Examples";

        // The Alexa test console (as of 2017-07-13) sends the request timestamp in an invalid format:
        // instead of an ISO 8601 date, it sends the milliseconds since 1970-1-1 (such as what's used
        // for the Date object's ctor.
        [Fact]
        public void Can_handle_Test_Console_Invalid_Date()
        {
			const string example = "IntentRequestWithInvalidTimestamp.json";
			var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
			var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

			Assert.NotNull(convertedObj);
			Assert.Equal(typeof(IIntentRequest), convertedObj.Request.GetRequestType());
			Assert.Equal(typeof(IIntentRequest), convertedObj.GetRequestType());
            Assert.NotEqual(System.DateTime.MinValue, convertedObj.Request.Timestamp);
        }

        [Fact]
        public void Can_read_IntentRequest_example()
        {
            const string example = "IntentRequest.json";
            var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
            var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(IIntentRequest), convertedObj.Request.GetRequestType());
            Assert.Equal(typeof(IIntentRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_LaunchRequest_example()
        {
            const string example = "LaunchRequest.json";
            var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
            var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(ILaunchRequest), convertedObj.Request.GetRequestType());
            Assert.Equal(typeof(ILaunchRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_SessionEndedRequest_example()
        {
            const string example = "SessionEndedRequest.json";
            var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
            var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(ISessionEndedRequest), convertedObj.Request.GetRequestType());
            Assert.Equal(typeof(ISessionEndedRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_slot_example()
        {
            const string example = "GetUtterance.json";
            var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
            var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

            var request = Assert.IsAssignableFrom<IIntentRequest>(convertedObj.Request);
            var slot = request.Intent.Slots["Utterance"];
            Assert.Equal("how are you", slot.Value);
        }

        [Fact]
        public void Can_accept_new_versions()
        {
            const string example = "SessionEndedRequest.json";
            var json = File.ReadAllText(Path.Combine(ExamplesPath, example));
            var convertedObj = JsonConvert.DeserializeObject<SkillRequest>(json);

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(ISessionEndedRequest), convertedObj.Request.GetRequestType());
            Assert.Equal(typeof(ISessionEndedRequest), convertedObj.GetRequestType());
        }
    }
}
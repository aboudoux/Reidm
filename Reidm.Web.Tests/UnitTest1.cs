using FluentAssertions;
using Reidm.Web.Stores;
using Xunit;

namespace Reidm.Web.Tests {
	public class NavigateToShould {
		[Fact(DisplayName = "Append http if ommited")]
		public void Test6()
		{
			var message = new GlobalState.NavigateTo("www.test.com", false);
			message.Url.Should().Be("http://www.test.com");
		}

		[Fact(DisplayName = "dont append http if local url")]
		public void Test15()
		{
			var message = new GlobalState.NavigateTo("/test/A", false);
			message.Url.Should().Be("/test/a");
		}

		[Fact(DisplayName = "trim local url")]
		public void Test22()
		{
			var message = new GlobalState.NavigateTo(" /test/A ", false);
			message.Url.Should().Be("/test/a");
		}

		[Fact(DisplayName = "trim http url")]
		public void Test23() {
			var message = new GlobalState.NavigateTo("  http://www.test.com  ", false);
			message.Url.Should().Be("http://www.test.com");
		}
	}
}
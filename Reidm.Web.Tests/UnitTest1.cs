using FluentAssertions;
using Reidm.Web.Stores;
using Xunit;

namespace Reidm.Web.Tests {
	public class NavvigateToShould {
		[Fact(DisplayName = "Append http if ommited")]
		public void Test6()
		{
			var message = new GlobalState.NavigateTo("www.test.com", false);
			message.Url.Should().Be("http://www.test.com");
		}
	}
}
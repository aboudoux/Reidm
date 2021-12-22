using FluentAssertions;
using Reidm.Domain.Buildings;
using Reidm.Domain.Buildings.Events;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common.Events;
using Xunit;

namespace Reidm.Domain.Tests {
	public class BuildingTests {

		[Fact(DisplayName = "Create new building")]
		public void Test7()
		{
			var building = Building.ToStudy("TEST");
			building.UncommittedEvents.GetStream()
				.Should().HaveCount(1)
				.And.ContainItemsAssignableTo<BuildingAddedToStudy>();
		}

		[Fact(DisplayName = "change a building value")]
		public void Test19()
		{
			var building = Building.ToStudy("TEST");
			building.ChangeInfo(new Address("11 rue du test"));
			building.UncommittedEvents.GetStream()
				.Should().ContainEquivalentOf(new BuildingInfoChanged(new Address("11 rue du test")), options => options
					.ComparingByValue(typeof(IBuildingValue))
					.Excluding(b=>b.AggregateId)
					.Excluding(b=>b.Sequence));
		}

		[Fact(DisplayName = "don't change value if same informations")]
		public void Test33()
		{
			var building = Building.ToStudy("TEST");
			building.ChangeInfo(new Address("11 rue du test"));
			building.ChangeInfo(new Address("11 rue du test"));
			building.UncommittedEvents.GetStream()
				.Should().HaveCount(2);
		}

		[Fact(DisplayName = "Reload building from aggregate")]
		public void Test42()
		{
			History h = new(new IDomainEvent[]
			{
				new BuildingAddedToStudy("TEST"),
				new BuildingInfoChanged(new Address("12 rue du test")),
			});

			var building = new Building(h);
			building.AggregateId.Should().NotBeEmpty();
		}
	}
}
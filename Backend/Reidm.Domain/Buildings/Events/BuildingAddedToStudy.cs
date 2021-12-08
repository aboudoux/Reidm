using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Events {

	[SerializableTypeIdentifier("18")]
	public record BuildingAddedToStudy(BuildingLabel Label) : DomainEvent;


	/*
	 *
	 	toiture / chaudiere

	 *
	 */
}

using System.Linq;
using Reidm.Application.Buildings.Queries;
using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Contacts.Values;
using TechTalk.SpecFlow;

namespace Reidm.infrastructure.Tests.Steps;

[Binding]
public class StepTransformations
{
	[StepArgumentTransformation]
	public static BuildingLabel ToBuildingLabel(string label) => new(label);

	[StepArgumentTransformation]
	public static BuildingLabel[] ToBuildingLabels(Table table)
		=> table.Rows.Select(row => new BuildingLabel(row["Immeuble"])).ToArray();
	
	[StepArgumentTransformation]
	public static BuildingToStudyResult[] ToBuildingToStudyResult(Table table)
		=> table.Rows.Select(row =>
			new BuildingToStudyResult(string.Empty, row["Immeuble"], int.Parse(row["SellingPrice"]), int.Parse(row["Surface"]))).ToArray();

	[StepArgumentTransformation]
	public static ContactName ToContactName(string contactName)
		=> new(contactName);

	[StepArgumentTransformation]
	public static ContactResult[] ToContactResult(Table table)
		=> table.Rows.Select(row =>
			new ContactResult(string.Empty, row["Name"], row["Phone"], row["Email"], row["Quality"], row["Infos"]))
			.ToArray();

	[StepArgumentTransformation]
	public static ContactName[] ToContactNames(Table table)
		=> table.Rows.Select(row => new ContactName(row["Name"])).ToArray();
}
using System;
using System.Linq;
using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;
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
}
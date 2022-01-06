using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Reidm.Application.Buildings.Commands;
using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common;
using TechTalk.SpecFlow;

namespace Reidm.infrastructure.Tests.Steps 
{
	[Binding]
	public class BuildingSteps : StepBase
	{
		[Given(@"Aucun immeuble n'est à étudier")]
		public async Task GivenAucunImmeubleNestAEtudier()
		{
			(await Query(new GetAllBuildingToStudy())).Should().BeEmpty("Il y a des immeuble à étudier en base");
		}

		[Given(@"Une liste d'immeubles à étuder")]
		public async Task GivenUneListeDimmeublesAEtuder(BuildingLabel[] labels)
		{
			await labels.ForEachAsync(async a => await SendCommand(new AddBuildingToStudy(a)));
		}


		[Given(@"J'ajoute un nouvel immeuble a étudier du nom de ""([^""]*)""")]
		[When(@"J'ajoute un nouvel immeuble a étudier du nom de ""([^""]*)""")]
		public async Task WhenJajouteUnNouvelImmeubleAEtudierDuNomDe(BuildingLabel label)
		{
			await SendCommand(new AddBuildingToStudy(label));
		}

		[Given(@"Je modifie la valeur ""([^""]*)"" de l'immeuble ""([^""]*)"" en (.*)")]
		[When(@"Je modifie la valeur ""([^""]*)"" de l'immeuble ""([^""]*)"" en (.*)")]
		public async Task WhenJeModifieLaValeurDeLimmeubleEn(string data, BuildingLabel building, string value)
		{
			var selectedBuilding = (await Query(new GetAllBuildingToStudy())).First(a => a.BuildingLabel == building.Value);

			var info = data switch
			{
				"Surface" => new Surface(value.ToInt()) as IBuildingValue,
				"BuildYear" => new BuildYear(value.ToInt()),
				"PropertyTax" => new PropertyTax(value.ToInt()),
				"SellingPrice" => new SellingPrice(value.ToInt()),
				"Address" => new Address(value),
				"Comments" => new Comments(value),
				"LastWorks" => new LastWorks(value),
				"WantAddLink" => new WantAdLink(value),
				"BuildingLabel" => new BuildingLabel(value),

				"Attics" => new Attics(value.ToBool()),
				"Basement" => new Basement(value.ToBool()),
				"ClassifiedArea" => new ClassifiedArea(value.ToBool()),
				"SeparateElectricMeters" => new SeparateElectricMeters(value.ToBool()),
				"SeparateWaterMeters" => new SeparateWaterMeters(value.ToBool()),
				"SewageServices" => new SewageServices(value.ToBool()),
				"TownGas" => new TownGas(value.ToBool()),
			};

			await SendCommand(new ChangeBuildingInformation(selectedBuilding.BuildingId, info));
		}


		[Then(@"L'information ""([^""]*)"" de l'immeuble ""([^""]*)"" à pour valeur (.*)")]
		public async Task ThenLimmeubleAPourValeur(string data, BuildingLabel building, string value)
		{
			var selectedBuilding = (await Query(new GetAllBuildingToStudy())).First(a => a.BuildingLabel == building.Value);
			var buildingnfos = (await Query(new LoadBuilding(selectedBuilding.BuildingId)));

			switch (data)
			{
				case "Surface":
					buildingnfos.Surface.Should().Be(value.ToInt());
					break;
				case "BuildYear":
					buildingnfos.BuildYear.Should().Be(value.ToInt());
					break;
				case "PropertyTax":
					buildingnfos.PropertyTax.Should().Be(value.ToInt());
					break;
				case "SellingPrice":
					buildingnfos.SellingPrice.Should().Be(value.ToInt());
					break;
				case "Address":
					buildingnfos.Address.Should().Be(value);
					break;
				case "Comments":
					buildingnfos.Comments.Should().Be(value);
					break;
				case "LastWorks":
					buildingnfos.LastWorks.Should().Be(value);
					break;
				case "WantAddLink":
					buildingnfos.WantAddLink.Should().Be(value);
					break;
				case "Attics":
					buildingnfos.Attics.Should().Be(value.ToBool());
					break;
				case "SewageServices":
					buildingnfos.SewageServices.Should().Be(value.ToBool());
					break;
			}
		}

		[Then(@"Un nouvel immeuble nommé ""([^""]*)"" est à étudier\.")]
		public async Task ThenUnNouvelImmeubleNommeEstAEtudier_(BuildingLabel label)
		{
			(await Query(new GetAllBuildingToStudy())).First().BuildingLabel.Should().Be(label.Value);
		}

		[Then(@"La liste des immeubles à étudier est")]
		public async Task ThenLaListeDesImmeublesAEtudierEst(BuildingToStudyResult[] expected)
		{
			(await Query(new GetAllBuildingToStudy())).Should()
				.BeEquivalentTo(expected, a => a.Excluding(b => b.BuildingId));
		}
	}
}

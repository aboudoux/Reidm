using BlazorState;
using Reidm.Application.Contacts.Queries;
using Reidm.Web.Stores.Buildings;

namespace Reidm.Web.Stores.Contacts;

public class ContactState : State<BuildingState>
{
	public List<ContactResult> Contact = new();


	public override void Initialize()
	{
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux+longemiladeouf@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
		Contact.Add(new ContactResult("","Valentine BOUDOUX", "0614894072","valentine.boudoux@gmail.com", "Propriétaire", ""));
	}
}
﻿using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Application.Common;

public interface IContactRepository
{
	public ContactResult[] GetAllContact();

	public void Add(ContactId contactId, ContactName name);

	public void ChangeValue(ContactId contactId, IContactValue value);

	public void Remove(ContactId contactId);
}
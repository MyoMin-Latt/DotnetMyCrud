using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetMyCrud.Infrastructure.ContactRepo
{
    public interface IContactRepository
    {
        Task<Response> addContact(AddContactDto contact);
        Task<Response> getContact();
        Task<Response> updateContact(Contact contact);
        Task<Response> deleteContact(string id);
        Task<Response> searchContact(string search);
    }
}
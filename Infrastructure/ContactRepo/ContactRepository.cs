using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotnetMyCrud.Dto;
using Microsoft.EntityFrameworkCore;

namespace DotnetMyCrud.Infrastructure.ContactRepo
{
    public class ContactRepository : IContactRepository
    {
        public contact_DBContext _DBContext;

        public IDBUnitOfWork _DBUnitOfWork;

        public ContactRepository(IDBUnitOfWork dBUnitOfWork)
        {
            _DBContext = dBUnitOfWork.DBContext;
            _DBUnitOfWork = dBUnitOfWork;

        }

        public async Task<Response> addContact(AddContactDto contact)
        {
            try
            {
                Mapper _mapper = MapperExtension.GetMapper<AddContactDto, Contact>();
                Contact mapContact = _mapper.Map<Contact>(contact);
                mapContact.Id = Guid.NewGuid().ToString();
                await _DBContext.Contacts.AddAsync(mapContact);
                _DBUnitOfWork.Commit();

                var res = new Response()
                {
                    code = "201",
                    data = mapContact,
                };
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<Response> getContact()
        {
            try
            {
                List<Contact> contactList = await _DBContext.Contacts.ToListAsync();
                var res = new Response()
                {
                    code = "201",
                    data = contactList,
                };
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> updateContact(Contact contact)
        {
            try
            {
                var res = new Response();
                Contact? findContact = await _DBContext.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);
                if (findContact == null)
                {
                    res = new Response()
                    {
                        code = "003",
                        message = "Contact is no found"
                    };
                }
                else
                {
                    findContact.Name = contact.Name;
                    findContact.Age = contact.Age;
                    findContact.Phone = contact.Phone;

                    _DBContext.Contacts.Update(findContact);
                    _DBUnitOfWork.Commit();
                    res = new Response()
                    {
                        code = "201",
                        data = findContact
                    };
                }
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> deleteContact(string Id)
        {
            try
            {
                var res = new Response();
                Contact? findContact = await _DBContext.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
                if (findContact == null)
                {
                    res = new Response()
                    {
                        code = "003",
                        message = "Contact is no found"
                    };
                }
                else
                {
                    _DBContext.Contacts.Remove(findContact);
                    _DBUnitOfWork.Commit();
                    res = new Response()
                    {
                        code = "201",
                        message = "Delete contact succefully"
                    };
                }
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Shared.ResponseDataHandler;
using DotnetMyCrud.Infrastructure.ContactRepo;

namespace DotnetMyCrud.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        public readonly IContactRepository _contactRepository;

        public readonly IResponseHandler _response;

        public ContactController(IContactRepository contactRepository, IResponseHandler response)
        {
            _contactRepository = contactRepository;
            _response = response;
        }

        [HttpPost()]
        public async Task<IActionResult> AddContact([FromBody] AddContactDto contactDto)
        {
            try
            {

                var results = await _contactRepository.addContact(contactDto);
                if (results.code == "201")
                {
                    var response = _response.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.data });
                }

                var res = _response.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.message });

            }
            catch (Exception ex)
            {
                var response = _response.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetContact()
        {
            try
            {
                var results = await _contactRepository.getContact();
                if (results.code == "201")
                {
                    var response = _response.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.data });
                }

                var res = _response.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.message });

            }
            catch (Exception ex)
            {
                var response = _response.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            try
            {

                var results = await _contactRepository.updateContact(contact);
                if (results.code == "201")
                {
                    var response = _response.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.data });
                }

                var res = _response.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.message });

            }
            catch (Exception ex)
            {
                var response = _response.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteContact(string Id)
        {
            try
            {

                var results = await _contactRepository.deleteContact(Id);
                if (results.code == "201")
                {
                    var response = _response.GetResponse<ResponseData>(ResponseEnum.R201);
                    return Ok(new { code = response.code, message = response.message, data = results.data });
                }

                var res = _response.GetResponse<ResponseData>(ResponseEnum.R000);
                return StatusCode(500, new { code = res.code, message = res.message, description = results.message });

            }
            catch (Exception ex)
            {
                var response = _response.GetResponse<ResponseData>(ResponseEnum.R001);
                return BadRequest(new { code = response.code, message = response.message, description = ex.Message });
            }
        }


    }
}
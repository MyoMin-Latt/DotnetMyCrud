using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMyCrud.Dto
{
    public class AddContactDto
    {
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public int? Age { get; set; }
    }

    public class GetContactDto
    {
        public string? Name { get; set; }

        public int? Age { get; set; }
    }
}
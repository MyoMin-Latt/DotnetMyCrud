using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMyCrud.Shared.Dto
{
    public class Response
    {
        public dynamic? data { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
    }
}
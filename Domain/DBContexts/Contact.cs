using System;
using System.Collections.Generic;

namespace DotnetMyCrud.Domain.DBContexts;

public partial class Contact
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public int? Age { get; set; }
}

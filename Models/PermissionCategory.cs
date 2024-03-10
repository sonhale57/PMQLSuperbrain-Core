using System;
using System.Collections.Generic;

namespace PMQLSuperbrain_Core.Models;

public partial class PermissionCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Updatetime { get; set; }

    public int? Iduser { get; set; }

    public string? Ma { get; set; }

    public int? Stt { get; set; }

    public int? Enable { get; set; }

    public bool? Public { get; set; }

    public virtual Permission? Permission { get; set; }
}

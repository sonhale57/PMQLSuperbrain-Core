using System;
using System.Collections.Generic;

namespace PMQLSuperbrain_Core.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string? Ma { get; set; }

    public int? Idcategory { get; set; }

    public string? Name { get; set; }

    public int? Iduser { get; set; }

    public DateTime? Updatetime { get; set; }

    public int? Enable { get; set; }

    public string? RNote { get; set; }

    public string? WNote { get; set; }

    public virtual PermissionCategory IdNavigation { get; set; } = null!;

    public virtual User? IduserNavigation { get; set; }

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}

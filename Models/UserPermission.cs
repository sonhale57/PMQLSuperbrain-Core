using System;
using System.Collections.Generic;

namespace PMQLSuperbrain_Core.Models;

public partial class UserPermission
{
    public int Id { get; set; }

    public int? Iduser { get; set; }

    public int? Idpermission { get; set; }

    public int? Idtemplate { get; set; }

    public int? Lever { get; set; }

    public DateTime? Updatetime { get; set; }

    public int? Permision { get; set; }

    public int? PerR { get; set; }

    public int? PerA { get; set; }

    public int? PerE { get; set; }

    public int? PerW { get; set; }

    public int? Idcreate { get; set; }

    public virtual Permission? IdpermissionNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}

namespace PMQLSuperbrain_Core.Models
{
    public class CustomPermission
    {
            public int? Idcategory { get; set; }
            public string? CategoryCode { get; set; }
            public string CategoryName { get; set; }
            public List<Permission> Permissions { get; set; }

    }
}

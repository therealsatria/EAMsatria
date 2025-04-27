namespace EAMsatria.Models;
public class User : BaseEntity
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Departement { get; set; }
    public string Contact { get; set; }
    public DateTime LastLogin { get; set; }
}
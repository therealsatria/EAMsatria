namespace EAMsatria.Models
{
    public class Asset : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
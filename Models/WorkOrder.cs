namespace EAMsatria.Models
{
    public class WorkOrder : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime COmpletedDate { get; set; }
    }
}
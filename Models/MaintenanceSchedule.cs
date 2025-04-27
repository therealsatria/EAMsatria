namespace EAMsatria.Models
{
    public class MaintenanceSchedule : BaseEntity
    {
        public Asset Asset { get; set; }
        public Guid AssetId { get; set; }
        public string Frequency { get; set; }
        public DateTime NextDueDate { get; set; }
        public string Priority { get; set; }
    }
}
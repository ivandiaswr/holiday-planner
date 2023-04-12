namespace DataAccess.Dtos.Plan
{
    public class PlanReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AddicionalInformation { get; set; } = string.Empty;
    }
}

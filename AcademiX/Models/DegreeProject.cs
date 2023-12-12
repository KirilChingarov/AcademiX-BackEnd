namespace AcademiX.Models
{

    public class DegreeProject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DegreeSupervisorId { get; set; }
        public int ReviewerId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DegreeStatus Status { get; set; }
    }
    public enum DegreeStatus
    {
        Draft,
        InProgress,
        Review,
        Defense,
        Completed
    }


}

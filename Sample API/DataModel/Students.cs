using System.ComponentModel.DataAnnotations;

namespace Sample_API.DataModel
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}

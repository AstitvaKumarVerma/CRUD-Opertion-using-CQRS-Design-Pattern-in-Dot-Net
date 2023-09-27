
namespace CQRS_Pattern.Models.Response
{
    public class EmpResponse
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public DateTime EmpDob { get; set; }
        public string EmpAddress { get; set; } = null!;
    }
}

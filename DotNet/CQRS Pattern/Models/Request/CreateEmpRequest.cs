namespace CQRS_Pattern.Models.Request
{
    public class CreateEmpRequest
    {
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public DateTime EmpDob { get; set; }
        public string EmpAddress { get; set; } = null!;
    }
}


using System;
using System.Collections.Generic;

namespace CQRS_Pattern.Models
{
    public partial class AstitvaEmp308
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public DateTime EmpDob { get; set; }
        public string EmpAddress { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

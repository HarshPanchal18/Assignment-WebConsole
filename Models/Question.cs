using AssignmentWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApplication.Model {
    public class Question {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Assignment.Id))]
        public int? AssignmentId { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public DateTime? CreationTimestamp { get; set; }

        public DateTime? UpdationTimestamp { get; set; }

        public DateTime? DeletionTimestamp { get; set; }

        public string FunctionSignature { get; set; }

        public int ParameterCount { get; set; } = 0;

        public virtual Assignment Assignment { get; set; }

        //public virtual ICollection<Testcase> Testcases { get; set; } = new List<Testcase>();

    }
}

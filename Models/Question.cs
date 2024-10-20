using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApplication.Models {
    public class Question {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Assignment.Id))]
        public int AssignmentId { get; set; } = 0;

        public string Description { get; set; } = string.Empty;

        public bool Status { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public DateTime? CreationTimestamp { get; set; } = DateTime.Now;

        public DateTime? UpdationTimestamp { get; set; } = DateTime.Now;

        public DateTime? DeletionTimestamp { get; set; } = DateTime.Now;

        public string FunctionSignature { get; set; } = string.Empty;

        public int ParameterCount { get; set; } = 0;

        public virtual Assignment Assignment { get; set; } = new Assignment();

        public Question() { }
    }
}

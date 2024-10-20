using AssignmentWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApplication.Model {
    public class TestCase {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Question.Id))]
        public int QuestionId { get; set; }

        public string Input { get; set; } // The input for the test case (this can be a serialized string for complex objects)

        public string ExpectedOutput { get; set; } // The expected output of the test case

        // Optional: Maximum allowed execution time in milliseconds
        public int? ExecutionTimeLimit { get; set; } = 2000; // Default to 2 seconds

        // Optional: Maximum memory usage allowed (in kilobytes)
        public int? MemoryLimit { get; set; } = 1024 * 64; // Default to 64MB

        public bool IsEdgeCase { get; set; } = false; // Optional: Flag to indicate if this is an edge case

        public virtual Question Question { get; set; } // Relationship with the Question entity
    }

}

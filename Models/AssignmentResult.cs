using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentConsole.Model {
    public class AssignmentResult {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(AssignmentSubmission.Id))]
        public int SubmissionId { get; set; }
        public int Score { get; set; }
        public string Feedback { get; set; }

        public AssignmentResult() { }

        public AssignmentResult(int id, int submissionId, int score, string feedback) {
            Id = id;
            SubmissionId = submissionId;
            Score = score;
            Feedback = feedback;
        }

        public override string ToString() {
            return "AssignmentResult(" + Id + ", " + SubmissionId + ", " + Score + ", " + Feedback + ")";
        }
    }
}
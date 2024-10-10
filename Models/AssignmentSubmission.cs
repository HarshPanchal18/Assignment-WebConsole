using AssignmentWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApplication.Model {
    public class AssignmentSubmission {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Assignment.Id))]
        public int AssignmentId { get; set; }
        [ForeignKey(nameof(Student.Id))]
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Content { get; set; }
        public bool IsSubmitted { get; set; }

        public AssignmentSubmission() { }

        public AssignmentSubmission(int id, int assignmentId, int studentId, DateTime submissionDate, string content) {
            Id = id;
            AssignmentId = assignmentId;
            StudentId = studentId;
            SubmissionDate = submissionDate;
            Content = content;
            IsSubmitted = true; // Default to true upon creation
        }

        public override string ToString() {
            return "AssignmentSubmission(" + Id + ", " + AssignmentId + ", " + StudentId + ", " + SubmissionDate + ", " + Content + ", " + IsSubmitted + ")";
        }
    }
}
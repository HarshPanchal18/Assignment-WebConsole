namespace AssignmentConsole.Model {
    public class AssignmentResult {
        public int Id { get; set; }
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
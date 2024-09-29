namespace AssignmentWebApplication.Models {
    public class Assignment {

        public int Id { get; set; } // Assignment Id
        public int Number { get; set; } // Assignment Number
        public int StudentId { get; set; } // StudentId whose submission
        public int SubjectId { get; set; }
        public string Content { get; set; } // Assignment Content
        public int Semester { get; set; } // Assignment Semester

        public Assignment() { }

        public Assignment(int id, int number, int studentId, int subjectId, string content, int semester) {
            Id = id;
            Number = number;
            StudentId = studentId;
            SubjectId = subjectId;
            Content = content;
            Semester = semester;
        }

        public override string ToString() {
            return "Assignment(" + Id + ", " + Number + ", " + StudentId + ", " + SubjectId + ", " + Content + ", " + Semester + ")";
        }
    }
}

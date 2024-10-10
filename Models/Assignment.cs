using AssignmentWebApplication.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApplication.Models {
    public class Assignment {
        [Key]
        public int Id { get; set; } // Assignment Id
        public int Number { get; set; } // Assignment Number
        [ForeignKey(nameof(Student.Id))]
        public int StudentId { get; set; } // StudentId whose submission
        //[ForeignKey(nameof(Subject.Code))]
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

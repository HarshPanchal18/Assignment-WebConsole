using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentConsole.Model {
    public class TeacherSubject {

        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Teacher.Id))]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(Subject.Code))]
        public int SubjectId { get; set; }

        public TeacherSubject() { }

        public TeacherSubject(int id, int teacherId, int subjectId) {
            Id = id;
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
    }
}
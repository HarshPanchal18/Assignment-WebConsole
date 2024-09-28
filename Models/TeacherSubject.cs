namespace AssignmentConsole.Model {
    internal class TeacherSubject {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public TeacherSubject() { }

        public TeacherSubject(int id, int teacherId, int subjectId) {
            Id = id;
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
    }
}
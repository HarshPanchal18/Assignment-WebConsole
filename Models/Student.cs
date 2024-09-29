using System.ComponentModel.DataAnnotations;

namespace AssignmentConsole.Model {
    public class Student {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }

        public Student() { }

        public Student(int id, string name) {
            Id = id;
            Name = name;
        }

        public Student(int id, string name, int rollNo, int semester) {
            Id = id;
            Name = name;
            RollNo = rollNo;
            Semester = semester;
        }

        public override string ToString() {
            return "Student(" + Id + ", " + RollNo + ", " + Name + ", " + Semester + ", " + ")";
        }

    }
}

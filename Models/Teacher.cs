using System.ComponentModel.DataAnnotations;

namespace AssignmentConsole.Model {
    public class Teacher {

        [Key]
        public int Id { get; set; } // Teacher Id
        public string Name { get; set; } // Teacher Name
        public string Type { get; set; } // Type of teacher (optional)
        public string Department { get; set; } // Teacher Department
        public List<Subject> Subjects { get; set; } // List of subjects taught by the teacher

        public Teacher() {
            Subjects = new List<Subject>();
        }

        public Teacher(int id, string name, string type, string department, List<Subject> subjects) {
            Id = id;
            Name = name;
            Type = type;
            Department = department;
            Subjects = subjects;
        }

        public override string ToString() {
            return "Teacher(" + Id + ", " + Name + ", " + Type + ", " + Department + ", " + "[" + string.Join(", ", Subjects) + "]" + ")";
        }
    }
}

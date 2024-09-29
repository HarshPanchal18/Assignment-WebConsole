using System.ComponentModel.DataAnnotations;

namespace AssignmentConsole.Model {
    public class Subject {
        [Key]
        public string Code { get; set; } // Subject Code
        public string Name { get; set; }

        public static List<Subject> preDefinedSubjects = new List<Subject> {
            // Sem 1
            new Subject("FSMCA01","C++ Programming"),
            new Subject("FSMCA02","Data structures and Algorithms"),
            new Subject("FSMCA03","Computer Organization"),
            new Subject("FSMCA04","Discrete Mathematics"),
            new Subject("FSMCA05","Computer Networks"),

            // Sem 2
            new Subject("SSMCA01","Python Programming"),
            new Subject("SSMCA02","Operating Systems"),
            new Subject("SSMCA03","Database Management System"),
            new Subject("SSMCA04","Java Programming"),

            new Subject("SSMCA05","Linux Administration and Network Programming"),
            new Subject("SSMCA06","Data Science"),
            new Subject("SSMCA07","Networks and Cybersecurity"),

            // Sem 3
            new Subject("TSMCA01",".NET Programming"),
            new Subject("TSMCA02","Software Engineering"),

            new Subject("TSMCA03","Advanced Java Technology"),
            new Subject("TSMCA04","Web Technology and Programming"),
            new Subject("TSMCA05","Data Warehouse and Data Mining"),
            new Subject("TSMCA06","Machine Learning"),
            new Subject("TSMCA07","Mobile Application Programming")
        };

        public Subject() { }

        public Subject(string code, string name) {
            Name = name;
            Code = code;
        }

        public override string ToString() {
            return "Subject(" + Code + ", " + Name + ")";
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace AssignmentConsole.Model {
    internal class Testcase<Toutput> {

        public Testcase(Toutput output, params (DataType, string)[] inputs) {
            Inputs = inputs;
            Output = output;
        }

        public int Id { get; set; }

        public int QuestionId { get; set; }

        public (DataType, string)[] Inputs { get; set; }

        public Toutput Output { get; set; }

        public string InputValueDatatype { get; set; } = null;

        public bool IsHidden { get; set; } = false;

        public string OutputValueDatatype { get; set; } = null;

        public bool Status { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public DateTime? CreationTimestamp { get; set; }

        public DateTime? UpdationTimestamp { get; set; }

        public DateTime? DeletionTimestamp { get; set; }

        public virtual Question Question { get; set; } = null;

    }

}

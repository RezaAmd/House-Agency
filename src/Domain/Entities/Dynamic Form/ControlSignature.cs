using Domain.Enums.Dynamic_Form;

namespace Domain.Entities.Dynamic_Form
{
    public class ControlSignature
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegEx { get; set; }
        public ControlSignatureType Type { get; set; }
    }
}
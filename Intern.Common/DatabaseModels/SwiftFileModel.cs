using System.ComponentModel.DataAnnotations;

namespace Intern.Common.DatabaseModels
{
    public class SwiftFileModel<T>
    {
        [Key]
        public T Id { get; set; }
        public string F01 { get; set; }
        public string O799 { get; set; }
        public string Type { get; set; }
        public string SenderRef { get; set; }
        public string TransId { get; set; }
        public string BanksSending { get; set; }
        public string Body { get; set; }
        public string Mac { get; set; }
        public string Chk { get; set; }

        public SwiftFileModel()
        {

        }

        public SwiftFileModel(List<string> match)
        {
            F01 = match[0];
            O799 = match[1];
            Type = O799.Substring(0, 1);
            SenderRef = O799.Substring(1, 16);
            TransId = O799.Substring(17, 12);
            BanksSending = O799.Substring(29, 12);
            Body = match[2];
            Mac = match[3];
            Chk = match[4];
        }
    }
}

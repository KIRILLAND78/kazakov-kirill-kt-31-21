using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace kazakov_kirill_kt_31_21.Models
{
    public class Faculty
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? LeadProfessorId { get; set; }
        public virtual IEnumerable<Professor> Professors { get; set; }
        public virtual Professor? LeadProfessor { get; set; }
    }
}

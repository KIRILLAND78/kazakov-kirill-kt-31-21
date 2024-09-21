namespace kazakov_kirill_kt_31_21.Models
{
    //дисциплина
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long WorkloadId { get; set; }
        public virtual IEnumerable<Professor> Professors { get; set; }
        public virtual Workload Workload { get; set; }
    }
}

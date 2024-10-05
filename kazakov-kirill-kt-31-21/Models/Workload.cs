namespace kazakov_kirill_kt_31_21.Models
{
    //учебная нагрузка
    public class Workload
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}

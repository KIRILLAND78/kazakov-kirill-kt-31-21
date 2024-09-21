namespace kazakov_kirill_kt_31_21.Models
{
    //ученая степень
    public class Rank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Professor> Professors { get; set; }
    }
}

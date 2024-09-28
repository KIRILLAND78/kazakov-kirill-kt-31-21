namespace kazakov_kirill_kt_31_21.Models
{
    public class Professor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FIO { get { var g = Name.Split(" "); return $"{g[0]} {g[1][0]}.{g[2][0]}"; } }
        public long FacultyId { get; set; }
        public long RankId { get; set; }
        public long PostId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Post Post { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
        public virtual Faculty? FacultyLead { get; set; }
    }
}

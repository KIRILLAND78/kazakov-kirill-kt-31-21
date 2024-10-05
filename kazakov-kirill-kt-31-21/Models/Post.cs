namespace kazakov_kirill_kt_31_21.Models
{
    //должности
    public class Post
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Professor> Professors { get; set; }
    }
}

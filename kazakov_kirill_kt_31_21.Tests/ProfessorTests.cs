using kazakov_kirill_kt_31_21.Models;

namespace kazakov_kirill_kt_31_21.Tests
{
    public class ProfessorTests
    {
        [Fact]
        public void GetFIO_IvanovPetrNikolaevich_IvanovPN()
        {
            Professor professor = new Professor() { Name = "Ivanov Petr Nikolaevich"};
            Assert.Equal("Ivanov P.N.", professor.FIO);
        }

    }
}
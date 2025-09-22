namespace MonG1WebApp.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id=1,Name="ahmed",Address="Alex",ImageURL="m.png"});
            students.Add(new Student() { Id=2,Name="Mohamed",Address="Alex",ImageURL="m.png"});
            students.Add(new Student() { Id=3,Name="Sama",Address="Alex",ImageURL="2.jpg"});
            students.Add(new Student() { Id=4,Name="Sara",Address="Alex",ImageURL="2.jpg"});
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}

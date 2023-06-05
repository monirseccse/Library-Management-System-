using Infrastructure.BusinessObjects;

namespace Infrastructure.Services;

public interface IStudentService
{
    public Task AddStudent(Student student);
    public Task UpdateStudent(StudentEdit book);
    public Task<IList<Student>> GetStudents();
}

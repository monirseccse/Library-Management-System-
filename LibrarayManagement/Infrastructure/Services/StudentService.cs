using AutoMapper;
using StudentEo=Domain.Entities.Student;
using StudentBo =Infrastructure.BusinessObjects.Student;
using Infrastructure.UnitOfWorks;
using Infrastructure.BusinessObjects;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly IApplicationUnitOfWork _applicationUnitofwork;
    private readonly IMapper _mapper;


    public StudentService(
        IApplicationUnitOfWork applicationUnitOfWork,
        IMapper mapper)
    {
         _applicationUnitofwork = applicationUnitOfWork;
        _mapper = mapper;
    }

    public async Task AddStudent(StudentBo student)
    {
        var studentEo = _mapper.Map<StudentEo>(student);

        await _applicationUnitofwork.Student.AddAsync(studentEo);
        await _applicationUnitofwork.SaveAsync();
    }

    public Task<IList<StudentBo>> GetStudents()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateStudent(StudentEdit student)
    {
        var entity = await _applicationUnitofwork.Student.GetByIdAsync(student.Id);

        if (entity is not null)
        {
            entity = _mapper.Map(student, entity);
            await _applicationUnitofwork.SaveAsync();
        }
        else
        {
            throw new InvalidOperationException("Student does not exist");
        }
    }
}

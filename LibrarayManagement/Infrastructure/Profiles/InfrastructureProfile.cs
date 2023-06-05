using AutoMapper;
using BookEo = Domain.Entities.Book;
using BookBo = Infrastructure.BusinessObjects.Book;
using StudentEo = Domain.Entities.Student;
using StudentBo = Infrastructure.BusinessObjects.Student;
using Infrastructure.BusinessObjects;

namespace Infrastructure.Profiles;

public class InfrastructureProfile :Profile
{
	public InfrastructureProfile()
	{
		CreateMap<BookEo,BookBo>().ReverseMap();
		CreateMap<BookEdit,BookEo>().ReverseMap();
		CreateMap<StudentEo, StudentBo>().ReverseMap();
		CreateMap<StudentEo,StudentEdit>().ReverseMap();
	}
}

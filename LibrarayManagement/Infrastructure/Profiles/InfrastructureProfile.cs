using AutoMapper;
using BookEo = Domain.Entities.Book;
using BookBo = Infrastructure.BusinessObjects.Book;
using StudentEo = Domain.Entities.Student;
using StudentBo = Infrastructure.BusinessObjects.Student;
using StudenBookIssueAndReturnDetailBo = Infrastructure.BusinessObjects.StudenBookIssueAndReturnDetail;
using StudenBookIssueAndReturnDetailEo = Domain.Entities.StudenBookIssueAndReturnDetail;
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
		CreateMap<StudenBookIssueAndReturnDetailEo,StudenBookIssueAndReturnDetailBo>()
			.ReverseMap();
	}
}

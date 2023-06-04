using AutoMapper;
using BookEo = Domain.Entities.Book;
using BookBo = Infrastructure.BusinessObjects.Book;
using Infrastructure.BusinessObjects;

namespace Infrastructure.Profiles;

public class InfrastructureProfile :Profile
{
	public InfrastructureProfile()
	{
		CreateMap<BookEo,BookBo>().ReverseMap();
		CreateMap<BookEdit,BookEo>().ReverseMap();
	}
}

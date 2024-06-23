using System;
using SocialRefApp.Entities;
using SocialRefApp.Dtos.Student;
using SocialRefApp.Dtos.CurrentAffairs;
using SocialRefApp.Dtos.Vacancy;
using SocialRefApp.Dtos.Article;
using SocialRefApp;

namespace SocialAppRef
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile()
		{
             CreateMap<UserProfileAddDto, UserProfile>();


            // CreateMap<AddStudentRequestDto, Student>();
            // CreateMap<Student, GetStudentResponseDto>();
            // CreateMap<GetStudentResponseDto, Student>();
            // CreateMap<UpdateStudentRequestDto, Student>();

            // CreateMap<CurrentAffairUpdateRequestDto, CurrentAffairs>();
            // CreateMap<CurrentAffairsAddRequestDto, CurrentAffairs>();
            // CreateMap<CurrentAffairs, CurrentAffairsGetResponseDto>();

            // CreateMap<VacancyAddRequestDto, Vacancy>();
            // CreateMap<VacancyUpdateRequestDto, Vacancy>();
            // CreateMap<Vacancy, VacancyGetResponseDto>();

            // CreateMap<ArticleAddRequestDto, Article>();
            // CreateMap<ArticleUpdateRequestDto, Article>();
            // CreateMap<Article, ArticleGetResponseDto>();
        }
    }
}


using System;
using SocialRefApp.Data;
using SocialRefApp.Dtos.Vacancy;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.VacancyService
{
    public class VacancyService : IVacancyService
	{
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public VacancyService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        // public async Task<ServiceResponse<VacancyGetResponseDto>> GetVacancyById(int vacancyId)
        // {
        //     ServiceResponse<VacancyGetResponseDto> serviceResponse = new();
        //     try
        //     {

        //         Vacancy? vacancy = await _dataContext.Vacancy.Where(x => x.Id == vacancyId && x.IsActive == true).FirstOrDefaultAsync();

        //         if (vacancy == null)
        //         {
        //             throw new Exception("Vacancy not found");
        //         }

        //         serviceResponse.Message = "Record found";
        //         serviceResponse.Data = _mapper.Map<VacancyGetResponseDto>(vacancy);

        //         Student? createdBy = await _dataContext.Students.Where(x => x.UserId == vacancy.CreatedBy).FirstOrDefaultAsync();

        //         if (createdBy != null)
        //             serviceResponse.Data.CreatedByName = string.IsNullOrEmpty(createdBy.FirstName) ? "" : createdBy.FirstName;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {

        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<List<VacancyGetResponseDto>>> GetVacancyListBySearch()
        // {
        //     ServiceResponse<List<VacancyGetResponseDto>> serviceResponse = new();
        //     try
        //     {
        //         List<VacancyGetResponseDto>? Vacancy = await _dataContext.Vacancy.Where(c => c.IsActive == true).Select(s => _mapper.Map<VacancyGetResponseDto>(s)).ToListAsync();

        //         serviceResponse.Data = Vacancy;
        //         serviceResponse.Message = "Vacancies fetched";

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> AddVacancy(VacancyAddRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {

        //         Vacancy vacancy = _mapper.Map<Vacancy>(request);

        //         vacancy.CreatedBy = 1;
        //         vacancy.CreatedDate = DateTime.UtcNow;

        //         vacancy.ModifiedBy = 1;
        //         vacancy.ModifiedDate = DateTime.UtcNow;

        //         vacancy.IsActive = true;

        //         await _dataContext.Vacancy.AddAsync(vacancy);
        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Vacancy saved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> StatusChangeVacancy(VacancyStatusRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         Vacancy? vacancy = await _dataContext.Vacancy.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (vacancy is null)
        //         {
        //             throw new Exception("Unable to get vacancy record");
        //         }

        //         vacancy.IsActive = request.IsActive;

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Vacancy record status changed.";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> UpdateVacancy(VacancyUpdateRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         Vacancy? vacancy = await _dataContext.Vacancy.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (vacancy is null)
        //         {
        //             throw new Exception("Unable to get vacancy record.");
        //         }

        //         Vacancy updatedVacancy = _mapper.Map<Vacancy>(request);

        //         _dataContext.Vacancy.Update(updatedVacancy);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Vacancy updated.";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<List<Vacancy>>> GetUserSavedVacanciesBySearch(int userId)
        // {
        //     ServiceResponse<List<Vacancy>> serviceResponse = new();
        //     try
        //     {
        //         List<Vacancy>? vacancy = await _dataContext.Users.Where(x => x.UserId == userId).SelectMany(selector: x => x.Vacancies).ToListAsync();

        //         serviceResponse.Message = "Vacancies fetched.";
        //         serviceResponse.Data = vacancy;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> AddVacancySavedByUser(int vacancyId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         Vacancy? vacancy = await _dataContext.Vacancy.Where(x => x.Id == vacancyId).FirstOrDefaultAsync();

        //         if (vacancy == null)
        //         {
        //             throw new Exception("Unable to find vacancy record");
        //         }

        //         vacancy.Users = new List<User>(); // you could also do this in the constructor of Candidate
        //         vacancy.Users.Add(user);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Vacancy saved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> RemoveVacancySavedByUser(int vacancyId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {


        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).Include(x => x.Vacancies).FirstOrDefaultAsync();
        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         Vacancy? vacancy = await _dataContext.Vacancy.Where(x => x.Id == vacancyId).FirstOrDefaultAsync();

        //         if (vacancy == null)
        //         {
        //             throw new Exception("Unable to find vacancy record");
        //         }

        //         user?.Vacancies?.Remove(vacancy);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Vacancy unsaved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

    }
}


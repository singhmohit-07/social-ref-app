using SocialRefApp.Data;
using SocialRefApp.Dtos.Student;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public StudentService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

    //     async Task<ServiceResponse<List<GetStudentResponseDto>>> IStudentService.SaveNewStudent(AddStudentRequestDto newStudent, int userId)
    //     {
    //         ServiceResponse<List<GetStudentResponseDto>> serviceResponse = new();

    //         try
    //         {
    //             Student student = _mapper.Map<Student>(newStudent);

    //             if (userId < 0)
    //             {
    //                 throw new Exception("Invalid user Id");
    //             }

    //             student.UserId = userId;

    //             if (String.IsNullOrEmpty(student.FirstName))
    //             {
    //                 throw new Exception("First name is missing");
    //             }

    //             if (String.IsNullOrEmpty(student.LastName))
    //             {
    //                 throw new Exception("Last name is missing");
    //             }

    //             student.DateModified = DateTime.UtcNow;
    //             student.DateOfEnroll = DateTime.UtcNow;

    //             if (student.DateOfBirth is not null)
    //                 student.Age = DateTime.UtcNow.CompareTo(student.DateOfBirth);
    //             else
    //                 student.Age = null;

    //             if (String.IsNullOrEmpty(student.Gender))
    //                 student.Gender = "";
    //             else
    //                 student.Gender = newStudent.Gender;

    //             await _dataContext.Students.AddAsync(student);

    //             await _dataContext.SaveChangesAsync();

    //             serviceResponse.Data = _dataContext.Students.Select(s => _mapper.Map<GetStudentResponseDto>(s)).ToList();

    //             serviceResponse.Message = "User information added";

    //             return serviceResponse;
    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Success = false;
    //             serviceResponse.Message = ex.Message;
    //             return serviceResponse;
    //         }
    //     }

    //     async Task<ServiceResponse<GetStudentResponseDto>> IStudentService.UpdateStudent(UpdateStudentRequestDto updateStudent)
    //     {
    //         ServiceResponse<GetStudentResponseDto> serviceResponse = new();

    //         try
    //         {
    //             Student? student = await _dataContext.Students.FirstOrDefaultAsync(s => s.StudentId == updateStudent.StudentId);

    //             if (student is null)
    //             {
    //                 throw new Exception("Student not found.");
    //             }

    //             //_mapper.Map(updateStudent, student);

    //             if (String.IsNullOrEmpty(updateStudent.FirstName))
    //             {
    //                 throw new Exception("First name is missing");
    //             }

    //             student.FirstName = updateStudent.FirstName;

    //             if (String.IsNullOrEmpty(updateStudent.LastName))
    //             {
    //                 throw new Exception("Last name is missing");
    //             }

    //             student.LastName = updateStudent.LastName;

    //             if (updateStudent.DateOfBirth != null && updateStudent.DateOfBirth != "null")
    //             {
    //               student.DateOfBirth = DateTime.Parse(updateStudent.DateOfBirth);
    //             }

    //             if (student.DateOfBirth is not null)
    //                 student.Age = DateTime.UtcNow.CompareTo(student.DateOfBirth);
    //             else
    //                 student.Age = null;

    //             if (String.IsNullOrEmpty(student.Gender))
    //                 student.Gender = "";
    //             else
    //                 student.Gender = updateStudent.Gender;

    //             student.DateModified = DateTime.UtcNow;

    //             _dataContext.Students.Update(student);

    //             await _dataContext.SaveChangesAsync();

    //             serviceResponse.Data = _mapper.Map<GetStudentResponseDto>(student);

    //             serviceResponse.Message = "Updated";

    //             return serviceResponse;

    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Success = false;
    //             serviceResponse.Message = ex.Message;

    //             return serviceResponse;
    //         }

    //     }

    //     async Task<ServiceResponse<List<GetStudentResponseDto>>> IStudentService.DeleteStudent(int Id)
    //     {
    //         ServiceResponse<List<GetStudentResponseDto>> serviceResponse = new();

    //         try
    //         {
    //             Student? student = await _dataContext.Students.FirstOrDefaultAsync(s => s.StudentId == Id);

    //             if (student is null)
    //             {
    //                 throw new Exception("Student not found.");
    //             }

    //             _dataContext.Students.Remove(student);

    //             await _dataContext.SaveChangesAsync();

    //             serviceResponse.Data = _dataContext.Students.Select(s => _mapper.Map<GetStudentResponseDto>(s)).ToList();

    //             serviceResponse.Message = "Deleted";

    //             return serviceResponse;

    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Success = false;
    //             serviceResponse.Message = ex.Message;

    //             return serviceResponse;
    //         }

    //     }

    //     async Task<ServiceResponse<List<GetStudentResponseDto>>> IStudentService.GetAllStudents()
    //     {
    //         ServiceResponse<List<GetStudentResponseDto>> serviceResponse = new();

    //         List<Student> dbStudents = await _dataContext.Students.ToListAsync();

    //         serviceResponse.Data = dbStudents.Select(s => _mapper.Map<GetStudentResponseDto>(s)).ToList();

    //         return serviceResponse;
    //     }

    //     async Task<ServiceResponse<GetStudentResponseDto>> IStudentService.GetStudentByUserId(int userId)
    //     {
    //         ServiceResponse<GetStudentResponseDto> serviceResponse = new();

    //         try
    //         {
    //             Student? student = await _dataContext.Students.Where(s => s.UserId == userId).FirstOrDefaultAsync();

    //             if (student is not null)
    //             {

    //                 serviceResponse.Data = _mapper.Map<GetStudentResponseDto>(student);
    //                 return serviceResponse;

    //             }
    //             else
    //             {
    //                 throw new Exception("Student not found");
    //             }

    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Data = null;
    //             serviceResponse.Message = ex.Message;
    //             serviceResponse.Success = false;

    //             return serviceResponse;
    //         }

    //     }

    //     async Task<ServiceResponse<GetStudentResponseDto>> IStudentService.GetStudent(int id)
    //     {
    //         ServiceResponse<GetStudentResponseDto> serviceResponse = new();

    //         try
    //         {

    //             Student? student = await _dataContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);

    //             if (student is not null)
    //             {
    //                 serviceResponse.Data = _mapper.Map<GetStudentResponseDto>(student);
    //                 return serviceResponse;

    //             }

    //             throw new Exception("Student not found");
    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Message = ex.Message;
    //             serviceResponse.Success = false;

    //             return serviceResponse;
    //         }
    //     }

    //     async Task<ServiceResponse<GetStudentResponseDto>> IStudentService.UpdateSelectedCategory(int categoryId, int userId)
    //     {
    //         ServiceResponse<GetStudentResponseDto> serviceResponse = new();

    //         try
    //         {

    //             Student? student = await _dataContext.Students.FirstOrDefaultAsync(x => x.UserId == userId);

    //             if (student is not null)
    //             {

    //                 student.SubCategorySelected = categoryId.ToString();

    //                 _dataContext.Update(student);

    //                 await _dataContext.SaveChangesAsync();

    //                 serviceResponse.Data = _mapper.Map<GetStudentResponseDto>(student);

    //                 serviceResponse.Message = "Category updated.";

    //                 return serviceResponse;

    //             }

    //             throw new Exception("Student not found");
    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Message = ex.Message;
    //             serviceResponse.Success = false;

    //             return serviceResponse;



    //         }
    //     }

    //     async Task<ServiceResponse<GetStudentResponseDto>> IStudentService.UpdateEmailNewsletterPreference(bool isNewsletterPreference, int userId) {

    //         ServiceResponse<GetStudentResponseDto> serviceResponse = new();

    //         try
    //         {

    //             Student? student = await _dataContext.Students.FirstOrDefaultAsync(x => x.UserId == userId);

    //             if (student is not null)
    //             {

    //                 student.EmailNewsletterPreference = isNewsletterPreference;

    //                 _dataContext.Update(student);

    //                 await _dataContext.SaveChangesAsync();

    //                 serviceResponse.Data = _mapper.Map<GetStudentResponseDto>(student);

    //                 serviceResponse.Message = "Newsletter preference updated.";

    //                 return serviceResponse;

    //             }

    //             throw new Exception("Student not found");
    //         }
    //         catch (Exception ex)
    //         {
    //             serviceResponse.Message = ex.Message;
    //             serviceResponse.Success = false;

    //             return serviceResponse;

    //         }
    //     }

    }

}

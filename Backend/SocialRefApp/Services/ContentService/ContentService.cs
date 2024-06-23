using SocialRefApp.Data;
using SocialRefApp.Dtos.Article;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.ContentService
{
    public class ContentService : IContentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public ContentService(DataContext dataContext, IMapper mapper)
        {

            _mapper = mapper;
            _dataContext = dataContext;
        }

        // public async Task<ServiceResponse<ArticleGetResponseDto>> GetArticleById(int articleId)
        // {
        //     ServiceResponse<ArticleGetResponseDto> serviceResponse = new();
        //     try
        //     {

        //         Article? article = await _dataContext.Articles.Where(x => x.Id == articleId && x.IsActive == true).FirstOrDefaultAsync();

        //         if (article == null)
        //         {
        //             throw new Exception("No article found");
        //         }

        //         serviceResponse.Message = "Record found";

        //         serviceResponse.Data = _mapper.Map<ArticleGetResponseDto>(article);

        //         Student? createdBy = await _dataContext.Students.Where(x => x.UserId == article.CreatedBy).FirstOrDefaultAsync();

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

        // public async Task<ServiceResponse<List<ArticleGetResponseDto>>> GetArticlesListBySearch()
        // {
        //     ServiceResponse<List<ArticleGetResponseDto>> serviceResponse = new();

        //     try
        //     {

        //         List<ArticleGetResponseDto>? article = await _dataContext.Articles.Where(c => c.IsActive == true).Select(s => _mapper.Map<ArticleGetResponseDto>(s)).ToListAsync();

        //         serviceResponse.Data = article;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {

        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> AddArticle(ArticleAddRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {

        //         Article article = _mapper.Map<Article>(request);

        //         article.CreatedBy = 1;
        //         article.CreatedDate = DateTime.UtcNow;

        //         article.ModifiedBy = 1;
        //         article.ModifiedDate = DateTime.UtcNow;

        //         article.IsActive = true;

        //         await _dataContext.Articles.AddAsync(article);
        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Article saved";
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

        // public async Task<ServiceResponse<bool>> StatusChangeArticle(ArticleStatusRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         Article? article = await _dataContext.Articles.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (article is null)
        //         {
        //             throw new Exception("Unable to get current affair record");
        //         }

        //         article.IsActive = request.IsActive;

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Article record status changed.";
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

        // public async Task<ServiceResponse<bool>> UpdateArticle(ArticleUpdateRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         Article? article = await _dataContext.Articles.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (article is null)
        //         {
        //             throw new Exception("Unable to get article record");
        //         }

        //         Article updatedArticle = _mapper.Map<Article>(request);

        //         _dataContext.Articles.Update(updatedArticle);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current article updated.";
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

        // public async Task<ServiceResponse<List<Article>>> GetUserSavedArticlesBySearch(int userId)
        // {
        //     ServiceResponse<List<Article>> serviceResponse = new();
        //     try
        //     {
        //         List<Article>? articles = await _dataContext.Users.Where(x => x.UserId == userId).SelectMany(x => x.Articles).ToListAsync();

        //         serviceResponse.Message = "Articles fetched.";
        //         serviceResponse.Data = articles;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> AddArticleSavedByUser(int articleId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();

        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         Article? article = await _dataContext.Articles.Where(x => x.Id == articleId).FirstOrDefaultAsync();

        //         if (article == null)
        //         {
        //             throw new Exception("Unable to find article record");
        //         }

        //         article.Users = new List<User>(); // you could also do this in the constructor of Candidate

        //         article.Users.Add(user);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Article saved";
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

        // public async Task<ServiceResponse<bool>> RemoveArticleSavedByUser(int articleId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {


        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).Include(x => x.Articles).FirstOrDefaultAsync();

        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         Article? article = await _dataContext.Articles.Where(x => x.Id == articleId).FirstOrDefaultAsync();

        //         if (article == null)
        //         {
        //             throw new Exception("Unable to find article record");
        //         }

        //         user?.Articles?.Remove(article);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Article unsaved";
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


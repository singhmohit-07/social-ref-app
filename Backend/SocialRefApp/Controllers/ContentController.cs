using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.Article;
using SocialRefApp.Entities;
using SocialRefApp.Models;
using SocialRefApp.Services.ContentService;

namespace SocialRefApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService)
		{
            _contentService = contentService;
        }

        // [AllowAnonymous]
        // [HttpPost("GetArticlesBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<ArticleGetResponseDto>>>> GetArticlesBySearch()
        // {
        //     return Ok(await _contentService.GetArticlesListBySearch());
        // }

        // [AllowAnonymous]
        // [HttpGet("GetArticleById/{articleId}")]
        // public async Task<ActionResult<ServiceResponse<ArticleGetResponseDto>>> GetArticleById(int articleId)
        // {
        //     return Ok(await _contentService.GetArticleById(articleId));
        // }

        // [AllowAnonymous]
        // [HttpPost("AddArticle")]
        // public async Task<ActionResult<ServiceResponse<bool>>> AddArticle(ArticleAddRequestDto request)
        // {
        //     return Ok(await _contentService.AddArticle(request));
        // }

        // [AllowAnonymous]
        // [HttpPut("UpdateArticle")]
        // public async Task<ActionResult<ServiceResponse<bool>>> UpdateArticle(ArticleUpdateRequestDto request)
        // {
        //     return Ok(await _contentService.UpdateArticle(request));
        // }

        // [AllowAnonymous]
        // [HttpPost("ArticleChangeStatus")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ArticleChangeStatus(ArticleStatusRequestDto request)
        // {
        //     return Ok(await _contentService.StatusChangeArticle(request));
        // }

        // [HttpGet("GetUserSavedArticlesBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<Article>>>> GetUserSavedArticlesBySearch()
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _contentService.GetUserSavedArticlesBySearch(userId));
        // }

        // [HttpPost("PostAddArticleSavedByUser/{articleId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostAddArticleSavedByUser(int articleId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _contentService.AddArticleSavedByUser(articleId, userId));
        // }

        // [HttpPost("PostRemoveArticleSavedByUser/{articleId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostRemoveCurrentAffairsSavedByUser(int articleId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _contentService.RemoveArticleSavedByUser(articleId, userId));
        // }

    }
}


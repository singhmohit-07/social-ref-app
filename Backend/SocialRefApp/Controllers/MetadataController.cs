using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.Student;
using SocialRefApp.Entities;
using SocialRefApp.Models;
using SocialRefApp.Repository.Metadata;

namespace SocialRefApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
	{
		private readonly IMetadataRepository _metadataRepository;

		public MetadataController(IMetadataRepository metadataRepository)
		{
			_metadataRepository = metadataRepository;
		}

        // [HttpPost("PostGlobalCategories")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategories>>> PostGlobalCategories(GlobalCategories model)
        // {
        //     return Ok(await _metadataRepository.PostGlobalCategories(model));
        // }

        // [HttpGet("GetGlobalCategories")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategories>>> GetGlobalCategories()
        // {
        //     return Ok(await _metadataRepository.GetGlobalCategories());
        // }

        // [HttpPost("PostGlobalSubCategories")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategorySubCategories>>> PostGlobalSubCategories(GlobalCategorySubCategories model)
        // {
        //     return Ok(await _metadataRepository.PostGlobalSubCategories(model));
        // }

        // [HttpGet("GetGlobalSubCategoriesByCategoryId/{categoryId}")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategorySubCategories>>> GetGlobalSubCatrogoriesByCategoryId(int categoryId)
        // {
        //     return Ok(await _metadataRepository.GetGlobalSubCategoriesByCategoryId(categoryId));

        // }

        // [HttpPost("PostSubCategorySubSection")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategorySubCategories>>> PostSubCategorySubSection(SubCategorySubsection model)
        // {
        //     return Ok(await _metadataRepository.PostSubSectionBySubCategory(model));
        // }

        // [HttpGet("GetSubSectionBySubCategoryId/{subCategoryId}")]
        // public async Task<ActionResult<ServiceResponse<GlobalCategorySubCategories>>> GetSubSectionBySubCategoryId(int subCategoryId)
        // {
        //     return Ok(await _metadataRepository.GetSubSectionsBySubCategoryId(subCategoryId));
        // }

        // [HttpGet("GetSubSectionItemBySubSectionId/{subSectionId}")]
        // public async Task<ActionResult<ServiceResponse<SubSectionItem>>> GetSubSectionItemBySubSectionId(int subSectionId)
        // {
        //     return Ok(await _metadataRepository.GetSubSectionItemsBySubSectionId(subSectionId));
        // }
    }
}


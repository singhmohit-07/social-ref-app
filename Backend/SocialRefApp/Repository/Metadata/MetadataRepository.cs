using System;
using SocialRefApp.Data;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Repository.Metadata
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly DataContext _dataContext;

        public MetadataRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // public async Task<ServiceResponse<bool>> PostGlobalCategories(GlobalCategories globalCategories)
        // {

        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         if (string.IsNullOrEmpty(globalCategories.Name))
        //         {
        //             throw new Exception("Name is empty");
        //         }

        //         if (string.IsNullOrEmpty(globalCategories.Description))
        //         {
        //             throw new Exception("Description is empty");
        //         }

        //         if (string.IsNullOrEmpty(globalCategories.Icon))
        //         {
        //             throw new Exception("Icon is empty");
        //         }

        //         globalCategories.CreatedDate = DateTime.UtcNow;

        //         await _dataContext.GlobalCategories.AddAsync(globalCategories);

        //         return serviceResponse;

        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<List<GlobalCategories>>> GetGlobalCategories()
        // {
        //     ServiceResponse<List<GlobalCategories>> serviceResponse = new()
        //     {
        //         Data = await _dataContext.GlobalCategories.Where(element => element.IsActive == true).ToListAsync()
        //     };

        //     return serviceResponse;
        // }

        // public async Task<ServiceResponse<bool>> PostGlobalSubCategories(GlobalCategorySubCategories globalSubCategory)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         if (string.IsNullOrEmpty(globalSubCategory.Name))
        //         {
        //             throw new Exception("Name is empty");
        //         }

        //         if (globalSubCategory.CategoryId <= 0)
        //         {
        //             throw new Exception("Category Id is invalid");
        //         }

        //         globalSubCategory.CreatedDate = DateTime.UtcNow;

        //         await _dataContext.GlobalCategorySubCategories.AddAsync(globalSubCategory);

        //         return serviceResponse;

        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;

        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }

        // }

        // public async Task<ServiceResponse<List<GlobalCategorySubCategories>>> GetGlobalSubCategoriesByCategoryId(int categoryId)
        // {
        //     ServiceResponse<List<GlobalCategorySubCategories>> serviceResponse = new()
        //     {
        //         Data = await _dataContext.GlobalCategorySubCategories.Where(element => element.CategoryId == categoryId && element.IsActive == true).ToListAsync()
        //     };

        //     return serviceResponse;
        // }

        // public async Task<ServiceResponse<bool>> PostSubSectionBySubCategory(SubCategorySubsection subSection)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         if (string.IsNullOrEmpty(subSection.Name))
        //         {
        //             throw new Exception("Name is empty");
        //         }

        //         if (string.IsNullOrEmpty(subSection.SectionType))
        //         {
        //             throw new Exception("Section Type is empty");
        //         }

        //         if (subSection.SubCategoryId <= 0)
        //         {
        //             throw new Exception("SubCategory Id is invalid");
        //         }

        //         subSection.CreatedDate = DateTime.UtcNow;

        //         await _dataContext.SubCategorySubsections.AddAsync(subSection);

        //         return serviceResponse;

        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;

        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }

        // }

        // public async Task<ServiceResponse<List<SubCategorySubsection>>> GetSubSectionsBySubCategoryId(int subCategoryId)
        // {

        //     ServiceResponse<List<SubCategorySubsection>> serviceResponse = new()
        //     {
        //         Data = await _dataContext.SubCategorySubsections.Where(element => element.SubCategoryId == subCategoryId).ToListAsync()
        //     };

        //     return serviceResponse;
        // }

        // public async Task<ServiceResponse<List<SubSectionItem>>> GetSubSectionItemsBySubSectionId(int subSectionId)
        // {
        //     ServiceResponse<List<SubSectionItem>> serviceResponse = new()
        //     {
        //         Data = await _dataContext.SubSectionsSubSectionItems.Where(x => x.SubCategorySubSectionId == subSectionId).Select(x => x.SubSectionItem).OrderBy(z => z.PartNumber).OrderBy(a => a.SerialNumber).ToListAsync()
        //     };

        //     return serviceResponse;
        // }

    }
}


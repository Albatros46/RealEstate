using RealEstate.API.DTOs.CategoryDTOs;

namespace RealEstate.API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDTO categoryDTO);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDTO categoryDTO);
        
    }
}

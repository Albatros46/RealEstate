using Dapper;
using RealEstate.API.DTOs.CategoryDTOs;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDTO categoryDTO)
        {
            string query = "INSERT INTO Category (CategoryName, CategoryStatus) VALUES (@CategoryName, @CategoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", categoryDTO.CategoryName);
            parameters.Add("@CategoryStatus", true);

            using (var connection = _context.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE CategoryId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = _context.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            string query = "select * from Category";
            using (var connection = _context.createConnection()) {
                var values = await connection.QueryAsync<ResultCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async void UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            string query = "UPDATE Category SET CategoryName = @categoryName, CategoryStatus = @categoryStatus WHERE CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", categoryDTO.Id);
            parameters.Add("@categoryName", categoryDTO.CategoryName);
            parameters.Add("@categoryStatus", categoryDTO.CategoryStatus);

            using (var connection = _context.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

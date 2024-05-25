using PhongKhamOnline.Models;


namespace PhongKhamOnline.Repositories
{
    public interface IBacSiRepository
    {
        Task<IEnumerable<BacSi>> GetAllAsync();
        Task<IEnumerable<BacSi>> searchDoctor(string value);
        Task<BacSi> GetByIdAsync(int id);
        Task AddAsync(BacSi bacSi);
        Task UpdateAsync(BacSi bacSi);
        Task DeleteAsync(int id);
    }

}

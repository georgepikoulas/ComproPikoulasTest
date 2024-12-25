using ComproPikoulasTest.Core;

namespace ComproPikoulasTest.Business.Services
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        Task<Customer> CustomerExistsAsync(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<(IEnumerable<Customer>, PaginationMetadata)> GetCustomersPagedAsync(
    string? name, string? lastName, string? email, string? phone, int pageNumber, int pageSize);
        Task<bool> SaveChangesAsync();

        Task<Customer> CustomerGetById(int customerid);
    }
}
using ComproPikoulasTest.Core;
using ComproPikoulasTest.Data;
using Microsoft.EntityFrameworkCore;

namespace ComproPikoulasTest.Business.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ComproPikoulasTestDbContext dbContext;

        public CustomerRepository(ComproPikoulasTestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<(IEnumerable<Customer>, PaginationMetadata)> GetCustomersPagedAsync(
     string? name, string? lastName, string? email, string? phone, int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = dbContext.Customers as IQueryable<Customer>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                lastName = lastName.Trim();
                collection = collection.Where(c => c.LastName == lastName);
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
                collection = collection.Where(c => c.Email == email);
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                phone = phone.Trim();
                collection = collection.Where(c => c.Phone == phone);
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

           var collectionToReturn = await collection.OrderBy(c => c.Name).Include(p =>p.Orders)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }
        public async Task<Customer> CustomerGetById(int customerid)
        {
            var custfromDb = await dbContext.Customers.FirstOrDefaultAsync(c => c.ID == customerid);
            return custfromDb;
        }
        public async Task<Customer> CustomerExistsAsync(Customer customer)
        {
            var custfromDb = await dbContext.Customers.FirstOrDefaultAsync(c => c.Name == customer.Name && c.LastName == customer.LastName && c.Email == customer.Email && c.Phone == customer.Phone);
            return custfromDb == null ? customer : null;


        }
        public async Task AddCustomerAsync(Customer customer)
        {
            var customerToAdd = await CustomerExistsAsync(customer);
            if (customerToAdd == null)
            {
                //customerId.PointsOfInterest.Add(pointOfInterest);
                dbContext.Customers.Add(customer);
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await dbContext.SaveChangesAsync() >= 0);
        }
    }
}

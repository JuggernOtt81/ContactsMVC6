using ContactsMVC6;
using ContactsMVC6.Data;
using ContactsMVC6.Helpers;
using ContactsMVC6.Models;
using ContactsMVC6.Services;
using ContactsMVC6.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsMVC6.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly ApplicationDbContext _context;
        public AddressBookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddContactToCategoryAsync(int categoryId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetContactCategoriesAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<int>> GetContactCategoryIdsAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId)
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = await _context.Categories.Where(c => c.AppUserId == userId)
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
            return categories;
        }

        public Task<bool> IsContactInCategory(int categoryId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveContactFromCategoryAsync(int categoryId, int contactId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> SearchForContacts(string searchString, string userId)
        {
            throw new NotImplementedException();
        }
    }
}

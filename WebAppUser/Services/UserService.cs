using WebAppUser.Models.DataContext;
using WebAppUser.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppUser.Services
{
    public class UserService : IUserService
    {
        private readonly WebAppContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(WebAppContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                user.Password = _passwordHasher.GetHashPassword(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateUserAsync(User user)
        {
            if (!_context.Database.CanConnect())
            {
                throw new Exception("No se pudo conectar a la base de datos.");
            }

            try
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = _passwordHasher.GetHashPassword(user.Password);
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

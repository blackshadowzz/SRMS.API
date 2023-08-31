using Microsoft.EntityFrameworkCore;
using SRMS.API.Data.AppContext;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;
using System.Security.Cryptography;
using System.Text;

namespace SRMS.API.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
            context.Users.Remove(result);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IQueryable<User> results = context.Users;
            return await results.AsNoTracking().ToListAsync() ?? Enumerable.Empty<User>();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User?> GetOneUser(string username)
        {
            var result = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username.Equals(username));
            return result;
        }

        public async Task<ResponeService<int?>> RegisterAsync(User user, string Password)
        {
            try
            {
                if(await UserExist(user.Username))
                {
                    return new ResponeService<int?>()
                    {
                        Success=false,
                        Message="User already exists."
                    };
                }
                CreatePwdHash(Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return new ResponeService<int?>()
                {
                    Data=user.UserId
                    ,Success=true
                   
                };

            } catch (Exception ex)
            {
                throw;
            }
        }
        private void CreatePwdHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac= new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash= hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<ResponeService<string?>> UserLogin(string username, string password)
        {
            var respone=new ResponeService<string?>();
            var user= await context.Users.FirstOrDefaultAsync(x=>x.Username.ToLower() == username.ToLower());   
            if(user==null)
            {
                respone.Success = false;
                respone.Message = "User not found!";
            }
            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                respone.Success = false;
                respone.Message = "Wrong password!";
            }
            else
            {
                respone.Success = true;
                respone.Data = "User login";
                respone.Message = "Login successfully!";
            }
                
            return respone;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512(passwordSalt))
            {
                var computeHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);

            }
        }
    }
}

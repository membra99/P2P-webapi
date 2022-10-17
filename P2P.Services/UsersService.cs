using P2P.DTO.Output;
using P2P.DTO.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.P2P.MainData;
using P2P.Base.Services;
using Entities.Context;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace P2P.Services
{
    public interface IUsersService
    {
        UserODTO GetUser(UserIDTO userMode);
        Task<UserODTO> GetUserById(int id);
        Task<List<UserODTO>> GetUsersByLangId(int langId);
        Task<UserODTO> RegisterUser(UserIDTO userModel);
        Task<UserODTO> UpdateUser(UserIDTO userModel);
    }
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(MainContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public UserODTO GetUser(UserIDTO userModel)
        {
            var users = _context.Users.Where(x => x.Username == userModel.Username).FirstOrDefault();
            if (users != null)
            {
                string passwordHash = users.Password;
               bool valid = BCrypt.Net.BCrypt.Verify(userModel.Password,passwordHash);
                if (valid)
                    return _mapper.Map<UserODTO>(users);
                else
                    return null;
            }
            return null;
        }

        public Task<List<UserODTO>> GetUsersByLangId(int langId)
        {
            var users = _context.Users.Include(x => x.Language).Where(x => x.LanguageId == langId).Select(x => _mapper.Map<UserODTO>(x)).ToListAsync();
            if (users != null)
            {
                return users;
            }
            return null;
        }

        public async Task<UserODTO> RegisterUser(UserIDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await SaveContextChangesAsync();
            return await GetUserById(user.UserId);
        }
        public async Task<UserODTO> UpdateUser(UserIDTO userModel)
        {
            var users = _context.Users.Include(x => x.Language).Where(x => x.UserId == userModel.UserId).FirstOrDefault();
            if (users != null)
            {
                    users.Username = userModel.Username;
                users.LastName = userModel.LastName;
                users.FirstName = userModel.FirstName;
                users.RoleId = userModel.RoleId;
                users.LanguageId = userModel.LanguageId;
                    users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                await SaveContextChangesAsync();
                return await GetUserById(users.UserId);
            }
            return null;
        }
        public async Task<UserODTO> GetUserById(int id)
        {
            var users = _context.Users.Include(x => x.Language).Include(x => x.Role)
                .Where(x => x.UserId == id).Select(x => _mapper.Map<UserODTO>(x)).FirstOrDefaultAsync();

            return await users;
        }
    }
}

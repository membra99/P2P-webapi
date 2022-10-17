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
        List<UserODTO> GetUsersByLangId(int langId);
        UserODTO RegisterUser(UserIDTO userModel);
        UserODTO UpdateUser(UserIDTO userModel);
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

        public List<UserODTO> GetUsersByLangId(int langId)
        {
            var users = _context.Users.Where(x => x.LanguageId == langId).Select(x => _mapper.Map<UserODTO>(x)).ToList();
            if (users != null)
            {
                return users;
            }
            return null;
        }

        public UserODTO RegisterUser(UserIDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<UserODTO>(user);
        }
        public UserODTO UpdateUser(UserIDTO userModel)
        {
            var users = _context.Users.Where(x => x.UserId == userModel.UserId).FirstOrDefault();
            if (users != null)
            {
                    users.Username = userModel.Username;
                users.LastName = userModel.LastName;
                users.FirstName = userModel.FirstName;
                users.Role = userModel.Role;
                users.LanguageId = userModel.LanguageId;
                    users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                    _context.SaveChanges();
                    return _mapper.Map<UserODTO>(users);
            }
            return null;
        }
        public async Task<UserODTO> GetUserById(int id)
        {
            var users = await (from x in _context.Users
                         .Include(x => x.Language)
                               where (x.UserId == id)
                               select _mapper.Map<UserODTO>(x)).FirstOrDefaultAsync();

            return users;
        }
    }
}

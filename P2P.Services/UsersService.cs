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

namespace P2P.Services
{
    public interface IUsersService
    {
        UserODTO GetUser(UserIDTO userMode);
        UserODTO GetUserById(int id);
        UserODTO RegisterUser(UserIDTO userModel);
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
        public UserODTO RegisterUser(UserIDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<UserODTO>(user);
        }
        public UserODTO GetUserById(int id)
        {
            var users = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            return _mapper.Map<UserODTO>(users);
        }
    }
}

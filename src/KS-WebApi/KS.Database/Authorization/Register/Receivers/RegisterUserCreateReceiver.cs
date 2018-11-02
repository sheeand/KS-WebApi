using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Register;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Register.Receivers
{
    public class RegisterUserCreateReceiver : IAuthorizationRegisterReceiver
    {
        private readonly KSContext _context;
        private readonly IMapper _mapper;

        public RegisterUserCreateReceiver(KSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUser(UserRegisterRAO userRAO)
        {
            var userEntity = _mapper.Map<UserEntity>(userRAO);
            userEntity.OwnerId = Guid.NewGuid();

            var duplicateUser = _context.UserTableAccess.SingleOrDefault(x => x.Username == userEntity.Username);
            if(duplicateUser == null)
            {
                return await CreateUser(userEntity);
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> CreateUser(UserEntity userEntity)
        {
            await _context.UserTableAccess.AddAsync(userEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

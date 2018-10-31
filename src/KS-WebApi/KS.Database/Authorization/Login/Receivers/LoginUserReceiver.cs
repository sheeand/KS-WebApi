using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Receivers
{
    public class LoginUserReceiver : IAuthorizationLoginReceiver
    {
        private readonly KSContext _context;
        private readonly IMapper _mapper;

        public LoginUserReceiver(KSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> GetUserByUsername(UserLoginRAO userRAO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginUser(UserLoginRAO userRAO)
        {
            var userEntity = _mapper.Map<UserEntity>(userRAO);
            userEntity.OwnerId = Guid.NewGuid();

            return await CreateUser(userEntity);

        }

        private async Task<bool> CreateUser(UserEntity userEntity)
        {
            await _context.UserTableAccess.AddAsync(userEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

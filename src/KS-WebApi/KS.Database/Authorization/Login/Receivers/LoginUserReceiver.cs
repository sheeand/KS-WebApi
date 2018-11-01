using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using KS.Database.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ReceivedUserLoginRAO> LoginByUsername(GetUserRAO userRAO)
        {

            //TODO: 0.1 Capture entity, map to received RAO, return the received RAO

            var userEntity = await _context.UserTableAccess.FirstOrDefaultAsync(x => x.Username == userRAO.Username);
            return _mapper.Map<ReceivedUserLoginRAO>(userEntity);
        }
    }
}
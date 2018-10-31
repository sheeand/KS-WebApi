using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization.Register;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class RegisterUserManager : IRegisterUserManager
    {
        private readonly IUserRegisterInvoker _userRegisterInvoker;
        private readonly IMapper _mapper;

        public RegisterUserManager(IUserRegisterInvoker userRegisterInvoker, IMapper mapper)
        {
            // the thing you inject is the next thing down
            _userRegisterInvoker = userRegisterInvoker;
            _mapper = mapper;
        }

        public RegisterUserManager()
        {
        }

        public async Task<bool> RegisterUser(NewUserCreateDTO userDTO)
        {
            //NewUserCreateDTO
            var rao = PrepareUserRAOForRegister(userDTO);

            return await _userRegisterInvoker.InvokeRegisterUserCommand(rao);

            //-- Code to the abstraction (interface)
        }

        // helper method
        private UserRegisterRAO PrepareUserRAOForRegister(NewUserCreateDTO userDTO)
        {
            byte[] passwordHash, passwordSalt;

            //-- Create an instance of the engine
            var hashEngine = new CreatePasswordHashEngine();

            //-- Pass userDTO variable into CreatePasswordHash method to hash the password
            hashEngine.CreatePaswordHash(userDTO.Password, out passwordHash, out passwordSalt);

            //NewUserCreateDTO = var
            //var userRAO = MapuserDTOObjectToDTO(userDTO, passwordHash, passwordSalt);

            var rao = _mapper.Map<UserRegisterRAO>(userDTO);
            rao.PasswordHash = passwordHash;
            rao.PasswordSalt = passwordSalt;

            return rao;
        }

        //-- Prepare (map) the DTO object for the next layer
        //-- Instantiate the class for the Database
        //-- Call the Invoker method in the DAL

        // helper method
        //private NewUserCreateDTO MapuserDTOObjectToDTO(NewUserCreateRequest userDTO, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    // object init syntax
        //    var userDTO = new NewUserCreateDTO
        //    {
        //        Username = userDTO.UserName,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt
        //    };

        //    return userDTO;
        //}

    }
}

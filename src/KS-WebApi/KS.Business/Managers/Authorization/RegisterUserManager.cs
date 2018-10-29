using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class RegisterUserManager : IRegisterUserManager
    {
        public Task<NewUserCreateDTO> RegisterUser(NewUserCreateRequest userRequest)
        {
            NewUserCreateDTO dto = PrepareUserDTOForRegister(userRequest);

            throw new Exception();

            //-- Create an instance of the engine
            //-- Call CreatePasswordHash method
            //-- Pass userrequest variable into password hash method

            //-- Code to the abstraction (interface)
        }

        // helper method
        private NewUserCreateDTO PrepareUserDTOForRegister(NewUserCreateRequest userRequest)
        {
            byte[] passwordHash, passwordSalt;

            // go to the engine befroe you go to the database
            var hashEngine = new CreatePasswordHashEngine();
            hashEngine.CreatePaswordHash(userRequest.Password, out passwordHash, out passwordSalt);

            // Hash the password
            //NewUserCreateDTO = var
            var userDTO = MapUserRequestObjectToDTO(userRequest, passwordHash, passwordSalt);

            return userDTO;
        }

        //-- Prepare (map) the DTO object for the next layer
        //-- Instantiate the class for the Database
        //-- Call the Invoker method in the DAL

            // helper method
        private NewUserCreateDTO MapUserRequestObjectToDTO(NewUserCreateRequest userRequest, byte[] passwordHash, byte[] passwordSalt)
        {
            // object init syntax
            var userDTO = new NewUserCreateDTO
            {
                Username = userRequest.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            return userDTO;
        }

    }
}

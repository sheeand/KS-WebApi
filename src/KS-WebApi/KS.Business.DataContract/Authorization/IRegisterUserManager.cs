﻿using KS.API.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface IRegisterUserManager
    {
        // Corresponds to ISP

        Task<NewUserCreateDTO> RegisterUser(NewUserCreateRequest userRequest);

    }
}

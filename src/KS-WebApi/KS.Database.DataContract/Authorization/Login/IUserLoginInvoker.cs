﻿using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization.Login
{
    public interface IUserLoginInvoker
    {
        //TODO: 0.4 Fix this
        Task<ReceivedUserLoginRAO> InvokeLoginUserCommand(GetUserRAO userRAO);
    }
}

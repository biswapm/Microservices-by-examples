using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Services
{
    public interface IIdentityService
    {
        string GetUserIdentity();
    }
}

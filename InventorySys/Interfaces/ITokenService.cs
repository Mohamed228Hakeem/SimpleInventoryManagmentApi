using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Models;

namespace InventorySys.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
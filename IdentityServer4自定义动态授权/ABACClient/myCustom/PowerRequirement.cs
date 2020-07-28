using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABACClient.myCustom
{
    public class PowerRequirement:IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PowerRequirement(string permission) { Permission = permission; }
    }
}

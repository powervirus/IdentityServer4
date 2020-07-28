using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABACClient.myCustom
{
    public class PowerAuthorizeAttribute:AuthorizeAttribute
    {
        const string POLICY_PREFIX = "Power";
        public PowerAuthorizeAttribute(string permission) => Permission = permission;

        public string Permission
        {
            get
            {
                if (Policy.Length > POLICY_PREFIX.Length)
                {
                    return Policy;
                }
                return POLICY_PREFIX;
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value}";
            }
        }
    }
}

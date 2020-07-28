using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABACClient.myCustom
{
    public class PowerPolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "Power";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public PowerPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()//=> FallbackPolicyProvider.GetDefaultPolicyAsync();
        {
            var p = await FallbackPolicyProvider.GetDefaultPolicyAsync();
            return p;
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                policyName.Length>POLICY_PREFIX.Length)
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PowerRequirement(policyName.Substring(POLICY_PREFIX.Length)));
                return Task.FromResult(policy.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}

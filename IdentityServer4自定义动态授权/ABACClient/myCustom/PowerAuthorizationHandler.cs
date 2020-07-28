using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABACClient.myCustom
{
    public class PowerAuthorizationHandler : AuthorizationHandler<PowerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PowerRequirement requirement)
        {
            try
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
                var pendingRequirements = context.PendingRequirements.ToList();

                var roles = context.User.Claims.FirstOrDefault(c => c.Type == "Permission")?.Value;
                foreach (var item in roles.Split(';'))
                {
                    if (item == requirement.Permission)
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                }
                context.Fail();
                return Task.CompletedTask;
            }
            catch
            {
                context.Fail();
                return Task.CompletedTask;
            }
        }
    }
}

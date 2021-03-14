using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuestionAnswer.Security
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<QuestionAnswerUser>
    {
        public ClaimsPrincipalFactory(UserManager<QuestionAnswerUser> u, IOptions<IdentityOptions> o) :
            base(u, o) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(QuestionAnswerUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            return identity;
        }
    }
}

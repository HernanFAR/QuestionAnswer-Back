using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Interface
{
    public interface ILoginController
    {
        Task<ActionResult<UserCreated>> Register(RegisterData model);

        Task<ActionResult<TokenData>> Login(LoginSession model);

        Task<ActionResult<TokenData>> UpdateInformation(ChangeInformation model);

        Task<ActionResult> ConfirmEmail(string userId, string token);

        Task<ActionResult> ForgetPassword(string email);

        Task<ActionResult> ResetPassword(ResetPassword model);

        Task<ActionResult> SendConfirm(string email);
    }
}

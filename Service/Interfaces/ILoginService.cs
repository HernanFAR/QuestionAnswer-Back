using Repository.Models;
using Service.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILoginService
    {
        Task<UserCreated> RegisterUser(RegisterData model);

        Task<TokenData> LoginUser(LoginSession model);

        Task<QuestionAnswerUser> FindById(string id);

        Task<QuestionAnswerUser> FindByEmail(string email);

        Task SendConfirmEmail(string email);

        Task ConfirmEmail(ConfirmEmailData model);

        Task ForgetPassword(string email);

        Task ResetPassword(ResetPassword model);

        Task UpdateInformation(ChangeInformation model);

        Task DeleteUser(string id);

        Task AddPassword(PasswordData model);
    }
}

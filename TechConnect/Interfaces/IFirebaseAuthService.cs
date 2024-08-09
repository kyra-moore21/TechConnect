using FirebaseAdmin.Auth;
using System.Threading.Tasks;
namespace TechConnect.Interfaces
{
    public interface IFirebaseAuthService
    {
        Task<string> VerifyTokenAsync(string token);
        Task<UserRecord> GetUserByIdAsync(string uid);
        Task<UserRecord> UpdateUserAsync(UserRecordArgs args);
        Task<UserRecord> CreateUserAsync(UserRecordArgs user);
        Task DeleteUserAsync(string uid);
    }
}

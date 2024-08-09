using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using TechConnect.Interfaces;
namespace TechConnect.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseAuth _firebaseAuth;

        public FirebaseAuthService()
        {
            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }

        public async Task<string> VerifyTokenAsync(string token)
        {
            var decodedToken = await _firebaseAuth.VerifyIdTokenAsync(token);
            return decodedToken.Uid;
        }

        public async Task<UserRecord> GetUserByIdAsync(string uid)
        {
            return await _firebaseAuth.GetUserAsync(uid);
        }

        public async Task<UserRecord> UpdateUserAsync(UserRecordArgs args)
        {
            return await _firebaseAuth.UpdateUserAsync(args);
        }

        public async Task<UserRecord> CreateUserAsync(UserRecordArgs args)
        {
            return await _firebaseAuth.CreateUserAsync(args);
        }

        public async Task DeleteUserAsync(string uid)
        {
             await _firebaseAuth.DeleteUserAsync(uid);
        }
    }
}

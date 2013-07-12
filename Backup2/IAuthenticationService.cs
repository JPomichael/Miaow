using System.ServiceModel;

using iPow.Service.SSO.Entity;

namespace iPow.Service.SSO.WebService
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [OperationContract(Name = "Login")]
        LoginResponse ValidateUser(LoginRequest loginRequest);

        /// <summary>
        /// Validates the user is online.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns></returns>
        [OperationContract(Name = "IsOnline")]
        ValidateResponse ValidateUserIsOnline(ValidateRequest validateRequest);


        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        [OperationContract]
        TokenResponse GetToken(TokenRequest tokenRequest);

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        [OperationContract]
        TokenResponse ValidateToken(TokenRequest tokenRequest);

        /// <summary>
        /// Sings the out.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        [OperationContract]
        void SingOut(string userName);

        /// <summary>
        /// Gets the online users.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        OnlineUserCollection GetOnlineUsers();

        /// <summary>
        /// Gets the security token collection.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        SecurityTokenCollection GetSecurityTokenCollection();
    }
}

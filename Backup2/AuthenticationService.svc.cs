using System;
using System.Linq;
using System.Timers;

using System.ServiceModel;
using iPow.Service.SSO.Entity;

namespace iPow.Service.SSO.WebService
{
    // NOTE: If you change the class name "AuthenticationService" here, you must also update the reference to "AuthenticationService" in Web.config.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, MaxItemsInObjectGraph = Int32.MaxValue)]
    public class AuthenticationService : IAuthenticationService
    {
        object synchronizeObjectCall = new object();

        TimeSpan tokenTimeOut = new TimeSpan(0, 0, iPow.Service.SSO.WebService.TimeOutService.TokenTimeOutInSecond);

        TimeSpan loginTimeOut = new TimeSpan(0, 0, iPow.Service.SSO.WebService.TimeOutService.LoginTimeOutTimeInSecond);

        Timer serviceCleanUpTimer = new Timer(iPow.Service.SSO.WebService.TimeOutService.CleanUpTimeInSecond);

        public AuthenticationService()
        {
            var loginTimeOutInSeconds = 120;
            var tokenTimeOutInSeconds = 120;
            TimeSpan tokenTimeOut = new TimeSpan(0, 0, tokenTimeOutInSeconds);
            TimeSpan loginTimeOut = new TimeSpan(0, 0, loginTimeOutInSeconds);
            Timer serviceTimer = new Timer(100);
            serviceTimer.Elapsed += new ElapsedEventHandler(ServiceCleanUpTimerElapsed);
            serviceTimer.Start();
        }
        #region 项目用到的

        /// <summary>
        /// Validates the user is online.
        /// 项目用到的
        /// </summary>
        /// <param name="validateRequest">The login request.</param>
        /// <returns></returns>
        public ValidateResponse ValidateUserIsOnline(ValidateRequest validateRequest)
        {
            ValidateResponse loginResponse = new ValidateResponse();
            User user = validateRequest.User;
            try
            {
                lock (synchronizeObjectCall)
                {
                    // User is not yet logged in.
                    if (iPow.Service.SSO.WebService.OnLineUserService
                        .OnLineUserList.Where(e=> e.id == user.id && e.username == user.username).Any())
                    {
                        //存在
                        loginResponse.User = user;
                    }
                }
            }
            catch (Exception ex)
            {
                loginResponse.Fault = new SingleSignOnFault();
                loginResponse.Fault.Message = ex.Message;
            }
            return loginResponse;
        }

        /// <summary>
        /// Validates the token.
        /// 在securitylist里面找token.id对应的user
        /// 项目用到的
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public TokenResponse ValidateToken(TokenRequest tokenRequest)
        {
            TokenResponse tokenResponse = new TokenResponse();
            ValidateTokenBase(tokenRequest, tokenResponse);
            return tokenResponse;
        }

        #endregion

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public LoginResponse ValidateUser(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            User user = loginRequest.User;
            try
            {
                lock (synchronizeObjectCall)
                {
                    // User is not yet logged in.
                    if (!iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList.Contains(loginRequest.User.UserGuid))
                    {
                        iPow.Service.SSO.WebService.OnLineUserService
                            .OnLineUserList.Add(new OnlineUser()
                        {
                            Activity = user.Activity,
                            DepartmentID = user.DepartmentID,
                            Email = user.Email,
                            EmployeeID = user.EmployeeID,
                            id = user.id,
                            lastloginip = user.lastloginip,
                            lastlogintime = user.lastlogintime,
                            LoginDomain = user.LoginDomain,
                            LoginIpAddress = user.LoginIpAddress,
                            LoginTime = System.DateTime.Now,
                            logintimes = user.logintimes,
                            password = user.password,
                            Phone = user.Phone,
                            roleid = user.roleid,
                            sex = user.sex,
                            style = user.style,
                            truename = user.truename,
                            UserGuid = user.UserGuid,
                            userid = user.userid,
                            username = user.username,
                            UserType = user.UserType
                        });
                    }
                    else
                    {
                        iPow.Service.SSO.WebService.OnLineUserService
                            .OnLineUserList[loginRequest.User.UserGuid].LoginTime = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                loginResponse.Fault = new SingleSignOnFault();
                loginResponse.Fault.Message = ex.Message;
            }
            loginResponse.User = user;
            return loginResponse;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public TokenResponse GetToken(TokenRequest tokenRequest)
        {
            //token, 有个Id和User，
            TokenResponse response = new TokenResponse();
            GetTokenBase(tokenRequest, response);
            return response;
        }

        /// <summary>
        /// Sings the out.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public void SingOut(string userName)
        {
            lock (synchronizeObjectCall)
            {
                var currentOnLineUser = iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList
                    .Where(e => e.username == userName).FirstOrDefault();
                if (currentOnLineUser != null)
                {
                    DeleteUser(currentOnLineUser.username, currentOnLineUser.id);
                }
            }
        }

        /// <summary>
        /// Gets the online users.
        /// </summary>
        /// <returns></returns>
        public OnlineUserCollection GetOnlineUsers()
        {
            return iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList;
        }

        /// <summary>
        /// Gets the security token collection.
        /// </summary>
        /// <returns></returns>
        public SecurityTokenCollection GetSecurityTokenCollection()
        {
            return iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList;
        }

        #region private

        /// <summary>
        /// Gets the token base.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        /// <param name="response">The response.</param>
        private void GetTokenBase(TokenRequest tokenRequest, TokenResponse response)
        {
            response.Token = new Token();
            lock (synchronizeObjectCall)
            {
                //通过user是否登陆，去判断是否登陆了，如果登陆了才发放，token.id
                var userIsOnline = iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList
                    .Where(e => e.id == tokenRequest.User.id && e.username == tokenRequest.User.username)
                    .FirstOrDefault();

                if (userIsOnline != null)
                {
                    SecurityToken securityToken = new SecurityToken()
                    {
                        User = tokenRequest.User,
                        TokenId = response.Token.TokenId,
                        CreateTime = DateTime.Now
                    };
                    iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Add(securityToken);

                    //发放token.id
                  //  response.Token.TokenId = iPow.Service.SSO.WebService.TokenBuilderService.BuilderTokenId();
                }
            }
        }

        /// <summary>
        /// Validates the token base.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        /// <param name="tokenResponse">The token response.</param>
        private void ValidateTokenBase(TokenRequest tokenRequest, TokenResponse tokenResponse)
        {
            tokenResponse.User = new User();
            lock (synchronizeObjectCall)
            {
                //tokenRequest.Token , tokenRequest.User = null
                //所以只能用tokenRequest.Token.Id去验证
                if (iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Contains(tokenRequest.Token.TokenId))
                {
                    //存在这个token.id
                    SecurityToken securityToken = iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList[tokenRequest.Token.TokenId];
                    //一个请求token的过期时间
                    //如果大于了过期时间的话，也不会有用的
                    TimeSpan differenceTime = DateTime.Now - securityToken.CreateTime;
                    if (differenceTime <= tokenTimeOut)
                    {
                        tokenResponse.User = securityToken.User;
                    }
                    //token用一欠，就删除
                    iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Remove(securityToken);
                }
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the _serviceTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void ServiceCleanUpTimerElapsed(object sender, ElapsedEventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;

            //
            var logintimeOutQuery = from users in iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList
                                    where (currentDateTime - users.LoginTime) > loginTimeOut
                                    select users;
            foreach (var user in logintimeOutQuery.ToList())
            {
                DeleteUser(user.username, user.id);
            }

            // Delete Security Tokens
            var tokenTimeOutQuery = from tokens in iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList
                                    where (currentDateTime - tokens.CreateTime) > tokenTimeOut
                                    select tokens;
            foreach (SecurityToken token in tokenTimeOutQuery.ToList())
            {
                iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Remove(token);
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userName">The login id.</param>
        private void DeleteUser(string userName, int id)
        {
            var currentOnlineUser = iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList
                .Where(e => e.username == userName && e.id == id).FirstOrDefault();
            if (currentOnlineUser != null)
            {
                var user = currentOnlineUser as User;
                // Remove Security Tokens first
                DeleteSecurityTokensForUser(user);

                // Remove the User now
                iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList.Remove(currentOnlineUser);
            }
        }

        /// <summary>
        /// Deletes the security tokens for user.
        /// </summary>
        /// <param name="userGuid">Name of the user.</param>
        private void DeleteSecurityTokensForUser(User user)
        {
            // Delete Security Tokens
            var tokenDeleteQuery = iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList
                .Where(e => e.User.id == user.id && e.User.username == user.username);

            foreach (SecurityToken token in tokenDeleteQuery.ToList())
            {
                iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Remove(token);
            }
        }
        #endregion

    }
}

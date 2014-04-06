using Common.Utilities;
using LoginServer.Config;
using LoginServer.Database;
using LoginServer.Model.Account;
using System.Linq;

namespace LoginServer.Service
{
    public enum AuthResponse
    {
        Success,
        WrongInfo,
        Banned,
        NoAtKey,
    }

    public class AuthService
    {
        private static AuthService Instance;

        public static AuthService GetInstance()
        {
            return (Instance != null) ? Instance : Instance = new AuthService();
        }

        public AuthResponse AuthAccount(string login, string password, ref Account account)
        {
            AuthResponse result;

            account = MdbAccount.GetInstance().GetAccountByName(login);

            if (account != null)
            {
                if (account.Password == password)
                    result = AuthResponse.Success;
                else
                    result = AuthResponse.WrongInfo;
            }
            else
            {
                if (Configuration.Setting.AutoAccount)
                {
                    account = new Account()
                    {
                        Name = login,
                        Password = password,
                        Password2 = null,
                        LastAddress = "0.0.0.0",
                    };
                    MdbAccount.GetInstance().AddAccount(account);
                    result = AuthResponse.Success;
                }
                else
                    result = AuthResponse.WrongInfo;
            }

            return result;
        }

        public AuthResponse AuthPassword2(string login, string password2, ref Account account)
        {
            AuthResponse result;

            result = AuthResponse.WrongInfo;

            account = MdbAccount.GetInstance().GetAccountByName(login);

            if (account != null)
            {
                if (account.Password2 == null)
                {
                    account.Name = login;
                    account.Password2 = password2;
                    MdbAccount.GetInstance().UpdateAccount(account);
                    result = AuthResponse.Success;
                }
                else
                {
                    if (account.Password2 == password2)
                        result = AuthResponse.Success;
                    else
                        result = AuthResponse.WrongInfo;
                }
            }
            return result;
        }

        public void UpdateChannelCurrentUserCount(int srvId, int chnId, int count)
        {
            var channel = LoginServer.ServerList[srvId].Channels[chnId];
            channel.CurrentUser = count;
            LoginServer.ServerList[srvId].Channels[chnId] = channel;
        }
    }
}

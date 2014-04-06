using LoginServer.Network.Send;
using LoginServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Network.Recv
{
    public class R8048Password2 : ARecvPacket
    {
        protected string Password2;
        protected internal override void Read()
        {
            Password2 = ReadS();

        }

        protected internal override void Run()
        {
            var resp = AuthService.GetInstance().AuthPassword2(_Client._Account.Name, Password2, ref _Client._Account);
            _Client.SendPacket(new W8049Password2(resp));
        }
    }
}

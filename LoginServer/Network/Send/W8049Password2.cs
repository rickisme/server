using LoginServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Network.Send
{
    public class W8049Password2 : ASendPacket
    {
        protected AuthResponse Response;

        public W8049Password2(AuthResponse resp)
        {
            Response = resp;
        }

        protected internal override void Write()
        {
            switch (Response)
            {
                case AuthResponse.Success:
                    WriteH(1);
                    break;
                case AuthResponse.WrongInfo:
                    WriteH(0xFFFF);
                    break;
            }
        }
    }
}

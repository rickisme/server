using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginServer.Network.Send;

namespace LoginServer.Network.Recv
{
    public class R804CPassword2 : ARecvPacket
    {

        protected internal override void Read()
        {
            // nothing to read ...
        }

        protected internal override void Run()
        {
            _Client.SendPacket(new W804DPassword2());
        }
    }
}

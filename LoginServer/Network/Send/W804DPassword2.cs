using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Network.Send
{
    public class W804DPassword2 : ASendPacket
    {
        protected internal override void Write()
        {
            WriteH(1);
        }
    }
}

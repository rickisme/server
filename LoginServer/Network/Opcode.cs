using LoginServer.Network.Recv;
using LoginServer.Network.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Network
{
    public class Opcode
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static void Init()
        {
            Recv.Add(unchecked((short)0x8000), typeof(RequestLogin));
            Recv.Add(unchecked((short)0x8016), typeof(RequestServerList));
            Recv.Add(unchecked((short)0x800C), typeof(RequestSelectServer));
            Recv.Add(unchecked((short)0x804C), typeof(R804CPassword2));
            Recv.Add(unchecked((short)0x8048), typeof(R8048Password2));

            Send.Add(typeof(ResponseLogin), unchecked((short)0x8001));
            Send.Add(typeof(ResponseServerList), unchecked((short)0x8017));
            Send.Add(typeof(ResponseSelectServer), unchecked((short)0x8064));
            Send.Add(typeof(W804DPassword2), unchecked((short)0x804D));
            Send.Add(typeof(W8049Password2), unchecked((short)0x8049));
        }
    }
}

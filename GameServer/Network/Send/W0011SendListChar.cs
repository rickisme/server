using GameServer.Model.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Network.Send
{
    public class W0011SendListChar : ASendPacket
    {
        protected int result;
        protected Character charinfo;

        public W0011SendListChar Empty()
        {
            result = 0;
            return this;
        }
        public W0011SendListChar InfoChar(Character c)
        {
            charinfo = c;
            return this;
        }

        protected internal override void Write()
        {
            switch (result)
            {
                case 0:
                    WriteC(0xFF);
                    break;
                case 1:
                    break;
            }
        }

    }
}

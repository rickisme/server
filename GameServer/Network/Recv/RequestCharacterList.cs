using GameServer.Database;
using GameServer.Model.Character;
using GameServer.Network.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Network.Recv
{
    public class RequestCharacterList : ARecvPacket
    {
        protected internal override void Read()
        {
            IDictionary<int, Character> listChar = MdbCharacter.GetInstance().GetListChar(_Client._Account.Name);

            if (listChar.Count == 0)
            {
                _Client.SendPacket(new W0011SendListChar().Empty());
            }
            else
            {
                foreach (Character c in listChar.Values)
                {
                    //
                    _Client.SendPacket(new W0011SendListChar().InfoChar(c));
                }

            }
        }

        protected internal override void Run()
        {
            
        }
    }
}

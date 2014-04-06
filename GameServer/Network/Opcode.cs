﻿using GameServer.Network.Recv;
using GameServer.Network.Send;
using System;
using System.Collections.Generic;

namespace GameServer.Network
{
    public class Opcode
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static void Init()
        {
            Recv.Add(unchecked((short)0x0001), typeof(RequestAuth));
            Recv.Add(unchecked((short)0x0010), typeof(RequestCharacterList));
            

            Send.Add(typeof(ResponseAuth), unchecked((short)0x0002));
            Send.Add(typeof(W0011SendListChar), unchecked((short)0x0011));
        }
    }
}

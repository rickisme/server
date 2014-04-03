﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Config
{
    public struct SettingStruct
    {
        public int ServerId;
        public string ServerName;

        public bool Debug;

        public int RateExp;
        public int RateMoney;
        public int RateSp;

        public SettingStruct(int svId, string svName, bool debug, int exp, int money, int sp)
        {
            ServerId = svId;
            ServerName = svName;
            Debug = debug;
            RateExp = exp;
            RateMoney = money;
            RateSp = sp;
        }
    }
}

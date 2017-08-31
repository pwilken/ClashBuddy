﻿using Buddy.Clash.DefaultSelectors.Game;
using Buddy.Clash.DefaultSelectors.Logic;
using Buddy.Common;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buddy.Clash.DefaultSelectors.Player
{

    public enum FightStyle
    {
        Defensive,
        Balanced,
        Rusher
    }

    class PlayerProperties
    {
        private static readonly ILogger Logger = LogProvider.CreateLogger<CastDeploymentHandling>();

        public static Position PlayerPosition
        {
            get
            {
                return PlaygroundPositionHandling.IsPositionUpOrDown(PlayerCharacterHandling.KingTower.StartPosition);
            }
        }

        public static uint MinManaToStartFirstStrike {get;set;}
    }
}

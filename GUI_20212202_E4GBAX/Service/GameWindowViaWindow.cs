﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Service
{
    public class GameWindowViaWindow : IGameWindowService
    {
        public void StartGame()
        {
            new GameWindow().ShowDialog();
        }
    }
}

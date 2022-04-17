﻿using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public interface IGameWindowLogic
    {
        void StartGame(string name);
        void LoadGame(SavedGame savedGame);
    }
}

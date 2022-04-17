using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Service
{
    public interface IGameWindowService
    {
        void StartGame(string name);
        void LoadGame(SavedGame savedGame);
    }
}

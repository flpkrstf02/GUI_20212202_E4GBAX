using GUI_20212202_E4GBAX.Models;
using GUI_20212202_E4GBAX.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public class GameWindowLogic:IGameWindowLogic
    {
        IGameWindowService service;
        public GameWindowLogic(IGameWindowService service)
        {
            this.service = service;
        }
        public void StartGame()
        {
            service.StartGame();
        }
        public void LoadGame(SavedGame savedGame)
        {
            service.LoadGame(savedGame);
        }
    }
}

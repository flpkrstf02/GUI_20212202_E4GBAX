using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Service
{
    public class GameWindowViaWindow : IGameWindowService
    {
        public void StartGame(string name)
        {
            new GameWindow(new SavedGame()
            {
                Name=name,
                Hp=100,
                Level=0
            }).ShowDialog();
        }
        public void LoadGame(SavedGame savedGame)
        {
            new GameWindow(savedGame).ShowDialog();
        }
    }
}

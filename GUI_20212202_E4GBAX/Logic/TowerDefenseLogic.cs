using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public class TowerDefenseLogic
    {
        public TowerItem[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public enum TowerItem
        {
            player, wall, floor, door
        }

        public TowerDefenseLogic()
        {
            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.lvl");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);
            }
            LoadNext(levels.Dequeue());
        }
        private void LoadNext(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new TowerItem[int.Parse(lines[1]), int.Parse(lines[0])];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i + 2][j]);
                }
            }
        }

        private TowerItem ConvertToEnum(char v)
        {
            switch (v)
            {
                case 'e': return TowerItem.wall;
                case 'S': return TowerItem.player;
                case 'F': return TowerItem.door;
                default:
                    return TowerItem.floor;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public class TowerDefenseLogic : IGameModel
    {
        public TowerItem[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public enum TowerItem
        {
            available, wall, path, position
        }

        public TowerDefenseLogic()
        {
            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.txt");
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

        private static TowerItem ConvertToEnum(char v)
        {
            switch (v)
            {
                case 'w': return TowerItem.wall;
                case 'o': return TowerItem.available;
                case 'p': return TowerItem.path;
                default:
                    return TowerItem.position;
            }
        }
        public void TowerPosition(Size size,Point p)
        {
            double x = p.X;
            double y = p.Y;
            double gridHeight = size.Height;
            double gridWidth = size.Width;
            double rectHeight = size.Height / GameMatrix.GetLength(0);
            double rectWidth = size.Width / GameMatrix.GetLength(1);

            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (y>=i*rectHeight && y<(i+1)*rectHeight && x >= j * rectWidth && x < (j + 1) * rectWidth)
                    {
                        if (GameMatrix[i,j]==TowerItem.available)
                        {
                            GameMatrix[i, j] = TowerItem.position;
                        }
                    }
                }
            }
        }
    }
}

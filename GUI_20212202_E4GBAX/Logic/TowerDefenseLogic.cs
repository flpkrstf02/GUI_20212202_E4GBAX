﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_20212202_E4GBAX.Models;

namespace GUI_20212202_E4GBAX.Logic
{
    public class TowerDefenseLogic : IGameModel
    {
        IEnemyLogic elogic = new EnemyLogic();
        public event EventHandler Changed;
        public Player User { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Tower> Towers { get; set; }
        public TowerItem[,] GameMatrix { get; set; }
        double eHelperH;
        double eHelperW;
        Size sizeH;
        
        private Queue<string> levels;
        int[] startCenter;
        
        public enum TowerItem
        {
            available, wall, path, position, start, crossroad, goal
        }
        SavedGame savedGame;
        public TowerDefenseLogic(SavedGame savedGame)
        {
            User = new Player();
            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.txt");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);
            }
            LoadNext(levels.Dequeue());
            this.savedGame = savedGame;
            Enemies = new List<Enemy>();
            Towers=new List<Tower>();
            User.Gold = savedGame.Gold;
            User.HP = savedGame.Hp;
            if (savedGame.Enemies!=null)
            {
                foreach (var item in savedGame.Enemies)
                {
                    Enemies.Add(item);
                }
            }
            if (savedGame.Towers!=null)
            {
                foreach (var item in savedGame.Towers)
                {
                    Towers.Add(item);
                }
            }
            
        }

        private void LoadNext(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new TowerItem[int.Parse(lines[1]), int.Parse(lines[0])];
            startCenter = new int[2];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i + 2][j]);
                    if (GameMatrix[i,j]==TowerItem.start)
                    {
                        startCenter[0] = i;
                        startCenter[1] = j;
                    }
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
                case 's': return TowerItem.start;
                case 'x': return TowerItem.crossroad;
                case 'g': return TowerItem.goal;
                default:
                    return TowerItem.position;
            }
        }
        public void TowerPosition(Size size, Point p)
        {
            double x = p.X;
            double y = p.Y;
            double rectHeight = size.Height / GameMatrix.GetLength(0);
            double rectWidth = size.Width / GameMatrix.GetLength(1);
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (y >= i * rectHeight && y < (i + 1) * rectHeight && x >= j * rectWidth && x < (j + 1) * rectWidth)
                    {
                        if (GameMatrix[i, j] == TowerItem.available)
                        {
                            GameMatrix[i, j] = TowerItem.position;
                        }
                    }
                }
            }
        }
        public void EnemySpawner(Size size)
        {
            double rectHeight = size.Height / GameMatrix.GetLength(0);
            double rectWidth = size.Width / GameMatrix.GetLength(1);
            double x = startCenter[1] * rectWidth+(rectWidth/2);
            double y = startCenter[0] * rectHeight+(rectHeight/2);
            this.eHelperH = rectHeight;
            this.eHelperW = rectWidth;
            Enemies.Add(new Enemy(new Point(x,y), new Vector(0, 0)));
        }
        public void TimeStep(Size size)
        {
            sizeH = size;
            elogic = new EnemyLogic(GameMatrix, Enemies, User,eHelperH,eHelperW, sizeH);
            
            foreach (var item in Enemies.ToList())
            {
                elogic.EnemyMove(item);
            }
        }
        public SavedGame Save()
        {
            return new SavedGame()
            {
                Name=savedGame.Name,
                Hp=User.HP,
                Gold=User.Gold,
                Level=savedGame.Level,
                Enemies=Enemies,
                Towers=Towers
            };
        }
    }
}

using System;
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
        ITowerLogic tLogic = new TowerLogic(); 
        public event EventHandler Changed;
        public Player User { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Tower> Towers { get; set; }
        public TowerItem[,] GameMatrix { get; set; }
        double eHelperH;
        double eHelperW;
        double rectHeight;
        double rectWidth;
        Size sizeH;
        int Enumbers = 0;
        int MaxEnemies = 10;
        private string[] levels;
        int[] startCenter;
        int currentLevel = 0;
        public int HP
        {
            get
            {
                return User.HP;
            }
        }
        public int Gold
        {
            get
            {
                return User.Gold;
            }
        }

        public enum TowerItem
        {
            available, wall, path, position, start, crossroad, goal,lvl1tower,lvl2tower,lvl3tower
        }
        SavedGame savedGame;
        public TowerDefenseLogic(SavedGame savedGame, Size size)
        {
            this.sizeH = size;
            
            User = new Player();
            levels = new string[5];
            int i = 0;
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.txt");
            foreach (var item in lvls)
            {
                levels[i] = item;
                i++;
            }
            LoadNext(levels[currentLevel]);
            currentLevel++;
            this.rectHeight = size.Height / GameMatrix.GetLength(0);
            this.rectWidth = size.Width / GameMatrix.GetLength(1);
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
                case '1': return TowerItem.lvl1tower;
                case '2': return TowerItem.lvl2tower;
                default:
                    return TowerItem.lvl3tower;
            }
        }
        public void TowerPosition(Size size, Point p, int towerlvl)
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
                            switch (towerlvl)
                            {
                                case 1:
                                    GameMatrix[i, j] = TowerItem.lvl1tower;
                                    Towers.Add(tLogic.Tower1Maker(p));
                                    break;
                                case 2:
                                    GameMatrix[i, j] = TowerItem.lvl2tower;
                                    Towers.Add(tLogic.Tower2Maker(p));
                                    break;
                                case 3:
                                    GameMatrix[i, j] = TowerItem.lvl3tower;
                                    Towers.Add(tLogic.Tower12Maker(p));
                                    break;
                            }
                        }
                    }
                }
            }
        }
        //public void EnemySpawner(Size size)
        //{
        //    double rectHeight = size.Height / GameMatrix.GetLength(0);
        //    double rectWidth = size.Width / GameMatrix.GetLength(1);
        //    double x = startCenter[1] * rectWidth+(rectWidth/2);
        //    double y = startCenter[0] * rectHeight+(rectHeight/2);
        //    this.eHelperH = rectHeight;
        //    this.eHelperW = rectWidth;
        //    Enemies.Add(new Enemy(new Point(x,y), new Vector(0, 0)));
        //}
        public void TimeStep(Size size)
        {
            sizeH = size;
            elogic = new EnemyLogic(GameMatrix, Enemies, User,eHelperH,eHelperW, sizeH);
            this.rectWidth = size.Width;
            this.rectHeight = size.Height;
            foreach (var item in Enemies.ToList())
            {
                elogic.EnemyMove(item);
            }
            
        }
        public void EnemySpawner(Size size)
        {
            Enemy e = new Enemy();
            double rectHeight = size.Height / GameMatrix.GetLength(0);
            double rectWidth = size.Width / GameMatrix.GetLength(1);
            double x = startCenter[1] * rectWidth+(rectWidth/2);
            double y = startCenter[0] * rectHeight+(rectHeight/2);
            Enumbers++;
            if(Enumbers <= MaxEnemies)
            {
                if(Enumbers%10 == 0)
                {
                    e=elogic.BossEnemyMaker(x,y);
                    
                }
                else if(Enumbers % 5 == 0)
                {
                    Enemies.Add(elogic.StrongEnemyMaker(x,y));
                }
                else
                {
                    Enemies.Add(elogic.AvgEnemyMaker(x,y));
                }
            }
        }

        public bool GameOver()
        {
            if (User.HP <= 0) { return true; }
            else return false;
        }
        private void towerAttack(Tower t, Enemy e)
        {
            int tX = (int)(t.Center.X/ (rectWidth+(rectWidth/2)));
            int tY = (int)(t.Center.Y / (rectHeight + (rectHeight / 2)));
            int eX = (int)(e.Center.X / (rectWidth + (rectWidth / 2)));
            int eY = (int)(e.Center.Y / (rectHeight + (rectHeight / 2)));
            if(Math.Abs(tX - eX) < t.range && Math.Abs(tY - eY) < t.range)
            {
                e.Health -= t.damage;
                if(e.Health <= 0)
                {
                    elogic.EnemyDeath(e);
                }
            }
        }

        public void TowerAttack()
        {
            int closest = 100000;
            int tX;
            int tY;
            int eX;
            int eY;
            int closestIdx = 0;
            int idx = 0;
            foreach (var item in Towers)
            {
                tX = (int)(item.Center.X / (rectWidth + (rectWidth / 2)));
                tY = (int)(item.Center.Y / (rectHeight + (rectHeight / 2)));

                foreach (var item2 in Enemies)
                {
                    eX = (int)(item2.Center.X / (rectWidth + (rectWidth / 2)));
                    eY = (int)(item2.Center.Y / (rectHeight + (rectHeight / 2)));
                    if ((int)(Math.Sqrt(Math.Pow(eX - tX, 2) + Math.Pow(eY - tY, 2))) < closest)
                    {
                        closest = (int)(Math.Sqrt(Math.Pow(eX - tX, 2) + Math.Pow(eY - tY, 2)));
                        closestIdx = idx;
                    }
                    idx++;
                }
                if(Enemies.Count > 0)
                towerAttack(item,Enemies[closestIdx]);
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

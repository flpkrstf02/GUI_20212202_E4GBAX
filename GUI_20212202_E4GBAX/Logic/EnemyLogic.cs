using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using static GUI_20212202_E4GBAX.Logic.TowerDefenseLogic;

namespace GUI_20212202_E4GBAX.Logic
{
    public class EnemyLogic : IEnemyLogic
    {
        private TowerItem[,] matrix;
        private List<Enemy> enemies;
        private Vector tmpVect;
        private Player user;
        private double rectHeight;
        private double rectWidth;
        private int matrixHelperX;
        private int matrixHelperY;
        private Size size;
        //private int[,] movementH = new int[7,7];
        public EnemyLogic()
        {

        }
        public EnemyLogic(TowerItem[,] Matrix, List<Enemy> Enemies, Player Player, double height, double width, Size size)
        {
            this.matrix = Matrix;
            this.user = Player;
            this.enemies = Enemies;
            this.rectHeight = height;
            this.rectWidth = width;
            this.size = size;
            //this.movementH = new int[matrix.GetLongLength(0),matrix.GetLongLength(1)];
        }
        public Enemy AvgEnemyMaker(double x, double y, int goal)
        {
            Enemy e = new Enemy();
            tmpVect = e.Speed;
            tmpVect.X = 0;
            tmpVect.Y = 0;
            e.Speed = tmpVect;
            e.Health = 10;
            e.Damage = 10;
            e.Value = 10;
            e.Center = new Point(x, y);
            e.MS = 10;
            e.EndGoal = goal;
            e.usedP = new int[7, 7];
            return e;
        }
        public Enemy StrongEnemyMaker(double x, double y,int goal)
        {
            Enemy e = new Enemy();
            tmpVect = e.Speed;
            tmpVect.X = 0;
            tmpVect.Y = 0;
            e.Speed = tmpVect;
            e.Health = 25;
            e.Damage = 25;
            e.Value = 25;
            e.Center = new Point(x, y);
            e.MS = 5;
            e.EndGoal = goal;
            e.usedP = new int[7, 7];
            return e;
        }

        public Enemy BossEnemyMaker(double x, double y, int goal)
        {
            Enemy e = new Enemy();
            tmpVect = e.Speed;
            tmpVect.X = 0;
            tmpVect.Y = 0;
            e.Speed = tmpVect;
            e.Health = 100;
            e.Damage = 50;
            e.Value = 125;
            e.Center = new Point(x, y);
            e.MS = 10;
            e.EndGoal = goal;
            e.usedP = new int[7, 7];
            return e;
        }
        // Point centerHelper;
        public void EnemyMove(Enemy e, int[,] movementH)
        {
            //width = size.Width / matrix.GetLength(1);
            //height = size.Height / matrix.GetLength(0);
            matrixHelperY = (int)((e.Center.X / (rectWidth)));// + (rectWidth / 2))); //+ 1.05);
            matrixHelperX = (int)((e.Center.Y / (rectHeight))); // + (rectHeight / 2))); //+ 0.6);
            if (matrix[matrixHelperX, matrixHelperY + 1] == TowerItem.path
                    //&& (matrix[matrixHelperX, matrixHelperY-1] != TowerItem.path)
                    //&& (matrix[matrixHelperX+1, matrixHelperY] != TowerItem.path)
                    //&& (matrix[matrixHelperX-1, matrixHelperY] != TowerItem.path))
                    && e.Speed.X != e.MS
                    && e.Speed.X != -e.MS
                    && e.usedP[matrixHelperX, matrixHelperY+1] == 0
                    )//jobbra
            {
                e.prevMov = 1;
                tmpVect = e.Speed;
                tmpVect.X = e.MS;
                tmpVect.Y = 0;
                e.Speed = tmpVect;
            }
            else if (matrixHelperY - 1 >= 0 && (matrix[matrixHelperX, matrixHelperY - 1] == TowerItem.path)
                    //&& (matrix[matrixHelperX, matrixHelperY+1] != TowerItem.path)
                    //&& (matrix[matrixHelperX+1, matrixHelperY] != TowerItem.path)
                    //&& (matrix[matrixHelperX-1, matrixHelperY] != TowerItem.path)
                    && e.Speed.X != e.MS
                    && e.Speed.X != -e.MS
                    && e.usedP[matrixHelperX, matrixHelperY-1] == 0
                    )//balra
            {
                e.prevMov = 2;
                tmpVect = e.Speed;
                tmpVect.X = -e.MS;

                tmpVect.Y = 0;
                e.Speed = tmpVect;
            }
            else if ((matrix[matrixHelperX + 1, matrixHelperY] == TowerItem.path)
                    //&& (matrix[matrixHelperX - 1, matrixHelperY] != TowerItem.path)
                    //&& (matrix[matrixHelperX, matrixHelperY+1] != TowerItem.path)
                    //&& (matrix[matrixHelperX, matrixHelperY-1] != TowerItem.path)
                    && e.Speed.Y != e.MS
                    && e.Speed.Y != -e.MS
                    && e.usedP[matrixHelperX + 1, matrixHelperY] == 0
                    ) //lefelé
                
            {
                e.prevMov = 3;
                tmpVect = e.Speed;
                tmpVect.X = 0;
                tmpVect.Y = e.MS;
                e.Speed = tmpVect;
            }
            else if ((matrixHelperX - 1) >= 0 && (matrix[matrixHelperX - 1, matrixHelperY] == TowerItem.path)
                    //&& (matrix[matrixHelperX + 1, matrixHelperY] != TowerItem.path)
                    //&& (matrix[matrixHelperX, matrixHelperY + 1] != TowerItem.path)
                    //&& (matrix[matrixHelperX, matrixHelperY - 1] != TowerItem.path))
                    && e.Speed.Y != e.MS
                    &&e.Speed.Y != -e.MS
                    && e.usedP[matrixHelperX-1,matrixHelperY] == 0) //felfelé
            {
                e.prevMov = 4;
                tmpVect = e.Speed;
                tmpVect.X = 0;
                tmpVect.Y = -e.MS;
                e.Speed = tmpVect;
            }

            Point centerHelper = new Point(e.Center.X + e.Speed.X, e.Center.Y + e.Speed.Y);
            e.Center = centerHelper;
            int enemyCenterMatrixX = (int)((e.Center.X / (rectWidth)));// + (rectWidth / 2)));// + 1.05);
            int enemyCenterMatrixY = (int)((e.Center.Y / (rectHeight)));// + (rectHeight / 2));// + 0.6);
            if(e.usedP[enemyCenterMatrixY,enemyCenterMatrixX] == 0)
            {
                e.usedP[enemyCenterMatrixY, enemyCenterMatrixX] = 1;
                
            }
            if (matrix[enemyCenterMatrixY, enemyCenterMatrixX] == TowerItem.goal)
            {
                EnemyGoalReached(e);
            }
            else if(matrix[enemyCenterMatrixY, enemyCenterMatrixX] == TowerItem.crossroad)
            {
                if(e.EndGoal == 1)
                {
                    tmpVect = e.Speed;
                    tmpVect.X = e.MS;
                    tmpVect.Y = 0;
                    e.Speed = tmpVect;
                }
                else if (e.EndGoal == 0)
                {
                    tmpVect = e.Speed;
                    tmpVect.X = -e.MS;

                    tmpVect.Y = 0;
                    e.Speed = tmpVect;
                }
            }
        }
        public void EnemyGoalReached(Enemy e)
        {
            user.HP -= e.Damage;
            enemies.Remove(e);
            if (user.HP > 0)
            {
                
            }

        }
        public bool Victory()
        {
            if(user.HP > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EnemyDeath(Enemy e)
        {
            if (e.Health <= 0)
            {
                user.Gold += e.Value;
                enemies.Remove(e);
            }
        }
    }
}

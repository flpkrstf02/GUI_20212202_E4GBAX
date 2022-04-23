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
        private double height;
        private double width;
        private int matrixHelperX;
        private int matrixHelperY;
        private Size size;
        public EnemyLogic()
        {

        }
        public EnemyLogic(TowerItem[,] Matrix,List<Enemy> Enemies , Player Player, double height, double width, Size size)
        {
            this.matrix = Matrix;
            this.user = Player;
            this.enemies = Enemies;
            this.height = height;
            this.width = width;
            this.size = size;
        }
        private void AvgEnemyMaker(Enemy e)
        {
            e.Health = 10;
            e.Damage = 10;
            e.Value = 10;
        }
        private void StrongEnemyMaker(Enemy e)
        {
            e.Health = 25;
            e.Damage = 25;
            e.Value = 25;
        }

        private void BossEnemyMaker(Enemy e)
        {
            e.Health = 100;
            e.Damage = 50;
            e.Value = 125;
        }
       // Point centerHelper;
        public void EnemyMove(Enemy e)
        {
            width = size.Width / matrix.GetLength(1);
            height = size.Height / matrix.GetLength(0);
            matrixHelperY = (int)(e.Center.X / (width + (width / 2))+1.05);
            matrixHelperX = (int)(e.Center.Y / (height + (height / 2))+0.6);
            if (matrix[matrixHelperX, matrixHelperY + 1] == TowerItem.path && e.Speed.X == 0)//jobbra
            {
                tmpVect = e.Speed;
                tmpVect.X = 10;
                tmpVect.Y = 0;
                e.Speed = tmpVect;
            }
            else if (matrixHelperY - 1 >= 0 && (matrix[matrixHelperX, matrixHelperY - 1] == TowerDefenseLogic.TowerItem.path) && e.Speed.X == 0)//balra
            {
                tmpVect = e.Speed;
                tmpVect.X = -10;
                tmpVect.Y = 0;
                e.Speed = tmpVect;
            }
            else if ((matrix[matrixHelperX + 1, matrixHelperY] == TowerItem.path) && e.Speed.Y == 0) //lefelé
            {
                tmpVect = e.Speed;
                tmpVect.X = 0;
                tmpVect.Y = 10;
                e.Speed = tmpVect;
            }
            else if ((matrixHelperX - 1) >= 0 && (matrix[matrixHelperX - 1, matrixHelperY] == TowerDefenseLogic.TowerItem.path) && e.Speed.Y == 0) //felfelé
            {
                tmpVect = e.Speed;
                tmpVect.X = 0;
                tmpVect.Y = -10;
                e.Speed = tmpVect;
          }
            
            Point centerHelper = new Point(e.Center.X + e.Speed.X, e.Center.Y + e.Speed.Y);
            e.Center = centerHelper;
            int enemyCenterMatrixX = (int)(e.Center.X / (width + (width / 2))+1.05);
            int enemyCenterMatrixY = (int)(e.Center.Y / (height + (height / 2))+0.6);
            if(matrix[enemyCenterMatrixY,enemyCenterMatrixX] == TowerItem.goal)
            {
                EnemyGoalReached(e);
            }
        }
        public void EnemyGoalReached(Enemy e)
        {
                user.HP -= e.Damage;
                enemies.Remove(e);
            if (user.HP <= 0)
            {

            }
            
        }
        public void EnemyDeath(Enemy e)
        {
            if(e.Health <= 0)
            {
                user.Gold += e.Value;
                enemies.Remove(e);
            }
        }
    }
}

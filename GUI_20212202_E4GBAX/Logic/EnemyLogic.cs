using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public class EnemyLogic : IEnemyLogic
    {
        private IGameModel gameModel;
        private Vector tmpVect;
        public EnemyLogic(IGameModel gm)
        {
            this.gameModel = gm;
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

        public void EnemyMove(Enemy e)
        {
            if ((gameModel.GameMatrix[(int)e.Center.X - 1, (int)e.Center.Y] == TowerDefenseLogic.TowerItem.path) && e.Speed.X > 0)
            {
                tmpVect = e.Speed;
                tmpVect.X = e.Speed.X * -1;
                e.Speed = tmpVect;
            }
            else if ((gameModel.GameMatrix[(int)e.Center.X + 1, (int)e.Center.Y] == TowerDefenseLogic.TowerItem.path) && e.Speed.X < 0)
            {
                tmpVect = e.Speed;
                tmpVect.X = e.Speed.X * -1;
                e.Speed = tmpVect;
            }
            else if ((gameModel.GameMatrix[(int)e.Center.X, (int)e.Center.Y - 1] == TowerDefenseLogic.TowerItem.path) && e.Speed.Y > 0)
            {
                tmpVect = e.Speed;
                tmpVect.Y = e.Speed.Y * -1;
                e.Speed = tmpVect;
            }
            else if ((gameModel.GameMatrix[(int)e.Center.X, (int)e.Center.Y + 1] == TowerDefenseLogic.TowerItem.path) && e.Speed.Y < 0)
            {
                tmpVect = e.Speed;
                tmpVect.Y = e.Speed.Y * -1;
                e.Speed = tmpVect;
            }
        }
        //public void EnemyGoalReached(Enemy e)
        //{
        //    if(gameModel.GameMatrix[(int)e.Center.X, (int)e.Center.Y] == )
        //}
    }
}

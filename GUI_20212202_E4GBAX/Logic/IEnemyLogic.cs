﻿using GUI_20212202_E4GBAX.Models;

namespace GUI_20212202_E4GBAX.Logic
{
    public interface IEnemyLogic
    {
        Enemy AvgEnemyMaker(double x, double y);
        Enemy BossEnemyMaker(double x, double y);
        void EnemyDeath(Enemy e);
        void EnemyGoalReached(Enemy e);
        void EnemyMove(Enemy e);
        Enemy StrongEnemyMaker(double x, double y);
    }
}
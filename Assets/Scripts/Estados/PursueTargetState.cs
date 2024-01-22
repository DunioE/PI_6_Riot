using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PursueTargetState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //persegue o alvo
            //se estiver na distancia correta, passa para o combat state,
            //se o alvo estiver fora da distancia ele continua neste estado a perseguir o alvo
            return this;
        }
    }
}

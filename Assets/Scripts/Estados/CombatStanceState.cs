using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CombatStanceState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //verifica a distancia para atacar
            //se estiver na distancia certa prossegue para o ataque
            //se estiver em um cooldown após o ataque ele volta para este estado
            //se o alvo estiver longe ele volta para este estado de perseguissão
            return this;
        }
    }
}

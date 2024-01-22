using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class AttackState : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            //seleciona um dos possiveis ataques, baseado em attack scores
            //se n�o conseguir usar esse ataque por causa de algum problema como distancia, ele seleciona um novo ataque
            //se n�o houver problemas, ele para o movimento e ataca o alvo
            //volta ao combat state ap�s o ataque
            return this;
        }
    }
}
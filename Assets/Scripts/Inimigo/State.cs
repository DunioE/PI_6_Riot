using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public abstract class State : MonoBehaviour
    {
        //Vai perseguir o alvo
        //Quando estiver na distancia certa troca para combate
        public abstract State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager);
    }
}

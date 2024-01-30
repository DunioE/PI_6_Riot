using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyBossManager : MonoBehaviour
    {
        public string bossName;
        public FogWall fogWall;
        UIBossHealthBar bossHealthBar;
        EnemyStats enemyStats;
        WorldEventManager worldEventManager;

        private void Awake()
        {
            bossHealthBar = Object.FindFirstObjectByType<UIBossHealthBar>();
            enemyStats = GetComponent<EnemyStats>();
            fogWall = GetComponentInChildren<FogWall>();
            worldEventManager = FindObjectOfType<WorldEventManager>();

            if (worldEventManager == null)
            {
                
            }
        }

        private void Start()
        {
            bossHealthBar.SetBossName(bossName);
            bossHealthBar.SetBossMaxHealth(enemyStats.maxHealth);
        }

        public void UpdateBossHealthBar(int currentHealth)
        {
            bossHealthBar.SetBossCurrentHealth(currentHealth);

            
            if (currentHealth <= 0 && worldEventManager != null)
            {
                Invoke("DeactivateHealthBarWithDelay", 3f);

                worldEventManager.BossHasBeenDefeated();
            }
        }

        private void DeactivateHealthBarWithDelay()
        {
            bossHealthBar.SetHealthBarToInactive();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : CharacterStats
    {
        Animator animator;

        public UIEnemyHealthBar enemyHealthBar;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;

            currentHealth = currentHealth - damage;
            enemyHealthBar.SetHealth(currentHealth);

            animator.Play("DamageE_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("DeadE_01");
                isDead = true;
            }
        }
    }
}

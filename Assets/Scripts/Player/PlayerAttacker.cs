using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        PlayerManager playerManager;
        PlayerStats playerStats;
        PlayerInventory playerInventory;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponent<AnimatorHandler>();
            playerManager = GetComponentInParent<PlayerManager>();
            playerStats = GetComponentInParent<PlayerStats>();
            playerInventory = GetComponentInParent<PlayerInventory>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
            inputHandler = GetComponentInParent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);

                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                }
                else if (lastAttack == weapon.th_light_attack_1)
                {
                    animatorHandler.PlayTargetAnimation(weapon.th_light_attack_2, true);
                }
            }

        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {
                animatorHandler.PlayTargetAnimation(weapon.th_light_attack_1, true);
                lastAttack = weapon.th_light_attack_1;
            }
            else
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
                lastAttack = weapon.OH_Light_Attack_1;
            }
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {
                animatorHandler.PlayTargetAnimation(weapon.th_heavy_attack_1, true);
                lastAttack = weapon.th_heavy_attack_1;
            }
            else
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
                lastAttack = weapon.OH_Light_Attack_1;
            }

        }

        #region InputActions

        public void HandleRBAction()
        {
            if (playerInventory.rightWeapon.isMeleeWeapon)
            {
                PerformRBMeleeAction();
            }
            else if (playerInventory.rightWeapon.isSpellCaster || playerInventory.rightWeapon.isFaithCaster || playerInventory.rightWeapon.isPyroCaster)
            {
                PerformRBMagicAction(playerInventory.rightWeapon);
            }
        }

        #endregion

        #region Attack Action

        private void PerformRBMeleeAction()
        {

            if (playerManager.canDoCombo)
            {
                inputHandler.comboFlag = true;
                HandleWeaponCombo(playerInventory.rightWeapon);
                inputHandler.comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;
                if (playerManager.canDoCombo)
                    return;

                animatorHandler.anim.SetBool("isUsingRightHand", true);
                HandleLightAttack(playerInventory.rightWeapon);
            }
        }

        private void PerformRBMagicAction(WeaponItem weapon)
        {
            if (playerManager.isInteracting)
                return;

            if (weapon.isFaithCaster)
            {
                if (playerInventory.currentSpell != null && playerInventory.currentSpell.isFaithSpell)
                {
                    if(playerStats.currentFocusPoints >= playerInventory.currentSpell.focusPointCost)
                    {
                        playerInventory.currentSpell.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);
                    }
                    else
                    {
                        animatorHandler.PlayTargetAnimation("Shrug", true);
                    }
                }
            }
            else if (weapon.isPyroCaster)
            {
                if (playerInventory.currentSpell != null && playerInventory.currentSpell.isPyroSpell)
                {
                    if (playerStats.currentFocusPoints >= playerInventory.currentSpell.focusPointCost)
                    {
                        playerInventory.currentSpell.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);
                    }
                    else
                    {
                        animatorHandler.PlayTargetAnimation("Shrug", true);
                    }
                }
            }
        }

        private void SuccessfullyCastSpell()
        {
            playerInventory.currentSpell.SuccessfullyCastSpell(animatorHandler, playerStats);
            animatorHandler.anim.SetBool("isFiringSpell", true);
        }

        #endregion

    }

}
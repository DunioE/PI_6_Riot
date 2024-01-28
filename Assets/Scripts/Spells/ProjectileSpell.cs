using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "Spells/Projectile Spell")]

    public class ProjectileSpell :  SpellItem
    {
        public float baseDamage;
        public float projectileVelocity;
        Rigidbody rigidBody;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlotManager)
        {
            base.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, weaponSlotManager.rightHandSlot.transform);
            instantiatedWarmUpSpellFX.transform.localScale = new Vector3(100, 100, 100);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);

        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            base.SuccessfullyCastSpell(animatorHandler, playerStats);
        }
    }
}

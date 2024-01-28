using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "Spells/Projectile Spell")]

    public class ProjectileSpell :  SpellItem
    {
        [Header("Projectile Damage")]
        public float baseDamage;

        [Header("Projectile Physics")]
        public float projectileForwardVelocity;
        public float projectileUpwardVelocity;
        public float projectileMass;
        public bool isEffectedByGravity;
        Rigidbody rigidBody;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlotManager)
        {
            base.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, weaponSlotManager.rightHandSlot.transform);
            instantiatedWarmUpSpellFX.transform.localScale = new Vector3(100, 100, 100);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);

        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, CameraHandler cameraHandler, WeaponSlotManager weaponSlotManager)
        {
            base.SuccessfullyCastSpell(animatorHandler, playerStats, cameraHandler, weaponSlotManager);
            GameObject instantiatedspellFX = Instantiate(spellCastFX, weaponSlotManager.rightHandSlot.transform.position, cameraHandler.cameraPivotTransform.rotation);
            rigidBody = instantiatedspellFX.GetComponent<Rigidbody>();
            //spel IDamagecolliden = instantiatedSpellIFX.GetComponent «Spell Danagecollider›(Fl

            if(cameraHandler.currentLockOnTarget != null)
            {
                instantiatedspellFX.transform.LookAt(cameraHandler.currentLockOnTarget.transform);
            }
            else
            {
                instantiatedspellFX.transform.rotation = Quaternion.Euler(cameraHandler.cameraPivotTransform.eulerAngles.x, playerStats.transform.eulerAngles.y, 0);
            }

            rigidBody.AddForce(instantiatedspellFX.transform.forward * projectileForwardVelocity);
            rigidBody.AddForce(instantiatedspellFX.transform.up * projectileUpwardVelocity);
            rigidBody.useGravity = isEffectedByGravity;
            rigidBody.mass = projectileMass;
            instantiatedspellFX.transform.parent = null;
        }
    }
}

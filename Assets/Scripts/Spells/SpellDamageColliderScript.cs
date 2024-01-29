using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class SpellDamageColliderScript : DamageCollider
    {
        public GameObject impactParticles;
        public GameObject projectileParticles;
        public GameObject muzzleParticles;

        bool hasCollided = false;

        CharacterStats spellTarget;
        Rigidbody rigidBody;

        Vector3 impactNormal;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            projectileParticles = Instantiate(projectileParticles, transform.position, transform.rotation);
            projectileParticles.transform.parent = transform;

            if (muzzleParticles)
            {
                muzzleParticles = Instantiate(muzzleParticles, transform.position, transform.rotation);
                Destroy(muzzleParticles, 2f);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!hasCollided)
            {
                spellTarget = collision.transform.GetComponent<CharacterStats>();

                if (spellTarget != null)
                {
                    spellTarget.TakeDamage(currentWeaponDamage);
                }
                hasCollided = true;
                impactParticles = Instantiate(impactParticles, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal));

                Destroy(projectileParticles);
                Destroy(impactParticles, 5f);
                Destroy(gameObject, 5f);
            }
        }
    }
}

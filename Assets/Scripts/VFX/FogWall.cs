using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class FogWall : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ActivateFogWall()
        {
            gameObject.SetActive(true);
        }

        public void DeactivateFogWall()
        {
            gameObject.SetActive(false);

            Collider[] colliders = GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }

            ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Stop();
                particleSystem.gameObject.SetActive(false);
            }
        }
    }
}

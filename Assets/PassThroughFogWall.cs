using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PassThroughFogWall : Interactable
    {
        WorldEventManager worldEventManager;

        private void Awake()
        {
            worldEventManager = Object.FindFirstObjectByType<WorldEventManager>();
        }

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);
            playerManager.PassThroughFogWallInteraction(transform);
            worldEventManager.ActivateBossFight();

            StartCoroutine(DestroyAfterAnimation());

            IEnumerator DestroyAfterAnimation()
            {
                yield return new WaitForSeconds(2.0f);

                Destroy(gameObject);
            }
        }
    }
}

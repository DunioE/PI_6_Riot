using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WeaponPickUP : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            PickUpItem(playerManager);
        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory;
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;

            playerInventory = playerManager.GetComponent<PlayerInventory>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();

            playerLocomotion.rigidbody.velocity = Vector3.zero; //impede o player de mover
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //inicia a anima��o
            playerInventory.weaponsInventory.Add(weapon);
            Destroy(gameObject);
        }
    }

}

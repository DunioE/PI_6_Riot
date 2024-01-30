using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EventColliderBeginBossFight : MonoBehaviour
    {
        WorldEventManager worldEventManager;

        private void Awake()
        {
            worldEventManager = Object.FindFirstObjectByType<WorldEventManager>();
        }

        private void OnTriggerEnter(Collider Other)
        {
            if(Other.tag == "Player")
            {
                worldEventManager.ActivateBossFight();
            }
        }
    }
}

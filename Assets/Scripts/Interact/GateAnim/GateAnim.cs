using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnim : MonoBehaviour
{
    public Animator playerAnimator;

    public string gateAnimationName = "GateAnimation";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAnimator.Play(gateAnimationName);
        }
    }
}

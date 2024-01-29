using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterManager : MonoBehaviour
    {
        public Transform lockOnTransform;

        [Header("Spells")]
        public bool isFiringSpell;

        [Header("Movement Flag")]
        public bool isRotatingWithRootMotion;
        public bool canRotate;

    }
}

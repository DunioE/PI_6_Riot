using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class Item : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemicon;
        public string itemName;
    }
}

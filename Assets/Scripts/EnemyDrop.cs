using System;
using UnityEngine;




[Serializable]
public class EnemyDrop
{
    // How likely the item is to drop
    public float Probability;
    // Drop to instantiate
    public GameObject DropItem;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool isEquipped = false;
    public abstract string WeaponName { get; set; }
    public abstract int Damage { get; set; }

}

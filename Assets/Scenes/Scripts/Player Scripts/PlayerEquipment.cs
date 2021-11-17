using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour, IPlayerEquipment
{
    public Weapon EquippedWeapon { get; set; } = null;
    public Transform weaponHolder;
    public Transform interactables;

    public void EquipWeapon(Weapon weapon)
    {

        Debug.Log($"You equipped {weapon.WeaponName}");
        weapon.transform.parent = weaponHolder;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.isEquipped = true;
        EquippedWeapon = weapon;
        
    }

    public void DropWeapon(Weapon weapon)
    {
        if (!EquippedWeapon)
        {
            return;
        }

        weapon.transform.rotation = Quaternion.Euler(Vector3.zero);
        weapon.transform.SetParent(interactables);
        weapon.isEquipped = false;
        weapon.gameObject.AddComponent<InteractableWeapon>();

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWeapon : Interactable
{
    Weapon _interactableWeapon;
    Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _interactableWeapon = GetComponent<Weapon>();
    }

    public override void Interact(Player player)
    {
        if (player.PLayerEquipment.EquippedWeapon != null)
        {
            player.PLayerEquipment.DropWeapon(player.PLayerEquipment.EquippedWeapon);
        }

        player.PLayerEquipment.EquipWeapon(_interactableWeapon);
        Destroy(_rigidBody);
        Destroy(this);
    }
}

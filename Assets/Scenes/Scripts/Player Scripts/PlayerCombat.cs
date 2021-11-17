using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IPlayerCombat
{
    IPlayerEquipment playerEquipment;
    public Transform AimedTarget { get; set; }
    public Vector3 AbilityOriginPoint => _raycastOriginTarget.position;

    [SerializeField] Transform _raycastOriginTarget;


    private void Start()
    {
        playerEquipment = GetComponent<IPlayerEquipment>();
    }

    private void Update()
    {
        Ray ray = new Ray(_raycastOriginTarget.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            AimedTarget = hit.transform;
        }
        else
        {
            AimedTarget = null;
        }
    }


    public void PerformNormalAttack()
    {
        if (!playerEquipment.EquippedWeapon)
        {
            return;
        }

        Debug.Log($"Performing normal attack with {playerEquipment.EquippedWeapon.WeaponName}");
    }

    public void PerformSpecialAttack()
    {
        if (!playerEquipment.EquippedWeapon)
        {
            return;
        }

        Debug.Log($"Performing special attack with {playerEquipment.EquippedWeapon.WeaponName}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [Header("Mage Abilities")]
    [SerializeField] Ability _fireBall;
    [SerializeField] Ability _fireBlast;
    [SerializeField] Ability _holyLight;
    [SerializeField] Ability _arcaneVoid;



    public Ability GetFireBall()
    {
        var instantiation = Instantiate(_fireBall);
        instantiation = _fireBall;

        return instantiation;
    }

    public Ability GetFireBlast()
    {
        var instantiation = Instantiate(_fireBlast);
        instantiation = _fireBlast;

        return instantiation;
    }

    public Ability GetHolyLight()
    {
        var instantiation = Instantiate(_holyLight);
        instantiation = _holyLight;

        return instantiation;
    }

    public Ability GetArcaneVoid()
    {
        var instantiation = Instantiate(_arcaneVoid);
        instantiation = _arcaneVoid;

        return instantiation;
    }


}

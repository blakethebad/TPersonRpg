using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{

    [SerializeField] string _abilityName;
    [SerializeField] float _cost;
    [SerializeField] float _cooldown;
    [SerializeField] string _description;

    public string AbilityName => _abilityName;
    public string Description => _description;
    public float Cost { get { return _cost; } set { _cost = value; } }
    public float Cooldown { get { return _cooldown; } set { _cooldown = value; } }


    public virtual void Cast(Player player)
    {
        Debug.Log($"Player has cast {AbilityName} and it costed {Cost} and player has to wait for {Cooldown} seconds");
    }
}

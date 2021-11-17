using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyLightAbility : Ability, ISelfTargetAbility, IHealAbility
{
    [SerializeField] ParticleSystem _particle;
    public override void Cast(Player player)
    {
        base.Cast(player);
        var instantiation = Instantiate(_particle);
        instantiation.transform.position = player.transform.position;
        instantiation.Play();
    }
}

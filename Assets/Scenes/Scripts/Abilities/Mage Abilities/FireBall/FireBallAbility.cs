using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAbility : Ability, IAoeAbility, IProjectileAbility, IDamageAbility
{
    public float DamageAmount { get; set; }

    public Projectile ProjectileObject { get; }

    public override void Cast(Player player)
    {
        base.Cast(player);
    }
}

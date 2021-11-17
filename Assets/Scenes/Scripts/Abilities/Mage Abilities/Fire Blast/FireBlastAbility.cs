using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastAbility : Ability, IProjectileAbility, IDamageAbility
{
    public Projectile ProjectileObject { get; }
    [SerializeField] DirectProjectile _projectileParticle;
    [SerializeField] float _damageAmount;
    [SerializeField] float _particleSpeed;

    public float DamageAmount { get; set; }



    public override void Cast(Player player)
    {
        base.Cast(player);
        var instantiation = Instantiate(_projectileParticle);
        instantiation.ProjectileSpeed = _particleSpeed;
        instantiation.Direction = player.transform.forward;
        instantiation.ProjectileOrigin = player.PlayerCombat.AbilityOriginPoint;
        instantiation.MaxLifeTime = 5f;
    }
}

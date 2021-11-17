using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBiteAbility : Ability, ISingleTargetAbility, IProjectileAbility, IDamageAbility
{
    public Projectile ProjectileObject => _projectileObject;
    [SerializeField] ProjectileWithTarget _projectileObject;
    [SerializeField] float _projectileSpeed;
    public float DamageAmount { get; set; }
    [SerializeField] float _DamageAmount;

    public Transform TargetTransform { get; set; }


    public override void Cast(Player player)
    {
        if (!player.PlayerCombat.AimedTarget) { Debug.Log("Please select a target"); return; }
        base.Cast(player);

        var instantiatedProjectile = Instantiate(_projectileObject);
        instantiatedProjectile.ProjectileOrigin = player.PlayerCombat.AbilityOriginPoint;
        instantiatedProjectile.ProjectileSpeed = _projectileSpeed;
        instantiatedProjectile.TargetTransform = player.PlayerCombat.AimedTarget;
        instantiatedProjectile.DamageAmount = DamageAmount;


    }
}

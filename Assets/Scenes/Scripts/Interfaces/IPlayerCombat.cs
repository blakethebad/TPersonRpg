using UnityEngine;
public interface IPlayerCombat
{
    Transform AimedTarget { get; set; }
    Vector3 AbilityOriginPoint { get; }
    void PerformNormalAttack();
    void PerformSpecialAttack();
}
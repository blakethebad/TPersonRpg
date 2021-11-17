using System.Collections;
using UnityEngine;


public class PlayerAbilities : MonoBehaviour, IPlayerAbilities
{
    Player _player;
    [SerializeField] AbilityManager _abilityManager;
    public Ability[] Abilities { get; set; } = new Ability[4];
    public Ability SelectedAbility { get; set; }

    private void Start()
    {
        _player = GetComponent<Player>();
        SetTestingAbilities();
    }

    void SetTestingAbilities()
    {
        SetAbility(_abilityManager.GetArcaneVoid(), 0);
        SetAbility(_abilityManager.GetFireBall(), 1);
        SetAbility(_abilityManager.GetHolyLight(), 2);
        SetAbility(_abilityManager.GetFireBlast(), 3);

    }

    public void CastSelectedAbility()
    {
        if (!SelectedAbility) { Debug.Log("Please select an ability"); return; }
        SelectedAbility.Cast(_player);
    }

    public void SelectAbility(int index)
    {
        
        SelectedAbility = Abilities[index];
        Debug.Log($"You have selected {SelectedAbility.AbilityName}");
    }

    public void SetAbility(Ability ability, int index)
    {
        Abilities[index] = ability;
    }

}
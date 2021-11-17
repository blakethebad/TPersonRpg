public interface IPlayerAbilities
{
    Ability[] Abilities { get; set; }
    Ability SelectedAbility { get; set; }
    void CastSelectedAbility();
    void SelectAbility(int index);
    void SetAbility(Ability ability, int index);
}
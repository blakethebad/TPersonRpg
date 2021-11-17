public interface IPlayerEquipment
{
    Weapon EquippedWeapon { get; set; }

    void DropWeapon(Weapon weapon);
    void EquipWeapon(Weapon weapon);
}
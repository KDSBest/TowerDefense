namespace DamagePerkSystem
{
    public interface ICalculateDamagePerk : IPerk
    {
        void ModifyWeaponConfig(DamageWeaponConfig weaponConfig);

        bool IsActiveForTower(TowerType towerType);
    }

    public interface IBuffPerk : IPerk
    {
        void ModifyWeaponConfig(DamageWeaponConfig weaponConfig);

        bool IsActiveForTower(TowerType towerType);
    }

    public class CannonExtraDamagePerk : ICalculateDamagePerk
    {
        public int ExtraDamage;

        public string Name
        {
            get { return ExtraDamage + " Extra Damage on Armor"; }
        }

        public void ModifyWeaponConfig(DamageWeaponConfig weaponConfig)
        {
            weaponConfig.TrueDamageArmor += ExtraDamage;
        }

        public bool IsActiveForTower(TowerType towerType)
        {
            return towerType == TowerType.Cannon;
        }
    }
}
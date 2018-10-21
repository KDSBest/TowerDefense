using System;
using System.Collections.Generic;

namespace DamagePerkSystem
{
    public class DamageWeaponConfig
    {
        public int TPPercentage;
        public int ShieldPercentage;
        public int ArmorPercentage;
        public int TrueDamageArmor;
        public int TrueDamageShield;
        public int TrueDamageTP;

        public List<BuffPercentageConfig> BuffPercentage = new List<BuffPercentageConfig>();

        public TowerType TowerType;

        public DamageWeaponConfig Clone()
        {
            return new DamageWeaponConfig()
            {
                TPPercentage = TPPercentage,
                ShieldPercentage = ShieldPercentage,
                ArmorPercentage = ArmorPercentage,
                TowerType = TowerType,
                TrueDamageArmor = TrueDamageArmor,
                TrueDamageShield = TrueDamageShield,
                TrueDamageTP = TrueDamageTP,
                BuffPercentage = BuffPercentage
            };
        }
    }
}
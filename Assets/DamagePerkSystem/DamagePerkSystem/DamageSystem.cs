using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagePerkSystem
{
    public class DamageSystem
    {
        private static DamageSystem instance;
        private static object lockObject = new object();
        public static DamageSystem Instance
        {
            get
            {
                // Double Check Lock - Yes you need both checks.
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DamageSystem();
                        }
                    }
                }

                return instance;
            }
        }

        public void CalculateDamage(Player player, Enemy enemy, DamageWeaponConfig origWeaponConfig, int damage)
        {
            var weaponConfig = origWeaponConfig.Clone();

            foreach (ICalculateDamagePerk perk in player.Perks.Where(x => x is ICalculateDamagePerk && ((ICalculateDamagePerk)x).IsActiveForTower(weaponConfig.TowerType)))
            {
                perk.ModifyWeaponConfig(weaponConfig);
            }

            int restDamage = damage;

            enemy.Shield -= weaponConfig.TrueDamageShield;
            enemy.Armor -= weaponConfig.TrueDamageArmor;
            enemy.TP -= weaponConfig.TrueDamageTP;

            if (enemy.Shield < 0)
                enemy.Shield = 0;
            if (enemy.Armor < 0)
                enemy.Armor = 0;
            if (enemy.TP < 0)
                enemy.TP = 0;

            if (enemy.Shield > 0)
            {
                enemy.Shield -= restDamage * weaponConfig.ShieldPercentage / 100;

                restDamage = 0;
                if (enemy.Shield < 0)
                {
                    restDamage = Math.Abs(enemy.Shield) * weaponConfig.ShieldPercentage / 100;
                    enemy.Shield = 0;
                }
            }

            if (enemy.Armor > 0)
            {
                enemy.Armor -= restDamage * weaponConfig.ArmorPercentage / 100;

                restDamage = 0;
                if (enemy.Armor < 0)
                {
                    restDamage = Math.Abs(enemy.Armor) * weaponConfig.ArmorPercentage / 100;
                    enemy.Armor = 0;
                }
            }

            if (enemy.TP > 0)
            {
                enemy.TP -= restDamage * weaponConfig.TPPercentage / 100;

                restDamage = 0;
                if (enemy.TP < 0)
                {
                    restDamage = Math.Abs(enemy.Shield) * weaponConfig.TPPercentage / 100;
                    enemy.TP = 0;
                }
            }
        }

        public void CalculateBuffs(Player player, Enemy enemy, DamageWeaponConfig origWeaponConfig)
        {
            var weaponConfig = origWeaponConfig.Clone();

            foreach (IBuffPerk perk in player.Perks.Where(x => x is IBuffPerk && ((IBuffPerk)x).IsActiveForTower(weaponConfig.TowerType)))
            {
                perk.ModifyWeaponConfig(weaponConfig);
            }

            foreach (var buff in weaponConfig.BuffPercentage)
            {
                if (RandomHelper.GetPercentage(buff.Percentage))
                {
                    enemy.Buffs.Add(buff.Buff);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagePerkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy enemy = new Enemy()
            {
                Armor = 100,
                Shield = 100,
                TP = 100
            };

            while (enemy.TP > 0)
            {
                enemy.InflictDamage(new DamageWeaponConfig()
                {
                    ArmorPercentage = 10,
                    ShieldPercentage = 25,
                    TPPercentage = 100,
                    BuffPercentage = new List<BuffPercentageConfig>()
                    {
                        new BuffPercentageConfig()
                        {
                            Buff = new DamageOverTimeBuff()
                            {
                                Config = new DamageWeaponConfig()
                                {
                                    ArmorPercentage = 100,
                                    ShieldPercentage = 100,
                                    TPPercentage = 100
                                },
                                Damage = 5,
                                Ticks = 10,
                                TickTimeMs = 1000
                            },
                            Percentage = 10
                        }
                    }
                }, 10);

                enemy.Update(1000);

                Console.WriteLine("Enemy Values: " + enemy.ToString());
            }

            Console.ReadLine();
        }
    }
}

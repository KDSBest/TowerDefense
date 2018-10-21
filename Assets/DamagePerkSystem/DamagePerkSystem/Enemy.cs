using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagePerkSystem
{
    public class Enemy
    {
        public int TP;

        public int Shield;

        public int Armor;

        public List<IBuffs> Buffs = new List<IBuffs>();

        public void Update(int deltaTimeMs)
        {
            for (var i = 0; i < Buffs.Count; i++)
            {
                var buff = Buffs[i];
                if (!buff.Update(this, deltaTimeMs))
                {
                    Buffs.RemoveAt(i);
                    i--;
                }
            }
        }

        public void InflictDamage(DamageWeaponConfig config, int damage)
        {
            DamageSystem.Instance.CalculateDamage(Player.Instance, this, config, damage);
            DamageSystem.Instance.CalculateBuffs(Player.Instance, this, config);
        }

        public override string ToString()
        {
            return string.Format("TP: {0}, Armor: {1}, Shield: {2}, Buffs: {3}", TP, Armor, Shield, Buffs.Count);
        }
    }
}

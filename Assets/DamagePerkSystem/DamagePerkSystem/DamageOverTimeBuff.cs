namespace DamagePerkSystem
{
    public class DamageOverTimeBuff : IBuffs
    {
        public DamageWeaponConfig Config;
        public int Damage;
        public int TickTimeMs;
        public int Ticks;

        private int currentTimePassedMs = 0;
        public bool Update(Enemy enemy, int deltaTimeMs)
        {
            currentTimePassedMs += deltaTimeMs;
            if (currentTimePassedMs >= TickTimeMs)
            {
                currentTimePassedMs -= TickTimeMs;
                Ticks--;
                enemy.InflictDamage(Config, Damage);
            }



            return Ticks > 0;
        }
    }
}
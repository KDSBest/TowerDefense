using System;

namespace DamagePerkSystem
{
    public static class RandomHelper
    {
        private static Random rnd = new Random();

        public static bool GetPercentage(int chance)
        {
            return rnd.Next(0, 100) <= chance;
        }
    }
}
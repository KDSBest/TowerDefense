using System.Collections.Generic;

namespace DamagePerkSystem
{
    public class Player
    {
        private static Player instance;
        private static object lockObject = new object();
        public static Player Instance
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
                            instance = new Player();
                        }
                    }
                }

                return instance;
            }
        }

        public List<IPerk> Perks = new List<IPerk>();
    }
}
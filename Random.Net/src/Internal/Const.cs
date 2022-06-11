using System;

namespace SimpleX.Random
{
    namespace Internal
    {
        internal class Const
        {
            private static DateTime Utc1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            internal static int Seed
            {
                get
                {
                    TimeSpan ts = DateTime.UtcNow - Const.Utc1970;
                    return Convert.ToInt32(ts.TotalSeconds);
                }
            }
        }
    }
    }

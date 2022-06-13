using System;

namespace SimpleX.Random
{
    using SimpleX.Random.Internal;

    // 由Bob Jinkens公开的生成随机数的方法
    // 详情见 http://burtleburtle.net/bob/rand/smallprng.html
    // 微软的项目中也实现了该方法
    // 详情见 https://github.com/microsoft/diskspd/blob/master/Common/Common.h
    public class BRandom : IRandom
    {
        private int[] states = new int[4];

        public BRandom()
        {
            var seed = Const.Seed;

            states[0] = 214748357;
            states[1] = seed;
            states[2] = seed;
            states[3] = seed;
        }

        public BRandom(int seed)
        {
            states[0] = 214748357;
            states[1] = seed;
            states[2] = seed;
            states[3] = seed;
        }

        // [0.0, 1.0]
        public float Next()
        {
            var n = NextL();
            return (float)((uint)(n + int.MaxValue) / (double)uint.MaxValue);
        }

        // [min, max]
        public int Next(int min, int max)
        {
            var mod = Next();
            max = max - min;

            return (int)Math.Floor(mod * max + min);
        }

        private int ShiftL32(int num, int bits)
        {
            return (num << bits) | (num >> (32 - bits));
        }

        public long NextL()
        {
            var state = states[0] - ShiftL32(states[1], 3);
            states[0] = states[1] ^ ShiftL32(states[2], 9);
            states[1] = states[2] + ShiftL32(states[3], 23);
            states[2] = states[3] + state;
            states[3] = state + states[0];

            return (long)states[3];
        }
    }
}

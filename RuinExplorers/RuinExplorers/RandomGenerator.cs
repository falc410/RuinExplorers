using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers
{
    public static class RandomGenerator
    {
        private static Random random;

        public static Random Random
        {
            get { return random; }
            private set { random = value; }
        }

        static RandomGenerator()
        {
            random = new Random();
        }

        public static float GetRandomFloat(float min, float max)
        {
            return (float)random.NextDouble() * (max-min) + min;
        }

        public static double GetRandomDouble(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        public static Vector2 GetRandomVector2(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(GetRandomFloat(xMin, xMax), GetRandomFloat(yMin, yMax));
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

    }
}

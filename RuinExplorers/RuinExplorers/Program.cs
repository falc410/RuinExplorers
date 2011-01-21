using System;

namespace RuinExplorers
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RuinExplorersMain game = new RuinExplorersMain())
            {
                game.Run();
            }
        }
    }
#endif
}


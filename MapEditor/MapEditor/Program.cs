using System;

namespace MapEditor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MapEditorMain game = new MapEditorMain())
            {
                game.Run();
            }
        }
    }
#endif
}


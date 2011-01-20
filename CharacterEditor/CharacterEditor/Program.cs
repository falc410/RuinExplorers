using System;

namespace CharacterEditor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (CharacterEditorMain game = new CharacterEditorMain())
            {
                game.Run();
            }
        }
    }
#endif
}


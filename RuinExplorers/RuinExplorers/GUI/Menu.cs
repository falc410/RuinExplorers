using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;

namespace RuinExplorers.GUI
{
    public class Menu
    {
        public enum Trans : int
        {
            Buttons = 0,
            All = 1
        }

        public enum Level : int
        {
            Main = 0,
            Options = 1,
            Quit = 2,
            NewGame = 3,
            ResumeGame = 4,
            EndGame = 5,
            Dead = 6,
            Multiplayer = 7,
            HostGame = 8,
            JoinGame = 9,
            NewArena = 10
        }

        public enum Option : int
        {
            None = -1,
            NewGame = 0,
            Continue = 1,
            Options = 2,
            Quit = 3,
            Back = 4,
            ResumeGame = 5,
            EndGame = 6,
            Multiplayer = 7,
            HostGame = 8,
            JoinGame = 9,
            RumbleOn = 10,
            RumbleOff = 11,
            Cancel = 12,
            AwaitingConnection = 13
        }

        public enum MenuMode : int
        {
            Main = 0,
            Pause = 1,
            Dead = 2
        }

        public float transFrame = 1f;
        public Trans transType = Trans.All;
        public Level transGoal;
        public Level level = Level.Main;
        public int selectedItem;

        Texture2D poseTexture;
        Texture2D poseForegroundTexture;
        Texture2D optionsTexture;
        Texture2D backgroundTexture;
        Texture2D spritesTexture;

        SpriteBatch spriteBatch;

        int[] levelSelect = new int[32];

        Option[] options = new Option[10];
        float[] optionFrames = new float[10];
        int totalOptions = 0;

        Vector2[] fog = new Vector2[128];

        float frame;
        
        GamePadState[] oldState = new GamePadState[4];

        public MenuMode menuMode = MenuMode.Main;

        public Menu(Texture2D poseTexture, Texture2D poseForegroundTexture, Texture2D optionsTexture, Texture2D backgroundTexture,
            Texture2D spritesTexture, SpriteBatch spriteBatch)
        {
            this.poseTexture = poseTexture;
            this.poseForegroundTexture = poseForegroundTexture;
            this.optionsTexture = optionsTexture;
            this.backgroundTexture = backgroundTexture;
            this.spritesTexture = spritesTexture;
            this.spriteBatch = spriteBatch;

            for (int i = 0; i < fog.Length; i++)
            {
                fog[i] = RandomGenerator.GetRandomVector2(-50f, RuinExplorersMain.ScreenSize.X + 50f,
                    RuinExplorersMain.ScreenSize.Y - 100f, RuinExplorersMain.ScreenSize.Y);
            }
        }

        public void Update(RuinExplorersMain game)
        {
            frame += RuinExplorersMain.FrameTime / 2f;
            if (frame > 6.28f) frame -= 6.28f;

            if (transFrame < 2f)
            {
                float pFrame = transFrame;
                transFrame += RuinExplorersMain.FrameTime;
                if (transType == Trans.Buttons)
                    transFrame += RuinExplorersMain.FrameTime;
                if (pFrame < 1f && transFrame >= 1f)
                {
                    levelSelect[(int)level] = selectedItem;
                    level = transGoal;
                    selectedItem = levelSelect[(int)level];
                    switch (level)
                    {
                        case Level.NewGame:
                            game.NewGame();
                            break;
                        case Level.ResumeGame:
                            RuinExplorersMain.GameMode = RuinExplorersMain.GameModes.Playing;
                            break;
                        case Level.EndGame:
                            menuMode = MenuMode.Main;
                            level = Level.Main;
                            break;
                        case Level.Quit:
                            game.Quit();
                            break;
                        case Level.HostGame:

                            break;
                        case Level.JoinGame:

                            break;
                        case Level.NewArena:

                            break;
                    }
                }
            }

            for (int i = 0; i < fog.Length; i++)
            {
                fog[i].X -= RuinExplorersMain.FrameTime * (50f + (float)(i % 20 + 2));
                fog[i].Y += RuinExplorersMain.FrameTime * (float)(i % 14 + 5);
                if (fog[i].X < -150f)
                {
                    fog[i].X = RuinExplorersMain.ScreenSize.X +
                        RandomGenerator.GetRandomFloat(150f, 200f);
                    fog[i].Y = RuinExplorersMain.ScreenSize.Y -
                        RandomGenerator.GetRandomFloat(0f, 300f);
                }
            }

            for (int i = 0; i < optionFrames.Length; i++)
            {
                if (selectedItem == i)
                {
                    if (optionFrames[i] < 1f)
                    {
                        optionFrames[i] += RuinExplorersMain.FrameTime * 7f;
                        if (optionFrames[i] > 1f) optionFrames[i] = 1f;
                    }
                }
                else
                {
                    if (optionFrames[i] > 0f)
                    {
                        optionFrames[i] -= RuinExplorersMain.FrameTime * 4f;
                        if (optionFrames[i] < 0f) optionFrames[i] = 0f;
                    }
                }
            }

            PopulateOptions();

            for (int i = 0; i < 4; i++)
            {
                GamePadState gs = GamePad.GetState((PlayerIndex)i);

                if (totalOptions > 0)
                {
                    if ((gs.ThumbSticks.Left.Y > 0.3f &&
                        oldState[i].ThumbSticks.Left.Y <= 0.3f) ||
                        (gs.DPad.Up == ButtonState.Pressed &&
                        oldState[i].DPad.Up == ButtonState.Released))
                    {
                        selectedItem = (selectedItem + (totalOptions - 1)) % totalOptions;
                    }

                    if ((gs.ThumbSticks.Left.Y < -0.3f &&
                        oldState[i].ThumbSticks.Left.Y >= -0.3f) ||
                        (gs.DPad.Down == ButtonState.Pressed &&
                        oldState[i].DPad.Down == ButtonState.Released))
                    {
                        selectedItem = (selectedItem + 1) % totalOptions;
                    }
                }

                if (options[0] == Option.AwaitingConnection)
                    selectedItem = 1;

                bool ok = false;
                if (transFrame > 1.9f)
                {
                    if (gs.Buttons.A == ButtonState.Pressed &&
                        oldState[i].Buttons.A == ButtonState.Released)
                        ok = true;
                    if (gs.Buttons.Start == ButtonState.Pressed &&
                        oldState[i].Buttons.Start == ButtonState.Released)
                    {
                        if (menuMode == MenuMode.Main ||
                            menuMode == MenuMode.Dead)
                            ok = true;
                        else
                        {
                            Transition(Level.ResumeGame, true);
                        }
                    }

                    if (ok)
                    {
                        switch (level)
                        {
                            case Level.Main:
                                switch (options[selectedItem])
                                {
                                    case Option.NewGame:
                                        Transition(Level.NewGame, true);
                                        break;
                                    case Option.ResumeGame:
                                        Transition(Level.ResumeGame, true);
                                        break;
                                    case Option.EndGame:
                                        Transition(Level.EndGame, true);
                                        break;
                                    case Option.Continue:

                                        break;
                                    case Option.Multiplayer:

                                        break;
                                    case Option.Options:
                                        Transition(Level.Options);
                                        break;
                                    case Option.Quit:
                                        Transition(Level.Quit, true);
                                        break;
                                }
                                break;
                            case Level.Dead:
                                switch (options[selectedItem])
                                {
                                    case Option.EndGame:
                                        Transition(Level.EndGame, true);
                                        break;
                                    case Option.Quit:
                                        Transition(Level.Quit, true);
                                        break;
                                }
                                break;
                            case Level.Options:
                                //switch (options[selectedItem])
                                //{
                                //    case Option.Back:
                                //        Transition(Level.Main);
                                //        RuinExplorersMain.store.Write(Store.STORE_SETTINGS);
                                //        break;
                                //    case Option.RumbleOn:
                                //        RuinExplorersMain.settings.Rumble = false;
                                //        break;
                                //    case Option.RumbleOff:
                                //        RuinExplorersMain.settings.Rumble = true;
                                //        break;
                                //}
                                break;
                            case Level.Multiplayer:
                                switch (options[selectedItem])
                                {
                                    case Option.Back:
                                        Transition(Level.Main);
                                        break;
                                    case Option.HostGame:
                                        Transition(Level.HostGame);
                                        break;
                                    case Option.JoinGame:
                                        Transition(Level.JoinGame);
                                        break;
                                }
                                break;
                            case Level.HostGame:

                                break;
                            case Level.JoinGame:

                                break;
                        }
                    }
                    else
                    {
                        switch (level)
                        {
                            case Level.JoinGame:

                                break;
                            case Level.HostGame:

                                break;
                        }
                    }
                }
                oldState[i] = gs;
            }
        }

        private void Transition(Level goal)
        {
            Transition(goal, false);
        }

        private void Transition(Level goal, bool all)
        {
            transGoal = goal;
            transFrame = 0f;
            if (all)
                transType = Trans.All;
            else
                transType = Trans.Buttons;
        }

        private float GetAlpha(bool buttons)
        {
            if (!buttons && transType == Trans.Buttons)
                return 1f;
            if (transFrame < 2f)
            {
                if (transFrame < 1f)
                    return 1f - transFrame;
                else
                    return transFrame - 1f;
            }
            return 1f;
        }

        public void Draw()
        {
            spriteBatch.Begin();

            if (menuMode == MenuMode.Main)
            {
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0,
                    1280, 720), new Color(new Vector4(GetAlpha(false),
                    GetAlpha(false), GetAlpha(false), 1f)));
            }
            else if (menuMode == MenuMode.Pause)
            {
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0,
                    1280, 720),
                    new Rectangle(600, 400, 200, 200),
                    new Color(new Vector4(1f, 1f, 1f, .5f)));
            }

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            float pan = (float)Math.Cos((double)frame) * 10f + 10f;
            for (int i = fog.Length / 2; i < fog.Length; i++)
            {
                spriteBatch.Draw(spritesTexture, fog[i] + new Vector2(pan, 0f),
                    new Rectangle((i % 4) * 64, 0, 64, 64),
                    new Color(new Vector4(1f, 1f, 1f, .1f * GetAlpha(false))),
                    (fog[i].X + fog[i].Y) / 100f,
                    new Vector2(32f, 32f),
                    (float)(i % 10) * .5f + 2f, SpriteEffects.None, 1f);
            }

            spriteBatch.End();
            spriteBatch.Begin();


            float poseA = GetAlpha(false);
            if (menuMode != MenuMode.Dead)
            {
                if (menuMode != MenuMode.Main)
                    poseA = 0f;

                spriteBatch.Draw(poseTexture,
                    new Vector2(RuinExplorersMain.ScreenSize.X -
                    (RuinExplorersMain.ScreenSize.Y / 480f) * 380f * (.5f * GetAlpha(false) + .5f)
                    + (float)Math.Cos((double)frame) * 10f + 10f,
                    0f),
                    new Rectangle(0, 0, 421, 480),
                    new Color(new Vector4(poseA, poseA, poseA, 1f)), 0f,
                    new Vector2(), (RuinExplorersMain.ScreenSize.Y / 480f), SpriteEffects.None, 1f);
            }
            PopulateOptions();

            for (int i = 0; i < totalOptions; i++)
            {
                spriteBatch.Draw(optionsTexture,
                    new Vector2(190f + (float)i * 5f + pan + optionFrames[i] * 10f
                    + GetAlpha(true) * 50f,
                    300f + (float)i * 64f - (float)totalOptions * 32f),
                    new Rectangle(0, (int)options[i] * 64, 320, 64), new Color(
                    new Vector4(1f, 1f - optionFrames[i], 1f - optionFrames[i], GetAlpha(true))),
                    (1f - optionFrames[i]) * -.1f, new Vector2(160f, 32f), 1f, SpriteEffects.None, 1f);
            }


            spriteBatch.End();

            if (menuMode != MenuMode.Dead)
            {
                spriteBatch.Begin();


                pan *= 2f;
                for (int i = 0; i < fog.Length / 2; i++)
                {
                    spriteBatch.Draw(spritesTexture, fog[i] + new Vector2(pan, 0f),
                        new Rectangle((i % 4) * 64, 0, 64, 64),
                        new Color(new Vector4(1f, 1f, 1f, .1f * GetAlpha(false))),
                        (fog[i].X + fog[i].Y) / 100f,
                        new Vector2(32f, 32f),
                        (float)(i % 10) * .5f + 2f, SpriteEffects.None, 1f);
                }

                spriteBatch.End();
                spriteBatch.Begin();

                spriteBatch.Draw(poseForegroundTexture,
                    new Vector2(RuinExplorersMain.ScreenSize.X - (RuinExplorersMain.ScreenSize.Y / 480f) * 616f * GetAlpha(false)
                    + (float)Math.Cos((double)frame) * 20f + 20f,
                    RuinExplorersMain.ScreenSize.Y - (RuinExplorersMain.ScreenSize.Y / 480f) * 286f),
                    new Rectangle(0, 0, 616, 286),
                    new Color(new Vector4(GetAlpha(false),
                    GetAlpha(false), GetAlpha(false), 1f)), 0f,
                    new Vector2(), (RuinExplorersMain.ScreenSize.Y / 480f), SpriteEffects.None, 1f);

                spriteBatch.End();
            }
        }

        private void PopulateOptions()
        {
            for (int i = 0; i < options.Length; i++)
                options[i] = Option.None;

            switch (level)
            {
                case Level.Main:
                    if (menuMode == MenuMode.Pause)
                    {
                        options[0] = Option.ResumeGame;
                        options[1] = Option.EndGame;
                        options[2] = Option.Options;
                        options[3] = Option.Quit;
                        totalOptions = 4;
                    }
                    else
                    {
                        options[0] = Option.NewGame;
                        options[1] = Option.Continue;
                        options[2] = Option.Multiplayer;
                        options[3] = Option.Options;
                        options[4] = Option.Quit;
                        totalOptions = 5;
                    }
                    break;
                case Level.Options:
                    //if (RuinExplorersMain.settings.Rumble)
                    //    options[0] = Option.RumbleOn;
                    //else
                    //    options[0] = Option.RumbleOff;
                    //options[1] = Option.Back;
                    //totalOptions = 2;
                    break;
                case Level.Dead:
                    options[0] = Option.EndGame;
                    options[1] = Option.Quit;
                    totalOptions = 2;
                    break;
                case Level.Multiplayer:
                    options[0] = Option.HostGame;
                    options[1] = Option.JoinGame;
                    options[2] = Option.Back;
                    totalOptions = 3;
                    break;
                case Level.HostGame:
                    options[0] = Option.AwaitingConnection;
                    options[1] = Option.Cancel;
                    totalOptions = 2;
                    break;
                case Level.JoinGame:
                    options[0] = Option.AwaitingConnection;
                    options[1] = Option.Cancel;
                    totalOptions = 2;
                    break;
                default:
                    totalOptions = 0;
                    break;
            }

        }
    }
}

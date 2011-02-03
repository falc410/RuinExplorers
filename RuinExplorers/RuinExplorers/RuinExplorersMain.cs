using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;
using RuinExplorers.Helpers;
using RuinExplorers.Particles;
using RuinExplorers.Audio;
using RuinExplorers.Shakes;
using RuinExplorers.GUI;

namespace RuinExplorers
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RuinExplorersMain : Microsoft.Xna.Framework.Game
    {
        public enum GameModes : int
        {
            Menu = 0,
            Playing = 1
        };

        public enum GameType : int
        {
            Solo = 0,
            Arena = 1
        };

        #region Fields
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D mainTarget;
        RenderTarget2D gameTarget;
        RenderTarget2D[] bloomTarget;
        RenderTarget2D waterTarget;
        RenderTarget2D refractTarget;

        Effect filterEffect;
        Effect negEffect;
        Effect pauseEffect;
        Effect bloomEffect;
        Effect waterEffect;

        float[] bloomPulse = { 0f, 0f };
        bool hasBloom = false;

        float waterDelta = 0f;
        float waterTheta = 0f;

        private static float frameTime = 0f;
        private static Vector2 scroll;
        private const float friction = 1000f;
        private const float gravity = 1400f;
        private static Vector2 screenSize = new Vector2();
        private static float slowTime = 0f;

        private static long score = 0;

        Map map;
        HUD hud;

        private static GameType gameType;
        private static int players;
        private static Menu menu;
        private static GameModes gameMode;

        Texture2D[] mapTexture = new Texture2D[1];
        Texture2D[] mapBackgroundTexture = new Texture2D[1];
        
        Character[] characters = new Character[16];
    
        static CharacterDefinition[] characterDefinitions = new CharacterDefinition[16];

        Texture2D nullTexture;
        Texture2D spritesTexture;
        ParticleManager particleManager;

        #endregion
        #region Properties

        public static CharacterDefinition[] CharacterDefinitions
        {
            get { return characterDefinitions; }
        }

        public static GameModes GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }

        public static Menu Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        public static long Score
        {
            get { return score; }
            set { score = value; }
        }

        public static float FrameTime
        {
            get { return frameTime; }
            set { frameTime = value; }
        }

        public static float SlowTime
        {
            get { return slowTime; }
            set { slowTime = value; }
        }

        public static Vector2 ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }

        public static float Friction
        {
            get { return friction; }
        }

        public static float Gravity
        {
            get { return gravity; }
        }

        public static Vector2 Scroll
        {
            get { return scroll; }
            set { scroll = value; }
        }
        #endregion

        public RuinExplorersMain()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            screenSize.X = 800f;
            screenSize.Y = 600f;
            
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            map = new Map();
          
            characterDefinitions[(int)CharacterType.Player1] = new CharacterDefinition("player",CharacterType.Player1);
            characterDefinitions[(int)CharacterType.Zombie] = new CharacterDefinition("zombie",CharacterType.Zombie);
            
            Sound.Initialize();
            Music.Initialize();

            QuakeManager.Init();

            base.Initialize();

            // override menu for debugging!
            //NewGame();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
                        
            // not sure if there is a visible difference with these two constructors
            mainTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24);
            gameTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24);
            refractTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24);
            //mainTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            bloomTarget = new RenderTarget2D[2];
            bloomTarget[0] = new RenderTarget2D(GraphicsDevice, 128, 128, true, SurfaceFormat.Color, DepthFormat.Depth24);
            bloomTarget[1] = new RenderTarget2D(GraphicsDevice, 256, 256, true, SurfaceFormat.Color, DepthFormat.Depth24);
            waterTarget = new RenderTarget2D(GraphicsDevice, 256, 256, true, SurfaceFormat.Color, DepthFormat.Depth24);

            filterEffect = Content.Load<Effect>(@"fx/filter");
            pauseEffect = Content.Load<Effect>(@"fx/pause");
            negEffect = Content.Load<Effect>(@"fx/negative");
            bloomEffect = Content.Load<Effect>(@"fx/bloom");
            waterEffect = Content.Load<Effect>(@"fx/water");

            particleManager = new ParticleManager(spriteBatch);
            spritesTexture = Content.Load<Texture2D>(@"gfx/sprites");
                        

            for (int i = 0; i < mapTexture.Length; i++)
                mapTexture[i] = Content.Load<Texture2D>(@"gfx/segments" + (i + 1).ToString());
            for (int i = 0; i < mapBackgroundTexture.Length; i++)
                mapBackgroundTexture[i] = Content.Load<Texture2D>(@"gfx/background" + (i + 1).ToString());

            Character.LoadTextures(Content);

            nullTexture = Content.Load<Texture2D>(@"gfx/1x1");

            /*
             * Create our menu and HUD objects, which we'll use in Chapter 9.
             */
            menu = new Menu(
                Content.Load<Texture2D>(@"gfx/pose"),
                Content.Load<Texture2D>(@"gfx/posefore"),
                Content.Load<Texture2D>(@"gfx/options"),
                mapBackgroundTexture[0],
                spritesTexture,
                spriteBatch);

            hud = new HUD(spriteBatch, spritesTexture, nullTexture, characters, map);
        }

        public void NewGame()
        {
            gameMode = GameModes.Playing;


            particleManager.Reset();


            map.Path = "start";
            gameType = GameType.Solo;
            players = 1;


            for (int i = 0; i < players; i++)
            {
                characters[i]
                    = new Character(new Vector2(300f
                    + (float)i * 200f, 100f),
                    characterDefinitions[(int)CharacterType.Player1],
                    i,
                    Character.TEAM_PLAYERS);
                characters[i].HP = characters[i].MHP = 100;
            }
            for (int i = players; i < characters.Length; i++)
                characters[i] = null;

            map.GlobalFlags = new MapFlags(64);
            map.Read();
            map.TransDir = TransitionDirection.Intro;
            map.transInFrame = 1f;
        }

        public void Quit()
        {
            this.Exit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {   
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Sound.Update();
            Music.Play("music1");
            QuakeManager.Update();

            frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //frameTime *= 1.5f;

            if (slowTime > 0f)
            {
                slowTime -= frameTime;
                frameTime /= 10f;
            }

            switch (gameMode)
            {
                case GameModes.Playing:
                    UpdateGame();

                    break;
                case GameModes.Menu:
                    if (menu.menuMode == Menu.MenuMode.Dead)
                    {
                        float pTime = FrameTime;
                        frameTime /= 3f;
                        UpdateGame();

                        frameTime = pTime;
                    }
                    menu.Update(this);
                    break;
            }

            base.Update(gameTime);
        }

        private void UpdateGame()
        {
            if (GamePad.GetState(PlayerIndex.One).Triggers.Left > .2f)
                frameTime /= 20f;

            int idx = 0;


            if (characters[idx] != null)
            {
                Scroll += ((characters[idx].Location -
                                    new Vector2(400f, 400f)) - Scroll) * FrameTime * 20f;
            }

            Scroll += QuakeManager.Quake.Vector;

            bloomPulse[0] += FrameTime * .5f;
            bloomPulse[1] += FrameTime * .9f;
            for (int i = 0; i < bloomPulse.Length; i++)
                if (bloomPulse[i] > 6.28f) bloomPulse[i] -= 6.28f;

            float xLim = map.GetXLim();
            float yLim = map.GetYLim();


            waterDelta += FrameTime * 8f;
            waterTheta += FrameTime * 10f;
            if (waterDelta > 6.28f)
                waterDelta -= 6.28f;
            if (waterTheta > 6.28f)
                waterTheta -= 6.28f;

            if (Scroll.X < 0f) scroll.X = 0f;
            if (Scroll.X > xLim) scroll.X = xLim;
            if (Scroll.Y < 0f) scroll.Y = 0f;
            if (Scroll.Y > yLim) scroll.Y = yLim;

            if (map.transOutFrame <= 0f)
            {
                particleManager.UpdateParticles(FrameTime, map, characters);


                if (gameType == GameType.Solo)
                {
                    if (characters[0] != null)
                        characters[0].DoInput(0);
                }


                for (int i = 0; i < characters.Length; i++)
                {
                    if (characters[i] != null)
                    {
                        characters[i].Update(map, particleManager, characters);
                        if (characters[i].DyingFrame > 1f)
                        {
                            if (characters[i].Team == Character.TEAM_PLAYERS)
                            {
                                characters[i].DyingFrame = 1f;
                            }
                            else
                            {
                                if (characters[i].Name != "")
                                    map.mapScript.Flags.SetFlag(characters[i].Name);
                                characters[i] = null;
                            }
                        }
                    }
                }
            }
            if (GamePad.GetState(PlayerIndex.One).Triggers.Left < .2f)
                map.Update(particleManager, characters);
            hud.Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            switch (gameMode)
            {
                case GameModes.Playing:
                    DrawGame();
                    hud.Draw();
                    break;
                case GameModes.Menu:
                    if (menu.menuMode == Menu.MenuMode.Pause ||
                        menu.menuMode == Menu.MenuMode.Dead)
                        DrawGame();
                    menu.Draw();
                    break;
            }

            base.Draw(gameTime);
        }

        private void DrawGame()
        {
            graphics.GraphicsDevice.SetRenderTarget(mainTarget);
            graphics.GraphicsDevice.Clear(Color.Black);
            
            // draw the background and back layers first
            map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 0, 2);

            // next draw the background particles
            particleManager.DrawParticles(spritesTexture, true);

            // next draw the characters(s)           
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != null)
                    characters[i].Draw(spriteBatch);
            }

            // draw other particles
            particleManager.DrawParticles(spritesTexture, false);

            // Draw our refract Particles to refractTarget
            graphics.GraphicsDevice.SetRenderTarget(refractTarget);
            graphics.GraphicsDevice.Clear(Color.Black);
            particleManager.DrawRefractParticles(spritesTexture);

            #region Water Effect
            
            /*
            * Set up our water texture. 
            */
            //EffectPass pass;

            float waterLevel = map.Water - (.2f * ScreenSize.Y);
            if (map.Water > 0f)
            {
                graphics.GraphicsDevice.SetRenderTarget(waterTarget);

                float wLev = (ScreenSize.Y / 2f + waterLevel - Scroll.Y) / ScreenSize.Y;

                waterEffect.Parameters["delta"].SetValue(waterDelta);
                waterEffect.Parameters["theta"].SetValue(waterTheta);
                waterEffect.Parameters["horizon"].SetValue(wLev);

                //waterEffect.CurrentTechnique.Passes[0].Apply();
                waterEffect.CurrentTechnique = waterEffect.Techniques["WaterTechnique"];
                
                spriteBatch.Begin(0, BlendState.Opaque, null,null,null,waterEffect);
                spriteBatch.Draw(mainTarget, new Rectangle(0, 0, 256, 256), Color.White);
                spriteBatch.End();
             
            }

            #endregion

            #region gameTarget / mainTarget
            
            /*
             * Switch to gameTarget and draw our mainTarget with refraction and
             * color filter effects as well as water and bloom overlay.
             */

            graphics.GraphicsDevice.SetRenderTarget(gameTarget);

            if (gameMode == GameModes.Menu)
            {
                pauseEffect.CurrentTechnique = pauseEffect.Techniques["PauseTechnique"]; 
                spriteBatch.Begin(0, BlendState.Opaque,null,null,null,pauseEffect);                               
                spriteBatch.Draw(mainTarget, new Vector2(), Color.White);                
                spriteBatch.End();
              
            }
            else
            {
                graphics.GraphicsDevice.Textures[1] = refractTarget;
                filterEffect.Parameters["burn"].SetValue(.15f);

                filterEffect.Parameters["saturation"].SetValue(0.5f);
                filterEffect.Parameters["r"].SetValue(1.0f);
                filterEffect.Parameters["g"].SetValue(0.98f);
                filterEffect.Parameters["b"].SetValue(0.85f);
                filterEffect.Parameters["brite"].SetValue(0.05f);


                filterEffect.CurrentTechnique = filterEffect.Techniques["FilterTechnique"];
                spriteBatch.Begin(0, BlendState.Opaque,null,null,null,filterEffect);                
                spriteBatch.Draw(mainTarget, new Vector2(), Color.White);                
                spriteBatch.End();
                

                graphics.GraphicsDevice.Textures[1] = null;

                if (map.Water > 0f)
                {
                    spriteBatch.Begin();

                    spriteBatch.Draw(waterTarget, new Rectangle(0,
                        (int)(waterLevel - Scroll.Y),
                        (int)ScreenSize.X, (int)ScreenSize.Y), Color.White);

                    spriteBatch.End();

                }

                // draw our foreground layer
                map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 2, 3);

                if (hasBloom)
                {
                    spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.Additive);

                    for (int i = 0; i < 2; i++)
                        spriteBatch.Draw(bloomTarget[i],
                        new Rectangle(0, 0, (int)ScreenSize.X,
                        (int)ScreenSize.Y), Color.White);

                    spriteBatch.End();

                }
            }

            #endregion

            #region Bloom Effect

            /*
             * Set up the bloom surfaces with our current scene.  Since we're
             * using an already-bloomed scene to create bloom, we end up with a
             * sort of feedback that gives us a nice haze effect.
             */
            for (int i = 0; i < 2; i++)
            {
                hasBloom = true;
                graphics.GraphicsDevice.SetRenderTarget(bloomTarget[i]);

                bloomEffect.Parameters["a"].SetValue(.25f);
                bloomEffect.Parameters["v"].SetValue((float)(i + 1) * 0.01f *
                    ((float)Math.Cos((double)bloomPulse[i]) * .25f + 0.7f));
                bloomEffect.CurrentTechnique = bloomEffect.Techniques["BloomTechnique"];
                spriteBatch.Begin(0, BlendState.Opaque,null,null,null,bloomEffect);
                spriteBatch.Draw(gameTarget, new Rectangle(0, 0, 128 * (i + 1), 128 * (i + 1)),
                    Color.White);                
                spriteBatch.End();                
            }

            #endregion

            /*
             * Render back the gameTarget to backbuffer.
             */

            graphics.GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.Opaque);

            spriteBatch.Draw(gameTarget, new Vector2(), Color.White);

            spriteBatch.End();          
            
            #region Screen Shake Effect
      
            spriteBatch.Begin();

            if (QuakeManager.Blast.Value > 0f)
            {
                for (int i = 7; i >= 0; i--)
                {
                    spriteBatch.Draw(mainTarget,
                        QuakeManager.Blast.Center - Scroll,
                        new Rectangle(0, 0, (int)ScreenSize.X, (int)ScreenSize.Y),
                        new Color(new Vector4(1f, 1f, 1f,
                        .25f * (QuakeManager.Blast.Value / QuakeManager.Blast.Magnitude))),
                        0f, QuakeManager.Blast.Center - Scroll,
                        (1.0f + (QuakeManager.Blast.Magnitude - QuakeManager.Blast.Value)
                        * .1f
                        + ((float)(i) / 50f)),
                        SpriteEffects.None, 1f);

                }
            }

            spriteBatch.End();
            #endregion
        }

    }
}

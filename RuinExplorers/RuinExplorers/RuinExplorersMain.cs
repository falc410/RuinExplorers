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

namespace RuinExplorers
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RuinExplorersMain : Microsoft.Xna.Framework.Game
    {
        #region Fields
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D mainTarget;

        private static float frameTime = 0f;
        private static Vector2 scroll;
        private const float friction = 1000f;
        private const float gravity = 1400f;
        private static Vector2 screenSize = new Vector2();
        private static float slowTime = 0f;

        Map map;

        Texture2D[] mapTexture = new Texture2D[1];
        Texture2D[] mapBackgroundTexture = new Texture2D[1];
        Character[] character = new Character[16];
        CharacterDefinition[] characterDefinition = new CharacterDefinition[16];

        Texture2D spritesTexture;
        ParticleManager particleManager;

        #endregion
        #region Properties

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
            map.Path = "map";
            map.Read();

            characterDefinition[(int)CharacterType.Player1] = new CharacterDefinition("player");
            characterDefinition[(int)CharacterType.Enemy] = new CharacterDefinition("zombie");

            character[0] = new Character(new Vector2(100f, 100f), characterDefinition[(int)CharacterType.Player1],0,Character.TEAM_PLAYERS);
            character[0].map = map;
            character[0].HP = character[0].MHP = 100;

            for (int i = 1; i < 9; i++)
            {
                character[i] = new Character(new Vector2((float)i * 100f, 100f),
                    characterDefinition[(int)CharacterType.Enemy], i, Character.TEAM_NPC);
                character[i].map = map;
            }

            Sound.Initialize();
            Music.Initialize();

            base.Initialize();  
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: not working - RenderTarget2D Constructor has changed probably
            //mainTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 1, SurfaceFormat.Color);
            particleManager = new ParticleManager(spriteBatch);
            spritesTexture = Content.Load<Texture2D>(@"gfx/sprites");

            character[0].particleManager = particleManager;

            for (int i = 0; i < mapTexture.Length; i++)
                mapTexture[i] = Content.Load<Texture2D>(@"gfx/segments" + (i + 1).ToString());
            for (int i = 0; i < mapBackgroundTexture.Length; i++)
                mapBackgroundTexture[i] = Content.Load<Texture2D>(@"gfx/background" + (i + 1).ToString());

            Character.LoadTextures(Content);
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
            
            if (character[0] != null)
            {
                scroll += ((character[0].Location - new Vector2(400f, 400f)) - scroll) * frameTime * 20f;               
            }

            // added for rumble
            scroll += QuakeManager.Quake.Vector;

            float xLim = map.GetXLim();
            float yLim = map.GetYLim();

            if (scroll.X < 0f) scroll.X = 0f;
            if (scroll.X > xLim) scroll.X = xLim;
            if (scroll.Y < 0f) scroll.Y = 0f;
            if (scroll.Y > yLim) scroll.Y = yLim;
            

            particleManager.UpdateParticles(frameTime, map, character);
            if(character[0] != null)
                character[0].DoInput(0);

            for (int i = 0; i < character.Length; i++)
            {
                if (character[i] != null)
                {
                    character[i].Update(map, particleManager, character);
                    if (character[i].DyingFrame > 1f)
                        character[i] = null;
                }
                  
            }

            //call map.update() to update fire & smoke particles on torches
            map.Update(particleManager);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //graphics.GraphicsDevice.SetRenderTarget(mainTarget);
            graphics.GraphicsDevice.Clear(Color.Black);
            
            // draw the background and back layers first
            map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 0, 2);

            // next draw the background particles
            particleManager.DrawParticles(spritesTexture, true);

            // next draw the character(s)
           //character[0].Draw(spriteBatch);
            for (int i = 0; i < character.Length; i++)
            {
                if (character[i] != null)
                    character[i].Draw(spriteBatch);
            }

            // draw other particles
            particleManager.DrawParticles(spritesTexture, false);

            // finally draw the foreground layer
            map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 2, 3);
           
            // TODO: not working!
            #region Screen Shake Effect

            //graphics.GraphicsDevice.SetRenderTarget(0, null);

            //spriteBatch.Begin(SpriteBlendMode.None);

            //spriteBatch.Draw(mainTarget.GetTexture(), new Vector2(), Color.White);

            //spriteBatch.End();

            ///*
            // * Draw our blast effect, which we set up in chapter 8.
            // */

            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            //if (QuakeManager.Blast.Value > 0f)
            //{
            //    for (int i = 7; i >= 0; i--)
            //    {
            //        spriteBatch.Draw(mainTarget.GetTexture(),
            //            QuakeManager.Blast.center - Scroll,
            //            new Rectangle(0, 0, (int)ScreenSize.X, (int)ScreenSize.Y),
            //            new Color(new Vector4(1f, 1f, 1f,
            //            .25f * (QuakeManager.Blast.Value / QuakeManager.Blast.Magnitude))),
            //            0f, QuakeManager.Blast.center - Scroll,
            //            (1.0f + (QuakeManager.Blast.Magnitude - QuakeManager.Blast.Value)
            //            * .1f
            //            + ((float)(i) / 50f)),
            //            SpriteEffects.None, 1f);

            //    }
            //}

            //spriteBatch.End();

            #endregion
           
            base.Draw(gameTime);
        }
    }
}

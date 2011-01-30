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

        public static float frameTime = 0f;
        private static Vector2 scroll;
        private const float friction = 1000f;
        private const float gravity = 900f;
        private static Vector2 screenSize = new Vector2();

        Map map;

        Texture2D[] mapTexture = new Texture2D[1];
        Texture2D[] mapBackgroundTexture = new Texture2D[1];
        Character[] character = new Character[16];
        CharacterDefinition[] characterDefinition = new CharacterDefinition[16];

        Texture2D spritesTexture;
        ParticleManager particleManager;

        #endregion
        #region Properties

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

            character[0] = new Character(new Vector2(100f, 100f), characterDefinition[(int)CharacterType.Player1]);
            character[0].map = map;

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

            frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            particleManager.UpdateParticles(frameTime, map, character);

            if (character[0] != null)
            {
                scroll += ((character[0].Location - new Vector2(400f, 400f)) - scroll) * frameTime * 20f;

                float xLim = map.GetXLim();
                float yLim = map.GetYLim();

                if (scroll.X < 0f) scroll.X = 0f;
                else if (scroll.X > xLim) scroll.X = xLim;
                if (scroll.Y < 0f) scroll.Y = 0f;
                else if (scroll.Y > yLim) scroll.Y = yLim;

                character[0].DoInput(0);
            }
            for (int i = 0; i < character.Length; i++)
            {
                if (character[i] != null)
                    character[i].Update(gameTime);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // draw the background and back layers first
            map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 0, 2);
            // next draw the character(s)
           character[0].Draw(spriteBatch);
            // finally draw the foreground layer
            map.Draw(spriteBatch, mapTexture, mapBackgroundTexture, 2, 3);

            particleManager.DrawParticles(spritesTexture, true);
            character[0].Draw(spriteBatch);
            particleManager.DrawParticles(spritesTexture, false);

            // glowing orb for inner fire above the characters head (for particle testing)
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            //spriteBatch.Draw(spritesTexture,
            //    character[0].Location - new Vector2(0f, 100f) - Scroll,
            //    new Rectangle(0, 128, 64, 64), Color.White, 0.0f,
            //    new Vector2(32.0f, 32.0f), RandomGenerator.GetRandomFloat(0.5f, 1.0f), SpriteEffects.None, 1.0f);
            //spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

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
using TextLibrary;
using CharacterEditor.Character;

namespace CharacterEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CharacterEditorMain : Microsoft.Xna.Framework.Game
    {
        #region Variable Declartion
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Text text;

        CharacterDefinition characterDefinition;

        Texture2D[] headTexture = new Texture2D[1];
        Texture2D[] torsoTexture = new Texture2D[1];
        Texture2D[] legsTexture = new Texture2D[1];
        Texture2D[] weaponTexture = new Texture2D[1];

        Texture2D nullTexture;
        Texture2D arrowTexture;
        Texture2D saveIcon;
        Texture2D openFolderIcon;

        const int FACE_LEFT = 0;
        const int FACE_RIGHT = 1;

        int selectedPart = 0;

        MouseState mouseState;
        MouseState previousMouseState;
        bool mouseClick = false;

        #endregion

        public CharacterEditorMain()
        {
            graphics = new GraphicsDeviceManager(this);
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
            this.IsMouseVisible = true;

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

            font = Content.Load<SpriteFont>(@"Fonts/Arial");
            text = new Text(spriteBatch, font);

            LoadTextures(legsTexture, @"gfx/legs");
            LoadTextures(headTexture, @"gfx/head");
            LoadTextures(torsoTexture, @"gfx/torso");
            //LoadTextures(weaponTexture, @"gfx/weapon");

            saveIcon = Content.Load<Texture2D>(@"gfx/save_icon");
            openFolderIcon = Content.Load<Texture2D>(@"gfx/folder_open_icon");
            arrowTexture = Content.Load<Texture2D>(@"gfx/arrows");
            nullTexture = Content.Load<Texture2D>(@"gfx/1x1");
        }

        private void LoadTextures(Texture2D[] textures, string path)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                textures[i] = Content.Load<Texture2D>(path + (i + 1).ToString());
            }
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

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {

            }
            else
            {
                if (previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    mouseClick = true;
                }
            }

            previousMouseState = mouseState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        #region Custom Draw Methods
        #endregion
        // Draws the character on screen by iterating through all parts
        private void DrawCharacter(Vector2 _location, float _scale, int _face, int _frameIndex, bool _preview, float _alpha)
        {
            Rectangle sourceRect = new Rectangle();

            Frame frame = characterDefinition.Frames[_frameIndex];

            spriteBatch.Begin();

            for (int i = 0; i < frame.Parts.Length; i++)
            {
                Part part = frame.Parts[i];
                if (part.Index > -1)
                {
                    // TODO: modify according to texture!!
                    // spritesheet thinks that every sprite is 64x64
                    /* index 0-63 for head texture
                     * 64-127 for torso texture
                     * 128-191 for legs texture
                     * 192 - 256 for weapons texture
                    */
                    sourceRect.X = ((part.Index % 64) % 5) * 64;
                    sourceRect.Y = ((part.Index % 64) / 5) * 64;
                    sourceRect.Width = 64;
                    sourceRect.Height = 64;

                    if (part.Index >= 192)
                    {
                        // spritesheet for weapons is 64 x 80 per sprite
                        sourceRect.X = ((part.Index % 64) % 3) * 80;
                        sourceRect.Width = 80;
                    }

                    float rotation = part.Rotation;

                    Vector2 location = part.Location * _scale + _location;
                    Vector2 scaling = part.Scaling * _scale;
                    
                    // if weapons or legs are used they have to be scaled up since the image was scaled down in the original spritesheet
                    if (part.Index >= 128)
                        scaling *= 1.35f;
                    if (_face == FACE_LEFT)
                    {
                        rotation = -rotation;
                        location.X -= part.Location.X * _scale * 2.0f;
                    }

                      Texture2D texture = null;

                    int t = part.Index / 64;
                    switch (t)
                    {
                        case 0:
                            texture = headTexture[characterDefinition.HeadIndex];
                            break;
                        case 1:
                            texture = torsoTexture[characterDefinition.TorsoIndex];
                            break;
                        case 2:
                            texture = legsTexture[characterDefinition.LegsIndex];
                            break;
                        case 3:
                            texture = weaponTexture[characterDefinition.WeaponIndex];
                            break;
                    }

                    Color color = new Color(255, 255, 255, (byte)(_alpha * 255));

                    // highlight selected part in red on editable character
                    if (!_preview && selectedPart == i)
                        color = new Color(255, 0, 0, (byte)(_alpha * 255));

                    bool flip = false;

                    if ((_face == FACE_RIGHT && part.Flip == 0) ||
                        (_face == FACE_LEFT && part.Flip == 1))
                        flip = true;

                    if (texture != null)
                    {
                        spriteBatch.Draw(
                            texture,
                            location,
                            sourceRect,
                            color,
                            rotation,
                            new Vector2((float)sourceRect.Width / 2f, 32f),
                            scaling,
                            (flip ? SpriteEffects.None : SpriteEffects.FlipHorizontally),
                            1.0f
                            );
                    }
                }
            }
            spriteBatch.End();             
        }

        // Used to draw a texture as a clickable button
        private bool DrawButton(int x, int y, Texture2D buttonTexture, int mouseX, int mouseY, bool mouseClick)
        {
            bool r = false;
            Rectangle destinationRect = new Rectangle(x, y, 32, 32);

            if (destinationRect.Contains(mouseX, mouseY))
            {
                destinationRect.X -= 1;
                destinationRect.Y -= 1;
                destinationRect.Width += 2;
                destinationRect.Height += 2;
                if (mouseClick)
                    r = true;
            }
            spriteBatch.Begin();
            spriteBatch.Draw(buttonTexture, destinationRect, Color.White);
            spriteBatch.End();

            return r;

        }
    }
}

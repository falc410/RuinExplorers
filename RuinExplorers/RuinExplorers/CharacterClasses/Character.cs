using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RuinExplorers.MapClasses;
using Microsoft.Xna.Framework.Content;

namespace RuinExplorers.CharacterClasses
{
    class Character
    {        
        
        public enum CharacterState
        {
            Ground = 0,
            Air = 1
        }

        public enum CharacterDirection
        {
            Left = 0,
            Right = 1
        }

        public enum LedgeFlags
        {
            Solid = 0
        }

        #region Fields
        public static Texture2D[] headTexture = new Texture2D[1];
        public static Texture2D[] torsoTexture = new Texture2D[1];
        public static Texture2D[] legsTexture = new Texture2D[1];
        public static Texture2D[] weaponTexture = new Texture2D[1];

        public Map map;

        public Vector2 Location;
        public Vector2 Trajectory;
        public CharacterDirection Face;
        public float Scale;
        public int AnimationFrame;
        public CharacterState State;
        public int Animation;
        public String AnimationName;

        public bool keyLeft;
        public bool keyRight;
        public bool keyUp;
        public bool keyDown;
        public bool keyJump;
        public bool keyAttack;
        public bool keySecondary;
        CharacterDefinition characterDefinition;

        float frame = 0f;
        int ledgeAttach = -1;

        GamePadState currentGamepadState = new GamePadState();
        GamePadState previousGamepadState = new GamePadState();
        KeyboardState currentKeyboardState = new KeyboardState();
        KeyboardState previousKeyboardState = new KeyboardState();
        #endregion

        #region Constructor
        
        public Character(Vector2 newLocation, CharacterDefinition newCharDef)
        {
            Location = newLocation;
            Trajectory = new Vector2();

            Face = CharacterDirection.Right;
            Scale = 0.5f;
            characterDefinition = newCharDef;

            SetAnim("fly");

            State = CharacterState.Air;
        }
        #endregion

        private void SetAnim(string newAnim)
        {
            if (AnimationName == newAnim)
                return;
            for (int i = 0; i < characterDefinition.Animations.Length; i++)
            {
                if (characterDefinition.Animations[i].Name == newAnim)
                {
                    Animation = i;
                    AnimationFrame = 0;
                    frame = 0;
                    AnimationName = newAnim;

                    break;
                }
            }
        }


        /// <summary>
        /// Updates the Character, checks for collision and handles input.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            #region Update Animation
            Animation animation = characterDefinition.Animations[Animation];
            KeyFrame keyFrame = animation.KeyFrames[AnimationFrame];

            frame += elapsedTime * 30.0f;
            if (frame > (float)keyFrame.Duration)
            {
                frame -= (float)keyFrame.Duration;
                AnimationFrame++;

                if (AnimationFrame >= animation.KeyFrames.Length)
                    AnimationFrame = 0;

                keyFrame = animation.KeyFrames[AnimationFrame];

                if (keyFrame.FrameReference < 0)
                    AnimationFrame = 0;                
            }            
            #endregion

            #region Update Location by Trajectory
            Vector2 previousLocation = new Vector2(Location.X, Location.Y);

            if (State == CharacterState.Ground)
            {
                if (Trajectory.X > 0f)
                {
                    Trajectory.X -= RuinExplorersMain.Friction * elapsedTime;
                    if (Trajectory.X < 0f)
                        Trajectory.X = 0f;
                }
                if (Trajectory.X < 0f)
                {
                    Trajectory.X += RuinExplorersMain.Friction * elapsedTime;
                    if (Trajectory.X > 0f)
                        Trajectory.X = 0f;
                }
            }

            Location.X += Trajectory.X * elapsedTime;

            if (State == CharacterState.Air)
            {
                Location.Y += Trajectory.Y * elapsedTime;
                Trajectory.Y += elapsedTime * RuinExplorersMain.Gravity;
            }
            #endregion

            #region Collision detection
            if (State == CharacterState.Air)
            {
                #region Air State
                CheckXCollision(map, previousLocation);

                #region Land on ledge
                if (Trajectory.Y > 0.0f)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (map.Legdes[i].TotalNodes > 1)
                        {
                            int ts = map.GetLedgeSection(i, previousLocation.X);
                            int s = map.GetLedgeSection(i, Location.X);
                            float fY;
                            float tfY;
                            if (s > -1 && ts > -1)
                            {
                                tfY = map.GetLedgeYLocation(i, s, previousLocation.X);
                                fY = map.GetLedgeYLocation(i, s, Location.X);
                                if (previousLocation.Y <= tfY && Location.Y >= fY)
                                {
                                    if (Trajectory.Y > 0.0f)
                                    {
                                        Location.Y = fY;
                                        ledgeAttach = i;
                                        Land();
                                    }
                                }
                                else
                                    if (map.Legdes[i].isHardLedge == (int)LedgeFlags.Solid && Location.Y >= fY)
                                    {
                                        Location.Y = fY;
                                        ledgeAttach = i;
                                        Land();
                                    }
                            }
                        }
                    }
                }
                #endregion

                #region Land on Collision Grid
                if (State == CharacterState.Air)
                {
                    if (Trajectory.Y > 0f)
                    {
                        if (map.CheckCollision(new Vector2(Location.X,Location.Y + 15f)))
                        {
                            Location.Y = (float)((int)((Location.Y + 15f) / 64f) * 64);
                            Land();
                        }
                    }
                }
                #endregion

                #endregion
            }
            else if (State == CharacterState.Ground)
            {
                #region Grounded State
                if (ledgeAttach > -1)
                {
                    if (map.GetLedgeSection(ledgeAttach, Location.X) == -1)
                    {
                        FallOff(); 
                    }
                    else
                    {
                        Location.Y = map.GetLedgeYLocation(ledgeAttach, map.GetLedgeSection(ledgeAttach, Location.X), Location.X);
                    }
                }
                else
                {
                    if (!map.CheckCollision(new Vector2(Location.X, Location.Y + 15f)))
                        FallOff();
                }

                CheckXCollision(map, previousLocation);
                #endregion
            }
            #endregion

            #region Key input
            if (AnimationName == "idle" || AnimationName == "run")
            {
                if (keyLeft)
                {
                    SetAnim("run");
                    Trajectory.X = -200f;
                    Face = CharacterDirection.Left;
                }
                else if (keyRight)
                {
                    SetAnim("run");
                    Trajectory.X = 200f;
                    Face = CharacterDirection.Right;
                }
                else
                {
                    SetAnim("idle");
                }
                if (keyJump)
                {
                    SetAnim("fly");
                    Trajectory.Y = -600f;
                    State = CharacterState.Air;
                    ledgeAttach = -1;
                    if (keyRight)
                        Trajectory.X = 200f;
                    if (keyLeft)
                        Trajectory.X = -200f;
                }
            }

            if (AnimationName == "fly")
            {
                if (keyLeft)
                {
                    Face = CharacterDirection.Left;
                    if (Trajectory.X > -200f)
                        Trajectory.X -= 500f * RuinExplorersMain.frameTime;
                }
                if (keyRight)
                {
                    Face = CharacterDirection.Right;
                    if (Trajectory.X < 200f)
                        Trajectory.X += 500f * RuinExplorersMain.frameTime;
                }
            }
            #endregion
        }


        /// <summary>
        /// Checks for x-based collisions.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="pLoc">The previous location.</param>
        private void CheckXCollision(Map map, Vector2 pLocation)
        {
            if (Trajectory.X > 0f)
                if (map.CheckCollision(new Vector2(Location.X + 25f, Location.Y - 15f)))
                    Location.X = pLocation.X;
            if (Trajectory.X < 0f)
                if (map.CheckCollision(new Vector2(Location.X - 25f, Location.Y - 15f)))
                    Location.X = pLocation.X;
        }

        /// <summary>
        /// When no ledges or collision cells are beneath the character
        /// set anim to fly and reset his trajectory.Y.
        /// </summary>
        private void FallOff()
        {
            State = CharacterState.Air;
            SetAnim("fly");
            Trajectory.Y = 0f;
        }

        /// <summary>
        /// Character lands on collision cell or ledge.
        /// </summary>
        private void Land()
        {
            State = CharacterState.Ground;
            SetAnim("idle");
        }

        /// <summary>
        /// Draws the character. Needs to be adjusted depending on texture setup.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sRect = new Rectangle();

            int frameIdx = characterDefinition.Animations[Animation].KeyFrames[AnimationFrame].FrameReference;

            Frame frame = characterDefinition.Frames[frameIdx];

            spriteBatch.Begin();

            for (int i = 0; i < frame.Parts.Length; i++)
            {
                Part part = frame.Parts[i];

                if (part.Index > -1)
                {
                    sRect.X = ((part.Index % 64) % 5) * 64;
                    sRect.Y = ((part.Index % 64) / 5) * 64;
                    sRect.Width = 64;
                    sRect.Height = 64;

                    if (part.Index >= 192)
                    {
                        sRect.X = ((part.Index % 64) % 4) * 80;
                        sRect.Y = ((part.Index % 64) / 4) * 64;
                        sRect.Width = 80;
                    }

                    float rotation = part.Rotation;

                    Vector2 location = part.Location * Scale + Location - RuinExplorersMain.Scroll;
                    Vector2 scaling = part.Scaling * Scale;
                    if (part.Index >= 128) scaling *= 1.35f;

                    if (Face == CharacterDirection.Left)
                    {
                        rotation = -rotation;
                        location.X -= part.Location.X * Scale * 2.0f;
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

                    Color color = Color.White;

                    bool flip = false;

                    if ((Face == CharacterDirection.Right && part.Flip == 0) ||
                        (Face == CharacterDirection.Left && part.Flip == 1))
                        flip = true;

                    if (texture != null)
                    {
                        spriteBatch.Draw(
                            texture,
                            location,
                            sRect,
                            color,
                            rotation,
                            new Vector2((float)sRect.Width / 2f, 32f),
                            scaling,
                            (flip ? SpriteEffects.None : SpriteEffects.FlipHorizontally),
                            1.0f
                            );
                    }
                }
            }

            spriteBatch.End();
        }

        /// <summary>
        /// Loads the textures - but with hardcoded file names and path.
        /// </summary>
        /// <param name="content">The ContentManager.</param>
        internal static void LoadTextures(ContentManager content)
        {
            for (int i = 0; i < headTexture.Length; i++)
                headTexture[i] = content.Load<Texture2D>(@"gfx/head" + (i+1).ToString());
            for (int i = 0; i < torsoTexture.Length; i++)
                torsoTexture[i] = content.Load<Texture2D>(@"gfx/torso" + (i + 1).ToString());
            for (int i = 0; i < legsTexture.Length; i++)
                legsTexture[i] = content.Load<Texture2D>(@"gfx/legs" + (i + 1).ToString());
            for (int i = 0; i < weaponTexture.Length; i++)
                weaponTexture[i] = content.Load<Texture2D>(@"gfx/weapon" + (i + 1).ToString());

        }

        #region Input Handler Methods
        /// <summary>
        /// Handles input for Gamepad or Keyboard.
        /// TODO: Finish input handler for keyboard!
        /// </summary>
        /// <param name="index">The index of the Player who is pressing the button. N/A for keyboard.</param>
        public void DoInput(int index)
        {
            currentGamepadState = GamePad.GetState((PlayerIndex)index);
            currentKeyboardState = Keyboard.GetState();

            keyLeft = false;
            keyRight = false;
            keyJump = false;
            keyUp = false;
            keyDown = false;
            keyAttack = false;
            keySecondary = false;

            if (currentGamepadState.ThumbSticks.Left.X < -0.1f || currentKeyboardState.IsKeyDown(Keys.Left))
                keyLeft = true;

            if (currentGamepadState.ThumbSticks.Left.X > 0.1f || currentKeyboardState.IsKeyDown(Keys.Right))
                keyRight = true;

            if (currentGamepadState.ThumbSticks.Left.Y < -0.1f || currentKeyboardState.IsKeyDown(Keys.Down))
                keyDown = true;

            if (currentGamepadState.ThumbSticks.Left.Y > 0.1f || currentKeyboardState.IsKeyDown(Keys.Up))
                keyUp = true;

            if (currentGamepadState.Buttons.A == ButtonState.Pressed &&
                previousGamepadState.Buttons.A == ButtonState.Released)
                keyJump = true;

            if (currentGamepadState.Buttons.Y == ButtonState.Pressed &&
                previousGamepadState.Buttons.Y == ButtonState.Released)
                keyAttack = true;

            if (currentGamepadState.Buttons.X == ButtonState.Pressed &&
                previousGamepadState.Buttons.X == ButtonState.Released)
                keySecondary = true;

            previousGamepadState = currentGamepadState;
            previousKeyboardState = currentKeyboardState;
        }
        #endregion
    }
}

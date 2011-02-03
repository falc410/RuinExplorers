    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RuinExplorers.MapClasses;
using Microsoft.Xna.Framework.Content;
using RuinExplorers.Helpers;
using RuinExplorers.Particles;
using RuinExplorers.Audio;
using RuinExplorers.AIClasses;
using RuinExplorers.Shakes;

namespace RuinExplorers.CharacterClasses
{
    // Maybe move this to its own .cs file?
    #region public enums
    
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
    #endregion

    /// <summary>
    /// Handles input, drawing, updating and collision check for characters
    /// Requires a start location and a CharacterDefinition to create a new character
    /// and of course proper textures which are loaded in the LoadTextures method
    /// </summary>
    public class Character
    {
        #region Fields

        public static Texture2D[] headTexture = new Texture2D[2];
        public static Texture2D[] torsoTexture = new Texture2D[2];
        public static Texture2D[] legsTexture = new Texture2D[2];
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
        public bool floating;
        public float Speed = 200f;
        public float CollisionMove = 0f;
        public float StunFrame = 0f;

        public AI Ai;
        public bool Ethereal;
        public float DyingFrame = -1f;
        public bool NoLifty;
        public int HP;
        public int MHP;
        public bool CanCancel;
        public int LastHitBy;
        
        public bool keyLeft;
        public bool keyRight;
        public bool keyUp;
        public bool keyDown;
        public bool keyJump;
        public bool keyAttack;
        public bool keySecondary;
        public PressedKeys PressedKey;
        public int[] GotoGoal = { -1, -1, -1, -1, -1, -1, -1, -1 };
        private Script script;
        private CharacterDefinition characterDefinition;
        public int ID;
        public int Team;
        public String Name = "";

        float frame = 0f;
        int ledgeAttach = -1;

        GamePadState currentGamepadState = new GamePadState();
        GamePadState previousGamepadState = new GamePadState();
        public Vector2 RightAnalog;
        KeyboardState currentKeyboardState = new KeyboardState();

        public ParticleManager particleManager;
        
        #endregion

        #region Constants (Triggers mostly)

        public const int TEAM_PLAYERS = 0;
        public const int TEAM_NPC = 1;

        public const int TRIG_PISTOL_ACROSS = 0;
        public const int TRIG_PISTOL_UP = 1;
        public const int TRIG_PISTOL_DOWN = 2;
        public const int TRIG_WRENCH_UP = 3;
        public const int TRIG_WRENCH_DOWN = 4;
        public const int TRIG_WRENCH_DIAG_UP = 5;
        public const int TRIG_WRENCH_DIAG_DOWN = 6;
        public const int TRIG_WRENCH_UPPERCUT = 7;
        public const int TRIG_WRENCH_SMACKDOWN = 8;
        public const int TRIG_KICK = 9;
        public const int TRIG_ZOMBIE_HIT = 10;
        public const int TRIG_BLOOD_SQUIRT_UP = 11;
        public const int TRIG_BLOOD_SQUIRT_UP_FORWARD = 12;
        public const int TRIG_BLOOD_SQUIRT_FORWARD = 13;
        public const int TRIG_BLOOD_SQUIRT_DOWN_FORWARD = 14;
        public const int TRIG_BLOOD_SQUIRT_DOWN = 15;
        public const int TRIG_BLOOD_SQUIRT_DOWN_BACK = 16;
        public const int TRIG_BLOOD_SQUIRT_BACK = 17;
        public const int TRIG_BLOOD_SQUIRT_UP_BACK = 18;
        public const int TRIG_BLOOD_CLOUD = 19;
        public const int TRIG_BLOOD_SPLAT = 20;
        public const int TRIG_CHAINSAW_DOWN = 21;
        public const int TRIG_CHAINSAW_UPPER = 22;
        public const int TRIG_ROCKET = 23;
        public const int TRIG_FIRE_DIE = 24;

        #endregion

        public CharacterDefinition Definition
        {
            get { return characterDefinition; }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// This method has been verified!
        /// </summary>
        /// <param name="newLocation">The new location.</param>
        /// <param name="newCharDef">The new char def.</param>
        /// <param name="newID">The new ID.</param>
        /// <param name="newTeam">The new team.</param>
        public Character(Vector2 newLocation, CharacterDefinition newCharDef, int newID, int newTeam)
        {
            script = new Script(this);
            Ai = null;
            
            Location = newLocation;
            Trajectory = new Vector2();
            ID = newID;
            Team = newTeam;
            Face = CharacterDirection.Right;
            Scale = 0.5f;
            characterDefinition = newCharDef;

            NoLifty = false;
          
            InitScript();
            
            Ethereal = false;
            AnimationName = "";
            SetAnim("fly");

            State = CharacterState.Air;

            
        }
        #endregion

        /// <summary>
        /// Initiliazes a character. Gets all Scripts from the "init" Animation
        /// and sets values like HP, Speed or AI Script.
        /// This method has been verified!
        /// </summary>
        private void InitScript()
        {
            SetAnim("init");
            if (AnimationName == "init")
            {
                for (int i = 0; i < characterDefinition.Animations[Animation].KeyFrames.Length; i++)
                {
                    if (characterDefinition.Animations[Animation].KeyFrames[i].FrameReference > -1)
                        script.DoScript(Animation, i);
                }
            }
        }

        /// <summary>
        /// Sets a new animation.
        /// This method has been verified!
        /// </summary>
        /// <param name="newAnim">The new anim.</param>
        public void SetAnim(string newAnim)
        {
            if (AnimationName != newAnim)
            {
                for (int i = 0; i < characterDefinition.Animations.Length; i++)
                {
                    if (characterDefinition.Animations[i].Name == newAnim)
                    {
                        for (int t = 0; t < GotoGoal.Length; t++)
                            GotoGoal[t] = -1;


                        floating = false;
                        Animation = i;
                        AnimationFrame = 0;
                        frame = 0f;
                        AnimationName = newAnim;
                        CanCancel = false;
                        Ethereal = false;

                        if (keyLeft)
                            Face = CharacterDirection.Left;
                        if (keyRight)
                            Face = CharacterDirection.Right;

                    }

                }
            }
            //if (AnimationName == newAnim)
            //    return;
            //for (int i = 0; i < characterDefinition.Animations.Length; i++)
            //{
            //    if (characterDefinition.Animations[i].Name == newAnim)
            //    {
            //        Animation = i;
            //        AnimationFrame = 0;
            //        frame = 0;
            //        AnimationName = newAnim;
            //        Ethereal = false;
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// Sets the frame.
        /// Actually who calls this method???
        /// This method has been verified!
        /// </summary>
        /// <param name="newFrame">The new frame.</param>
        public void SetFrame(int newFrame)
        {
            AnimationFrame = newFrame;
            frame = 0f;
            for (int i = 0; i < GotoGoal.Length; i++)
                GotoGoal[i] = -1;
            CanCancel = false;
        }


        /// <summary>
        /// Updates the Character, checks for collision and handles input.
        /// This method has been verified!
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(Map map, ParticleManager particleManager, Character[] character)
        {
            if (Ai != null)
                Ai.Update(character, ID, map);

            PressedKey = PressedKeys.None;
            if (keyAttack)
            {
                PressedKey = PressedKeys.Attack;
                if (keyUp) PressedKey = PressedKeys.Lower;
                if (keyDown) PressedKey = PressedKeys.Upper;
            }
            if (keySecondary)
            {
                PressedKey = PressedKeys.Secondary;
                if (keyUp) PressedKey = PressedKeys.SecUp;
                if (keyDown) PressedKey = PressedKeys.SecDown;
            }
            if (PressedKey > PressedKeys.None)
            {
                if (GotoGoal[(int)PressedKey] > -1)
                {
                    SetFrame(GotoGoal[(int)PressedKey]);

                    if (keyLeft)
                        Face = CharacterDirection.Left;
                    if (keyRight)
                        Face = CharacterDirection.Right;

                    PressedKey = PressedKeys.None;

                    for (int i = 0; i < GotoGoal.Length; i++)
                        GotoGoal[i] = -1;

                    frame = 0f;
                }
            }
            
            if (StunFrame > 0f)
                StunFrame -= RuinExplorersMain.FrameTime;

            #region update dying
            if (DyingFrame > -1f)
            {
                DyingFrame += RuinExplorersMain.FrameTime;
            }
            #endregion
            
            #region Update Animation
            if (DyingFrame < 0)
            {
                Animation animation = characterDefinition.Animations[Animation];
                KeyFrame keyFrame = animation.KeyFrames[AnimationFrame];

                frame += RuinExplorersMain.FrameTime * 30.0f;

                if (frame > (float)keyFrame.Duration)
                {
                    int pframe = AnimationFrame;

                    script.DoScript(Animation, AnimationFrame);
                    CheckTrigger(particleManager);

                    frame -= (float)keyFrame.Duration;
                    if (AnimationFrame == pframe)
                        AnimationFrame++;

                    keyFrame = animation.KeyFrames[AnimationFrame];

                    if (AnimationFrame >=
                        animation.KeyFrames.Length)
                        AnimationFrame = 0;
                }

                if (keyFrame.FrameReference < 0)
                    AnimationFrame = 0;

                if (AnimationName == "jhit")
                {
                    if (Trajectory.Y > -100f)
                        SetAnim("jmid");
                }                
            }

            #endregion

            #region Collision with other characters
            for (int i = 0; i < character.Length; i++)
            {
                if (i != ID)
                {
                    if (character[i] != null)
                    {
                        if (!Ethereal && !character[i].Ethereal)
                        {
                            if (Location.X > character[i].Location.X - 90f * character[i].Scale &&
                         Location.X < character[i].Location.X + 90f * character[i].Scale &&
                         Location.Y > character[i].Location.Y - 120f * character[i].Scale &&
                         Location.Y < character[i].Location.Y + 10f * character[i].Scale)
                            {
                                float dif = (float)Math.Abs(Location.X - character[i].Location.X);
                                dif = 180f * character[i].Scale - dif;
                                dif *= 2f;
                                if (Location.X < character[i].Location.X)
                                {
                                    CollisionMove = -dif;
                                    character[i].CollisionMove = dif;
                                }
                                else
                                {
                                    CollisionMove = dif;
                                    character[i].CollisionMove = -dif;
                                }
                            }
                        }                     
                    }
                }
            }

            if (CollisionMove > 0f)
            {
                CollisionMove -= 400f * RuinExplorersMain.FrameTime;
                if (CollisionMove < 0f)
                    CollisionMove = 0f;
            }
            if (CollisionMove < 0f)
            {
                CollisionMove += 400f * RuinExplorersMain.FrameTime;
                if (CollisionMove > 0f)
                    CollisionMove = 0f;
            }
            #endregion

            #region Update Location by Trajectory
            Vector2 previousLocation = new Vector2(Location.X, Location.Y);

            if (State == CharacterState.Ground || (State == CharacterState.Air && floating))
            {
                if (Trajectory.X > 0f)
                {
                    Trajectory.X -= RuinExplorersMain.Friction * RuinExplorersMain.FrameTime;
                    if (Trajectory.X < 0f)
                        Trajectory.X = 0f;
                }
                if (Trajectory.X < 0f)
                {
                    Trajectory.X += RuinExplorersMain.Friction * RuinExplorersMain.FrameTime;
                    if (Trajectory.X > 0f)
                        Trajectory.X = 0f;
                }
            }

            Location.X += Trajectory.X * RuinExplorersMain.FrameTime;
            Location.X += CollisionMove * RuinExplorersMain.FrameTime;

            if (State == CharacterState.Air)
            {
                Location.Y += Trajectory.Y * RuinExplorersMain.FrameTime;               
            }
            #endregion

            #region Collision detection
            if (State == CharacterState.Air)
            {
                #region Air State
                if (floating)
                {
                    Trajectory.Y += RuinExplorersMain.FrameTime * RuinExplorersMain.Gravity * 0.5f;
                    if (Trajectory.Y > 100f) Trajectory.Y = 100f;
                    if (Trajectory.Y < -100f) Trajectory.Y = -100f;

                }
                else
                    Trajectory.Y += RuinExplorersMain.FrameTime * RuinExplorersMain.Gravity;

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

                                    if (map.Legdes[i].isHardLedge == (int)LedgeFlags.Solid
                                        &&
                                        Location.Y >= fY)
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

                #region Land on col
                if (State == CharacterState.Air)
                {
                    if (Trajectory.Y > 0f)
                    {
                        if (map.CheckCollision(new Vector2(Location.X, Location.Y + 15f)))
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
                        Location.Y = map.GetLedgeYLocation(ledgeAttach,
                            map.GetLedgeSection(ledgeAttach, Location.X), Location.X);
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
            if (AnimationName == "idle" || AnimationName == "run" ||
                (State == CharacterState.Ground && CanCancel))
            {
                if (AnimationName == "idle" || AnimationName == "run")
                {
                    if (keyLeft)
                    {
                        SetAnim("run");
                        Trajectory.X = -Speed;
                        Face = CharacterDirection.Left;
                    }
                    else if (keyRight)
                    {
                        SetAnim("run");
                        Trajectory.X = Speed;
                        Face = CharacterDirection.Right;
                    }
                    else
                    {
                        SetAnim("idle");
                    }
                }
                if (keyAttack)
                {
                    SetAnim("attack");
                }
                if (keySecondary)
                {
                    SetAnim("second");
                }
                if (keyJump)
                {
                    SetAnim("jump");
                }
                if (RightAnalog.X > 0.2f || RightAnalog.X < -0.2f)
                {
                    SetAnim("roll");
                    if (AnimationName == "roll")
                    {
                        if (RightAnalog.X > 0f)
                            Face = CharacterDirection.Right;
                        else
                            Face = CharacterDirection.Left;
                    }
                }
            }

            if (AnimationName == "fly" ||
                (State == CharacterState.Air && CanCancel))
            {
                if (keyLeft)
                {
                    Face = CharacterDirection.Left;
                    if (Trajectory.X > -Speed)
                        Trajectory.X -= 500f * RuinExplorersMain.FrameTime;
                }
                if (keyRight)
                {
                    Face = CharacterDirection.Right;
                    if (Trajectory.X < Speed)
                        Trajectory.X += 500f * RuinExplorersMain.FrameTime;
                }
                if (keySecondary)
                {
                    SetAnim("fsecond");
                }
                if (keyAttack)
                {
                    SetAnim("fattack");
                }
            }

            #endregion
        }


        /// <summary>
        /// Gets the trigger by checking all parts with an index >= 1000.
        /// All Triggers have values between 1-25 (constants defined in the Character class)
        /// and are set to index + 1000. So we deduct 1000 from the part index and get back
        /// the original constant trigger. We then give this trigger index to FireTrigger method.
        /// This method has been verified!
        /// </summary>
        /// <param name="particleManager">The particle manager.</param>
        private void CheckTrigger(ParticleManager particleManager)
        {
            int frameIndex = characterDefinition.Animations[Animation].KeyFrames[AnimationFrame].FrameReference;

            Frame frame = characterDefinition.Frames[frameIndex];

            for (int i = 0; i < frame.Parts.Length; i++)
            {
                Part part = frame.Parts[i];
                if (part.Index >= 1000)
                {
                    Vector2 location = part.Location * Scale + Location;

                    if (Face == CharacterDirection.Left)
                        location.X -= part.Location.X * Scale * 2.0f;

                    FireTrigger(part.Index - 1000, location, particleManager);
                }
            }
        }

        /// <summary>
        /// Gets a Trigger and it's location and then usually creates new Particles,
        /// plays sound and set screen shake.
        /// This method has been verified!
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <param name="location">The location.</param>
        /// <param name="particleManager">The particle manager.</param>
        private void FireTrigger(int trigger, Vector2 location, ParticleManager particleManager)
        {
            switch (trigger)
            {
                case TRIG_PISTOL_ACROSS:
                case TRIG_PISTOL_UP:
                case TRIG_PISTOL_DOWN:
                    if (Team == TEAM_PLAYERS && ID < 4)
                    {
                        QuakeManager.SetRumble(ID, 1, .5f);
                        QuakeManager.SetRumble(ID, 0, .3f);
                    }
                    break;
            }

            #region Trigger Code

            switch (trigger)
            {
                case TRIG_FIRE_DIE:
                    for (int i = 0; i < 5; i++)
                    {
                        particleManager.AddParticle(new Fire(location +
                            RandomGenerator.GetRandomVector2(-30f, 30f, -30f, 30f),
                            RandomGenerator.GetRandomVector2(-5f, 60f, -150f, -20f),
                            RandomGenerator.GetRandomFloat(.3f, .8f), RandomGenerator.GetRandomInt(0, 4),
                            RandomGenerator.GetRandomFloat(.5f, .8f)));
                    }
                    particleManager.AddParticle(new Smoke(location,
                        RandomGenerator.GetRandomVector2(-10f, 10f, -60f, 10f),
                        1f, .8f, .6f, 1f, RandomGenerator.GetRandomFloat(.5f, 1.2f),
                        RandomGenerator.GetRandomInt(0, 4)));
                    particleManager.AddParticle(new Heat(location,
                        RandomGenerator.GetRandomVector2(-50f, 50f, -100f, 0f),
                        RandomGenerator.GetRandomFloat(1f, 2f)));
                    break;
                case TRIG_ROCKET:
                    particleManager.AddParticle(new Rocket(location, new Vector2((Face == CharacterDirection.Right ? 350f : -350f),
                        100f), ID));
                    break;
                case TRIG_PISTOL_ACROSS:
                    particleManager.MakeBullet(location, new Vector2(2000f, 0f), Face, ID);
                    Sound.PlayCue("revol");
                    QuakeManager.SetQuake(0.3f);
                    break;
                case TRIG_PISTOL_DOWN:
                    particleManager.MakeBullet(location, new Vector2(1400f, 1400f), Face, ID);
                    Sound.PlayCue("revol");
                    QuakeManager.SetQuake(0.3f);
                    break;
                case TRIG_PISTOL_UP:
                    particleManager.MakeBullet(location, new Vector2(1400f, -1400f), Face, ID);
                    Sound.PlayCue("revol");
                    QuakeManager.SetQuake(0.3f);
                    break;
                case TRIG_BLOOD_SQUIRT_BACK:
                case TRIG_BLOOD_SQUIRT_DOWN:
                case TRIG_BLOOD_SQUIRT_DOWN_BACK:
                case TRIG_BLOOD_SQUIRT_DOWN_FORWARD:
                case TRIG_BLOOD_SQUIRT_FORWARD:
                case TRIG_BLOOD_SQUIRT_UP:
                case TRIG_BLOOD_SQUIRT_UP_BACK:
                case TRIG_BLOOD_SQUIRT_UP_FORWARD:
                    double r = 0.0;
                    switch (trigger)
                    {
                        case TRIG_BLOOD_SQUIRT_FORWARD:
                            r = 0.0;
                            break;
                        case TRIG_BLOOD_SQUIRT_DOWN_FORWARD:
                            r = Math.PI * .25;
                            break;
                        case TRIG_BLOOD_SQUIRT_DOWN:
                            r = Math.PI * .5;
                            break;
                        case TRIG_BLOOD_SQUIRT_DOWN_BACK:
                            r = Math.PI * .75;
                            break;
                        case TRIG_BLOOD_SQUIRT_BACK:
                            r = Math.PI;
                            break;
                        case TRIG_BLOOD_SQUIRT_UP_BACK:
                            r = Math.PI * 1.25;
                            break;
                        case TRIG_BLOOD_SQUIRT_UP:
                            r = Math.PI * 1.5;
                            break;
                        case TRIG_BLOOD_SQUIRT_UP_FORWARD:
                            r = Math.PI * 1.75;
                            break;
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        particleManager.AddParticle(new Blood(location, new Vector2(
                            (float)Math.Cos(r) * (Face == CharacterDirection.Right ? 1f : -1f),
                            (float)Math.Sin(r)
                            ) * RandomGenerator.GetRandomFloat(10f, 500f) +
                            RandomGenerator.GetRandomVector2(-90f, 90f, -90f, 90f),
                            0.3f, 0f, 0f, 1f, RandomGenerator.GetRandomFloat(0.1f, 0.5f),
                            RandomGenerator.GetRandomInt(0, 4)));
                    }
                    particleManager.AddParticle(new BloodDust(location,
                        RandomGenerator.GetRandomVector2(-30f, 30f, -30f, 30f),
                        0.3f, 0f, 0f, .2f,
                        RandomGenerator.GetRandomFloat(.25f, .5f),
                        RandomGenerator.GetRandomInt(0, 4)));
                    break;
                case TRIG_BLOOD_CLOUD:
                    particleManager.AddParticle(new BloodDust(location,
                        RandomGenerator.GetRandomVector2(-30f, 30f, -30f, 30f),
                        0.3f, 0f, 0f, .4f,
                        RandomGenerator.GetRandomFloat(.25f, .75f),
                        RandomGenerator.GetRandomInt(0, 4)));
                    break;
                case TRIG_BLOOD_SPLAT:
                    for (int i = 0; i < 6; i++)
                    {
                        particleManager.AddParticle(new BloodDust(location,
                        RandomGenerator.GetRandomVector2(-30f, 30f, -30f, 30f),
                        0.3f, 0f, 0f, .4f,
                        RandomGenerator.GetRandomFloat(.025f, .125f),
                        RandomGenerator.GetRandomInt(0, 4)));
                    }
                    break;
                default:
                    particleManager.AddParticle(new Hit(location, new Vector2(
                        200f * (float)Face - 100f, 0f),
                        ID, trigger));
                    break;
            }
            #endregion
        }


        /// <summary>
        /// Checks for x-based collisions.
        /// This method has been verified!
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="pLoc">The previous location.</param>
        public void CheckXCollision(Map map, Vector2 pLocation)
        {
            if (Trajectory.X + CollisionMove > 0f)
                if (map.CheckCollision(new Vector2(Location.X + 25f, Location.Y - 15f)))
                    Location.X = pLocation.X;
            if (Trajectory.X + CollisionMove < 0f)
                if (map.CheckCollision(new Vector2(Location.X - 25f, Location.Y - 15f)))
                    Location.X = pLocation.X;            
        }

        
        /// <summary>
        /// Compares if a Particle is within a characters bounds.
        /// Essentially this is the bounding box around the character.
        /// I did modify the .X values from 110f to 60f because 
        /// bullets would explode even before hitting a zombie.
        /// This method has been verified!
        /// </summary>
        /// <param name="hitLocation">The hit location.</param>
        /// <returns></returns>
        public bool InHitBounds(Vector2 hitLocation)
        {
            if (hitLocation.X > Location.X - 60f * Scale &&
                hitLocation.X < Location.X + 60f * Scale &&
                hitLocation.Y > Location.Y - 190f * Scale &&
                hitLocation.Y < Location.Y + 10f * Scale)
                return true;

            return false;
        }

        /// <summary>
        /// When no ledges or collision cells are beneath the character
        /// set anim to fly and reset his trajectory.Y.
        /// This method has been verified!
        /// </summary>
        public void FallOff()
        {
            State = CharacterState.Air;
            SetAnim("fly");
            Trajectory.Y = 0f;
            if (Trajectory.X > 300f)
                Trajectory.X = 300f;
            if (Trajectory.X < -300f)
                Trajectory.X = -300f;
        }

        /// <summary>
        /// Character lands on collision cell or ledge - set animation and characterState
        /// This method has been verified!
        /// </summary>
        public void Land()
        {
            State = CharacterState.Ground;

            switch (AnimationName)
            {
                case "jhit":
                case "jmid":
                case "jfall":
                    SetAnim("hitland");
                    if (HP < 0)
                        SetAnim("dieland");
                    break;
                default:
                    SetAnim("land");
                    break;                
            }
        }

        /// <summary>
        /// Kills me. We could add lines here to create coins left
        /// behind by enemies.
        /// This method has been verified!
        /// </summary>
        public void KillMe()
        {
            if (DyingFrame < 0f)
                DyingFrame = 0f;
        }

        /// <summary>
        /// Set via script. Slides the character in facing x-direction.
        /// This method has been verified!
        /// </summary>
        /// <param name="distance">The distance to slide the character (set by script).</param>
        public void Slide(float distance)
        {
            Trajectory.X = (float)Face * 2f * distance - distance;
        }


        /// <summary>
        /// Moves a character into the air by setting his trajectory.Y
        /// This method has been verified!
        /// </summary>
        /// <param name="jump">The jump.</param>
        public void SetJump(float jump)
        {
            Trajectory.Y = -jump;
            State = CharacterState.Air;
            ledgeAttach = -1;
        }

        /// <summary>
        /// Draws the character. Needs to be adjusted depending on texture setup.
        /// This method has been verified!
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

                if (part.Index > -1 && part.Index < 1000)
                {
                    sRect.X = ((part.Index % 64) % 5) * 64;
                    sRect.Y = ((part.Index % 64) / 5) * 64;
                    sRect.Width = 64;
                    sRect.Height = 64;

                    if (part.Index >= 192)
                    {
                        // I commented the original line out and added another for Y coordinates
                        // I think it should be correct now - maybe the book was wrong?
                        //sourceRect.X = ((part.Index % 64) % 3) * 80;                       
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
                        default:
                            texture = null;
                            break;
                    }

                    Color color = new Color(new
                        Vector4(1.0f, 1.0f, 1.0f, 1f));

                    if (DyingFrame > 0f)
                        color = new Color(new Vector4(
                            1f - DyingFrame,
                            1f - DyingFrame,
                            1f - DyingFrame,
                            1f - DyingFrame));

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
        /// This method has been verified!
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
        /// Handles input for Gamepad and / or Keyboard.
        /// This method has been verified!
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

            RightAnalog = currentGamepadState.ThumbSticks.Right;

            if ((currentGamepadState.Buttons.A == ButtonState.Pressed &&
                previousGamepadState.Buttons.A == ButtonState.Released) || currentKeyboardState.IsKeyDown(Keys.Space))
                keyJump = true;

            if ((currentGamepadState.Buttons.X == ButtonState.Pressed &&
                previousGamepadState.Buttons.X == ButtonState.Released) || currentKeyboardState.IsKeyDown(Keys.X))
                keyAttack = true;

            if ((currentGamepadState.Buttons.B == ButtonState.Pressed &&
                previousGamepadState.Buttons.B == ButtonState.Released) || currentKeyboardState.IsKeyDown(Keys.C))
                keySecondary = true;
                        
            previousGamepadState = currentGamepadState;            
        }
        #endregion
    }
}

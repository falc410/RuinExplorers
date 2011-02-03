using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.CharacterClasses;
using RuinExplorers.MapClasses;
using Microsoft.Xna.Framework;

namespace RuinExplorers.GUI
{
    class HUD
    {
        SpriteBatch spriteBatch;
        Texture2D spritesTexture;
        Texture2D nullTexture;

        Character[] characters;

        Map map;

        ScoreDraw scoreDraw;

        float heartFrame;
        float fHP;

        public HUD(SpriteBatch spriteBatch, Texture2D spritesTexture, Texture2D nullTexture, Character[] characters, Map map)
        {
            this.spriteBatch = spriteBatch;
            this.spritesTexture = spritesTexture;
            this.nullTexture = nullTexture;
            this.characters = characters;
            this.map = map;
            scoreDraw = new ScoreDraw(spriteBatch, spritesTexture);
        }

        public void Update()
        {
            heartFrame += RuinExplorersMain.FrameTime;
            if (heartFrame > 6.28f)
                heartFrame -= 6.28f;

            if (characters[0].HP > fHP)
            {
                fHP += RuinExplorersMain.FrameTime * 15f;
                if (fHP > characters[0].HP)
                    fHP = characters[0].HP;
            }

            if (characters[0].HP < fHP)
            {
                fHP -= RuinExplorersMain.FrameTime * 15f;
                if (fHP < characters[0].HP)
                    fHP = characters[0].HP;
            }


        }

        public void Draw()
        {
            spriteBatch.Begin();

            scoreDraw.Draw(RuinExplorersMain.Score, new Vector2(50f, 78f), Color.White, Justification.Left);

            float fProg = fHP / characters[0].MHP;
            float prog = characters[0].HP / characters[0].MHP;
            fProg *= 5f;
            prog *= 5f;
            for (int i = 0; i < 5; i++)
            {
                float r = (float)Math.Cos((double)heartFrame * 2.0 + (double)i) * 0.1f;

                spriteBatch.Draw(spritesTexture, new Vector2(66f + (float)i * 32f, 66f),
                    new Rectangle(i * 32, 192, 32, 32),
                    new Color(new Vector4(0.5f, 0f, 0f, 0.25f)), r, new Vector2(16f, 16f), 1.25f,
                    SpriteEffects.None, 1f);

                float ta = fProg - (float)i;
                if (ta > 1f)
                    ta = 1f;
                if (ta > 0f)
                {
                    spriteBatch.Draw(spritesTexture, new Vector2(66f + (float)i * 32f, 66f),
                        new Rectangle(i * 32, 192, (int)(32f * ta), 32),
                        new Color(new Vector4(0.9f, 0f, 0f, 1f)), r, new Vector2(16f, 16f), 1.25f,
                        SpriteEffects.None, 1f);
                }
            }

            // If we are in a transition state draw the whole map overlayed by our nulltexture with specific alpha
            float screenAlpha = map.GetTransitionValue();
            if (screenAlpha > 0f)
            {
                spriteBatch.Draw(nullTexture, new Rectangle(0, 0, (int)RuinExplorersMain.ScreenSize.X, (int)RuinExplorersMain.ScreenSize.Y),
                    new Color(new Vector4(0f, 0f, 0f, screenAlpha)));
            }

            spriteBatch.End();
        }
    }
}

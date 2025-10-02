using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DA315A_Space_Invaders_V1
{
    public class Player
    {
        private Texture2D playerSprite;
        private Vector2 playerPosition;
        private int playerSpeedX = 0;
        private int windowWidth;
        private int shootCooldown = 20;
        private int shootTimer = 0;

        public Player(Texture2D playerSprite, Vector2 playerPosition, int windowWidth)
        {
            this.playerSprite = playerSprite;
            this.playerPosition = playerPosition;
            this.windowWidth = windowWidth;
        }

        public void Update(List<Bullet> bulletList, Texture2D bulletSprite)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shootTimer <= 0)
            {
                bulletList.Add(new Bullet(bulletSprite, new Vector2(playerPosition.X + playerSprite.Width / 2 - bulletSprite.Width / 2, playerPosition.Y - bulletSprite.Height)));
                shootTimer = shootCooldown;
            }
            else
            {
                shootTimer -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                playerSpeedX = 5;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                playerSpeedX = -5;
            }
            else
            {
                playerSpeedX = 0;
            }

            float nextX = playerPosition.X + playerSpeedX;

            if ((nextX < 0 || nextX + playerSprite.Width > windowWidth) == false)
            {
                playerPosition.X += playerSpeedX;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerSprite, playerPosition, Color.White);
        }
    }
}

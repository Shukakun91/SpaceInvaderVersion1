using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DA315A_Space_Invaders
{
    public class Player
    {
        private Texture2D playerSprite;
        private Vector2 playerPosition;
        private int playerSpeedX = 0;
        private int windowWidth;

        public Player(Texture2D playerSprite, Vector2 playerPosition, int windowWidth)
        {
            this.playerSprite = playerSprite;
            this.playerPosition = playerPosition;
            this.windowWidth = windowWidth;
        }

        public void Update()
        {
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

            if ((nextX < 0 || (nextX + playerSprite.Width) > windowWidth) == false)
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Space_Invaders_V1
{
    public class Bullet
    {
        private Texture2D bulletSprite;
        private Vector2 bulletPosition;
        private Rectangle hitbox;
        private bool outOfBounds = false;

        public Bullet(Texture2D bulletSprite, Vector2 bulletPosition)
        {
            this.bulletSprite = bulletSprite;
            this.bulletPosition = bulletPosition;
            hitbox = new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletSprite.Width, bulletSprite.Height);
        }

        public Rectangle GetHitbox()
        {
            hitbox.X = (int)bulletPosition.X;
            hitbox.Y = (int)bulletPosition.Y;
            return hitbox;
        }

        public float GetPositionY()
        {
            return bulletPosition.Y;
        }

        public bool IsOutOfBounds()
        {
            return outOfBounds;
        }

        public void Update()
        {
            bulletPosition.Y -= 3.0f;

            if (bulletPosition.Y < 0)
            {
                outOfBounds = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletSprite, bulletPosition, Color.White);
        }
    }
}

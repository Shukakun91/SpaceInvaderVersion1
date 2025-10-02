using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Space_Invaders_V1
{
    public class Enemy
    {
        private Texture2D enemySprite;
        private Vector2 enemyPosition;
        private Rectangle hitbox;

        public Enemy(Texture2D enemySprite, Vector2 enemyPosition)
        {
            this.enemySprite = enemySprite;
            this.enemyPosition = enemyPosition;
            hitbox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, enemySprite.Width, enemySprite.Height);
        }

        public Rectangle GetHitbox()
        {
            hitbox.X = (int)enemyPosition.X;
            hitbox.Y = (int)enemyPosition.Y;
            return hitbox;
        }

        public void Update()
        {
            enemyPosition.Y += 0.6f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemySprite, enemyPosition, Color.White);
        }
    }
}

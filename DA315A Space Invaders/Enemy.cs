using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Space_Invaders
{
    public class Enemy
    {
        private Texture2D enemySprite;
        private Vector2 enemyPosition;

        public Enemy(Texture2D enemySprite, Vector2 enemyPosition)
        {
            this.enemySprite = enemySprite;
            this.enemyPosition = enemyPosition;
        }

        public void Update()
        {
            enemyPosition.Y += 0.3f;


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemySprite, enemyPosition, Color.White);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Space_Invaders
{
    public class Bullet
    {
        private Texture2D bulletSprite;
        private Vector2 bulletPosition;

        public Bullet(Texture2D bulletSprite, Vector2 bulletPosition)
        {
            this.bulletSprite = bulletSprite;
            this.bulletPosition = bulletPosition;
        }
    }
}

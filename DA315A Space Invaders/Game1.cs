using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DA315A_Space_Invaders_V1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private HitboxManager hitboxManager;

        private int windowWidth = 736;
        private int windowHeight = 1030;
        #region Personal commentary
        /*
        Weirdly specific resolution that I haven't seen before, based on the example Space Invaders image from Canvas.
        I'm assuming that this is an old resolution, it is an old arcade game after all.
        If I were to design a similar game today, I would probably go with 1280x720.
        */
        #endregion

        private Texture2D playerSprite;
        private Texture2D enemySprite;
        private Texture2D bulletSprite;

        private int score = 0;
        private int lives = 72;
        private Player player;
        public List<Enemy> enemyList;
        public List<Bullet> bulletList;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hitboxManager = new HitboxManager();

        playerSprite = Content.Load<Texture2D>("DrMarioHead");
            enemySprite = Content.Load<Texture2D>("VirusBlue");
            bulletSprite = Content.Load<Texture2D>("Bullet");
            player = new Player(playerSprite, new Vector2((windowWidth - playerSprite.Width) / 2, windowHeight - playerSprite.Height), windowWidth);
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 24; column++)
                {
                    Vector2 nextPosition = new Vector2(6 * (column + 1) + enemySprite.Width * column, 6 * (row + 1) + enemySprite.Height * row);
                    enemyList.Add(new Enemy(enemySprite, nextPosition));
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Window.Title = "Space Invaders | Score: " + score + " | Lives: " + lives;
            player.Update(bulletList, bulletSprite);
            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].GetHitbox().Y > windowHeight)
                {
                    enemyList.RemoveAt(i);
                    lives -= 1;
                }
            }

            foreach (Bullet bullet in bulletList)
            {
                bullet.Update();
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].IsOutOfBounds())
                {
                    bulletList.RemoveAt(i);
                }
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                for (int j = 0; j < enemyList.Count; j++)
                {
                    if (hitboxManager.CheckCollision(bulletList[i].GetHitbox(), enemyList[j].GetHitbox()))
                    {
                        bulletList.RemoveAt(i);
                        enemyList.RemoveAt(j);
                        break;
                        #region Personal commentary
                        /*
                        I initially encountered an error here due to modifying the list while iterating through it. 
                        AI suggested that I add the break to exit the loop when detecting a collision.
                        This seems to have fixed the issue and the game seems to be working as intended.
                        However, am I correct in thinking that this means we can only detect a single collision per frame?
                        If so, that seems like a big enough problem that I'll probably want to use a different approach in future projects.
                        Another suggestion was to iterate backwards through the list, which makes sense.
                        At least I can't think of any way that that could cause problems.
                        */
                        #endregion
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player.Draw(spriteBatch);

            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }

            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

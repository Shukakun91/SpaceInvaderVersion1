using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DA315A_Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

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

            playerSprite = Content.Load<Texture2D>("Ship_01-1");
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
            Window.Title = "Space Invaders | Score: " + score;
            player.Update(bulletList, bulletSprite);
            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nominal.Components;
using Nominal.Engine;
using Nominal.Test;
using System.Linq;

namespace Nominal
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameObject go;
        GameObject camGo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.IsMouseVisible = true;
            
            //this.graphics.ApplyChanges();
            
            base.Initialize();

            Assets.Initialize(graphics.GraphicsDevice);

            camGo = new GameObject();
            go = new GameObject();
            camGo.AddComponent<Components.Cam.Camera>();
            SpriteRenderer rend = go.AddComponent<SpriteRenderer>();

            go.AddComponent<TestComponent>();

            GameObject go1 = new GameObject();
            SpriteRenderer rend1 = go1.AddComponent<SpriteRenderer>();

            go1.AddComponent<TestComponent>();
            go1.transform.parent = go.transform;
            go1.GetComponent<TestComponent>().o = new OrbitalMechanics.Orbit(1, 0.2, 1, 100, 2, true);

            graphics.PreferredBackBufferHeight = (int)(GraphicsDevice.DisplayMode.Height / 1.5);
            graphics.PreferredBackBufferWidth = (int)(GraphicsDevice.DisplayMode.Width / 1.5);
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Time.gameTimeUpdate = gameTime;

            GameObject.UpdateObjects();

            InputManager.LateUpdate();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Time.gameTimeDraw = gameTime;

            GraphicsDevice.Clear(new Color(0.1f, 0.1f, 0.1f));

            spriteBatch.Begin(SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp);
            GameObject.DrawObjects(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nominal.Engine;
using Nominal.Test;

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
        GameObject go2;

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
<<<<<<< HEAD
            // TODO: Add your initialization logic here

            this.IsMouseVisible = true;
            
            //this.graphics.ApplyChanges();

=======
>>>>>>> 260dbc74a6291480e064c53492d5b2d4bd77d4c8
            base.Initialize();
            go = new GameObject();

            go2 = new GameObject();
            TestComponent tc = go2.AddComponent<TestComponent>();
            go2.parent = go;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height / 2;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width / 2;

            graphics.ApplyChanges();

            System.Console.WriteLine("TestComponent: " + (tc==true));
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

            if(InputManager.GetKeyDown(Keys.Space))
            {
                go2.enabled = !go2.enabled;
            }
            if(InputManager.GetKeyDown(Keys.Enter))
            {
                go2.Destroy();
            }

            InputManager.LateUpdate();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
<<<<<<< HEAD
            GraphicsDevice.Clear(Color.Gray);
=======
            Time.gameTimeDraw = gameTime;

            GraphicsDevice.Clear(Color.Black);
>>>>>>> 260dbc74a6291480e064c53492d5b2d4bd77d4c8

            GameObject.DrawObjects(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeldaOne.Entities.Friendlies;
using ZeldaOne.Management;

namespace ZeldaOne
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RasterizerState _rasterizerState;

        private Link _link;

        private ResourceManager _resourceManager;
        
        private CameraManager _cameraManager;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _link = new Link();
            _resourceManager = new ResourceManager();
            _cameraManager = new CameraManager();
            _rasterizerState = new RasterizerState {MultiSampleAntiAlias = false};
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH * Settings.GENERAL_SCALE;
            _graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT * Settings.GENERAL_SCALE;
            _graphics.PreferMultiSampling = true;
            _graphics.GraphicsDevice.PresentationParameters.MultiSampleCount = 8;
            _graphics.ApplyChanges();

            _link.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
         
            _resourceManager.LoadAllTextures(Content);

            _link.LoadContent(Content);

            _cameraManager.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            GamePadManager.GamePadState = GamePad.GetState(PlayerIndex.One);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _link.Update(gameTime);
            
            _cameraManager.Update(gameTime);
            
            GamePadManager.OldGamePadState = GamePadManager.GamePadState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(
                SpriteSortMode.Immediate,
                null,
                SamplerState.PointClamp,
                DepthStencilState.Default,
                _rasterizerState
                );
            _cameraManager.Draw(_spriteBatch);
            _link.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

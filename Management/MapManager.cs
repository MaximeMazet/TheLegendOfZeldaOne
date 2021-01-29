using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaOne.Management
{
    public class MapManager
    {
        private Texture2D _texture;
        private readonly Color _color;
        private Rectangle _sourceRectangle;
        private Vector2 _position;
        private readonly Vector2 _scale;
        private readonly Vector2 _spawnArea;
        private Vector2 _origin;

        public MapManager(Vector2 spawnArea)
        {
            _color = Color.White;
            _scale = new Vector2(2, 2);
            _spawnArea = spawnArea;
        }

        public void LoadContent()
        {
            _texture = ResourceManager.Textures["map_overworld"];
            _sourceRectangle.Width = _texture.Width / 16;
            _sourceRectangle.Height = _texture.Height / 8;
            _sourceRectangle.X = (int)_spawnArea.X * _sourceRectangle.Width;
            _sourceRectangle.Y = (int)_spawnArea.Y * _sourceRectangle.Height;
            _position.X = 0;
            _position.Y = Settings.SCREEN_HEIGHT + (Settings.GAMEPLAY_HEIGHT + 63);
            _origin = new Vector2(0, Settings.GAMEPLAY_HEIGHT);
        }

        public void Update(GameTime gameTime)
        {
        }

        private void changeArea()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _sourceRectangle, _color, 0f, _origin, _scale, SpriteEffects.None, 0);
        }
    }
}
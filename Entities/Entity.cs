using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaOne.Entities
{
    public class Entity
    {

        private int _cols;
        private int _rows;
        private int _width;
        private int _height;
        protected float _speed;
        private string _path;
        private float _rotation;
        private int _currentFrameX;
        protected int _currentFrameY;

        private Color _color;
        private Vector2 _scale;
        private Vector2 _origin;
        protected Vector2 _position;
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
        protected SpriteEffects _spriteEffect;
        private Rectangle _destinationRectangle;

        protected Entity(string path, Vector2 startPosition, int rows, int cols)
        {
            _color = Color.White;
            _rotation = 0.0f;
            _spriteEffect = SpriteEffects.None;
            _scale = new Vector2(1.5f, 1.5f);
            _path = path;
            _position = startPosition;
            _cols = cols;
            _rows = rows;
            _currentFrameX = 0;
            _currentFrameY = 0;
            _speed = 100.0f;
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("graphics/" + _path);
            _width = _texture.Width / _cols;
            _height = _texture.Height / _rows;
            _origin.X = _width / 2;
            _origin.Y = _height / 2;
            _destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            _sourceRectangle = new Rectangle(0, 0, _width, _height);
        }

        public virtual void Update(GameTime gameTime)
        {
            _sourceRectangle.Y = _currentFrameY * _height;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _sourceRectangle, _color, _rotation, _origin, _scale, _spriteEffect, 0);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaOne.Management;

namespace ZeldaOne.Entities
{
    public class Entity
    {
        protected int _currentFrameY;
        
        protected float _speed;
        protected float _animationSpeed;
        
        protected bool _canWalk;

        protected SpriteEffects _spriteEffect;

        
        
        private int _cols;
        private int _rows;
        private int _width;
        private int _height;
        private int _maxFrameX;
        private int _maxFrameY;
        private int _currentFrameX;
        
        
        private string _path;
        
        private float _timer;
        private float _rotation;

        private Color _color;
        private Vector2 _scale;
        private Vector2 _origin;
        private Vector2 _position;
        private Vector2 _velocity;
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
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
            _velocity = new Vector2(0, 0);
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            _texture = ResourceManager.Textures[_path];
            _width = _texture.Width / _cols;
            _height = _texture.Height / _rows;
            _maxFrameX = (_texture.Width / _width) - 1;
            _maxFrameY = (_texture.Height / _height) - 1;
            _origin.X = _width / 2;
            _origin.Y = _height / 2;
            _destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            _sourceRectangle = new Rectangle(0, 0, _width, _height);
        }

        public virtual void Update(GameTime gameTime)
        {
            _sourceRectangle.Y = _currentFrameY * _height;
            _sourceRectangle.X = _currentFrameX * _width;
            _position += _velocity;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _sourceRectangle, _color, _rotation, _origin, _scale, _spriteEffect, 0);
        }

        protected void Animate(string axe, GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (axe.ToLower() == "x")
            {
                if (_timer >= _animationSpeed)
                {
                    if (_currentFrameX == _maxFrameX)
                        _currentFrameX = 0;
                    else
                        _currentFrameX++;
                    
                    _timer = 0;
                }
            }
            else
            {
                if (_timer >= _animationSpeed)
                {
                    if (_currentFrameY == _maxFrameY)
                        _currentFrameY = 0;
                    else
                        _currentFrameY++;
                    
                    _timer = 0;
                }
            }
        }

        protected void ResetAnimation(string axe)
        {
            if (axe.ToLower() == "x")
            {
                _currentFrameX = 0;
            }
            else
            {
                _currentFrameY = 0;
            }
        }

        protected void Movement(float speedX, float speedY)
        {
            if (_canWalk)
            {
                _velocity.X = speedX;
                _velocity.Y = speedY;
            }
        }
    }
}
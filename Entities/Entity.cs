using System;
using System.Threading;
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
        protected float _animationWalkSpeed;
        protected float _animationAttackSpeed;
        
        protected bool _canWalk;
        protected bool _attack;

        protected SpriteEffects _spriteEffect;

        
        
        private int _cols;
        private int _rows;
        private int _width;
        private int _height;
        private int _maxFrameX;
        private int _maxFrameY;
        private int _currentFrameX;
        
        
        private string _resourceName;
        
        private float _timer;
        private float _rotation;

        private Color _color;
        private Vector2 _scale;
        private Vector2 _origin;
        private Vector2 _hitbox;
        private Vector2 _position;
        private Vector2 _velocity;
        private Texture2D _texture;
        private Rectangle _sourceRectangle;

        private ContentManager _contentManager;

        protected Entity(string resourceName, Vector2 startPosition, int rows, int cols, Vector2 hitbox)
        {
            _color = Color.White;
            _rotation = 0.0f;
            _spriteEffect = SpriteEffects.None;
            _scale = new Vector2(2f, 2f);
            _resourceName = resourceName;
            _position = startPosition;
            _cols = cols;
            _rows = rows;
            _currentFrameX = 0;
            _currentFrameY = 0;
            _speed = 100.0f;
            _velocity = new Vector2(0, 0);
            _hitbox = hitbox;
            _timer = 0.0f;
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            _texture = ResourceManager.Textures[_resourceName];
            _width = _texture.Width / _cols;
            _height = _texture.Height / _rows;
            _maxFrameX = (_texture.Width / _width) - 1;
            _maxFrameY = (_texture.Height / _height) - 1;
            _origin.X = (float)_width / 2;
            _origin.Y = (float)_height / 2;
            _sourceRectangle = new Rectangle(0, 0, _width, _height);
            _contentManager = contentManager;
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

        private void Animate(string axe, GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (axe.ToLower() == "x")
            {
                if (_timer >= _animationWalkSpeed)
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
                if (_timer >= _animationWalkSpeed)
                {
                    if (_currentFrameY == _maxFrameY)
                        _currentFrameY = 0;
                    else
                        _currentFrameY++;
                    
                    _timer = 0;
                }
            }
        }

        protected void ChangeTexture(string textureName, int cols, int rows)
        {
            _resourceName = textureName;
            _rows = rows;
            _cols = cols;
            LoadContent(_contentManager);
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

            _timer = 0;
        }

        protected void Movement(GameTime gameTime, float speedX, float speedY)
        {
            if (_canWalk)
                Animate("x", gameTime);
            _velocity.X = speedX;
            _velocity.Y = speedY;
        }

        protected void Attack(GameTime gameTime)
        {
            _canWalk = false;
            if (_resourceName != "player_attack")
            {
                ChangeTexture("player_attack", 4, 3);
            }
            
            _timer += gameTime.ElapsedGameTime.Milliseconds;

            if (_timer >= _animationAttackSpeed)
            {
                _currentFrameX++;
                _timer = 0;
            }

            if (_currentFrameX == _maxFrameX)
            {
                _attack = false;
                ChangeTexture("player_movement", 2, 3);
                ResetAnimation("x");
                _canWalk = true;
            }
        }
    }
}
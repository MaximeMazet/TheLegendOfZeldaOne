using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeldaOne.Management;

namespace ZeldaOne.Entities.Friendlies
{
    public class Link : Entity
    {

        private bool _isSword;

        public Link()
            : base("player_movement", new Vector2((float)Settings.SCREEN_WIDTH, (float)Settings.SCREEN_HEIGHT), 3, 2, new Vector2(32, 32))
        {
            _isSword = true;
            _canWalk = true;
            _animationWalkSpeed = 200;
            _animationAttackSpeed = 100;
            _attack = false;
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_canWalk)
            {
                if (GamePadManager.ButtonPressedContinue(Buttons.DPadUp))
                {
                    Movement(gameTime, 0,-(_speed * delta));
                    _currentFrameY = 2;
                    _spriteEffect = SpriteEffects.None;
                }
                else if (GamePadManager.ButtonPressedContinue(Buttons.DPadDown))
                {
                    Movement(gameTime, 0,_speed * delta);
                    _currentFrameY = 0;
                    _spriteEffect = SpriteEffects.None;
                }
                else if (GamePadManager.ButtonPressedContinue(Buttons.DPadRight))
                {
                    Movement(gameTime, _speed * delta,0);
                    _currentFrameY = 1;
                    _spriteEffect = SpriteEffects.None;
                }
                else if (GamePadManager.ButtonPressedContinue(Buttons.DPadLeft))
                {
                    Movement(gameTime, -(_speed * delta),0);
                    _currentFrameY = 1;
                    _spriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    Movement(gameTime, 0,0);
                    ResetAnimation("x");
                }
            }
            else
            {
                Movement(gameTime, 0,0);
            }

            if (_attack)
            {
                Attack(gameTime);
            }
            
            if (GamePadManager.ButtonPressedContinue(Buttons.A) && _isSword && !_attack)
            {
                _attack = true;
            }
            
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
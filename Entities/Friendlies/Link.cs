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
        : base("graphics/player/player_movement", new Vector2(100,100), 3, 2)
        {
            _isSword = true;
            _canWalk = true;
            _animationSpeed = 200;
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
            if (GamePadManager.ButtonPressedContinue(Buttons.DPadUp))
            {
                Movement(0,-(_speed * delta));
                _currentFrameY = 2;
                _spriteEffect = SpriteEffects.None;
                Animate("x", gameTime);
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadDown))
            {
                Movement(0,_speed * delta);
                _currentFrameY = 0;
                _spriteEffect = SpriteEffects.None;
                Animate("x", gameTime);
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadRight))
            {
                Movement(_speed * delta,0);
                _currentFrameY = 1;
                _spriteEffect = SpriteEffects.None;
                Animate("x", gameTime);
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadLeft))
            {
                Movement(-(_speed * delta),0);
                _currentFrameY = 1;
                _spriteEffect = SpriteEffects.FlipHorizontally;
                Animate("x", gameTime);
            }
            else
            {
                Movement(0,0);
                ResetAnimation("x");
            }
            
            if (GamePadManager.ButtonPressedOnce(Buttons.B) && _isSword)
            {
                Console.WriteLine("Attack");
            }
            
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeldaOne.Management;

namespace ZeldaOne.Entities.Friendlies
{
    public class Link : Entity
    {
        public Link()
        : base("player/player_movement", new Vector2(100,100), 3, 2)
        {
            
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
                _position.Y -= _speed * delta;
                _currentFrameY = 2;
                _spriteEffect = SpriteEffects.None;
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadDown))
            {
                _position.Y += _speed * delta;
                _currentFrameY = 0;
                _spriteEffect = SpriteEffects.None;
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadRight))
            {
                _position.X += _speed * delta;
                _currentFrameY = 1;
                _spriteEffect = SpriteEffects.None;
            }
            else if (GamePadManager.ButtonPressedContinue(Buttons.DPadLeft))
            {
                _position.X -= _speed * delta;
                _currentFrameY = 1;
                _spriteEffect = SpriteEffects.FlipHorizontally;
            }
            
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
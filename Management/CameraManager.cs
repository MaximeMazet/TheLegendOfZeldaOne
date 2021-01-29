using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaOne.Management
{
    public class CameraManager
    {
        private MapManager _mapManager;
        
        public CameraManager()
        {
            _mapManager = new MapManager(new Vector2(7,7));
        }

        public void LoadContent()
        {
            _mapManager.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            _mapManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _mapManager.Draw(spriteBatch);
        }
    }
}
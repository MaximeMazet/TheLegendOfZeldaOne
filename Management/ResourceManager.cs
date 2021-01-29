using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaOne.Management
{
    public class ResourceManager
    {
        public static Dictionary<string, Texture2D> Textures;

        public ResourceManager()
        {
            Textures = new Dictionary<string, Texture2D>();
        }
        public void LoadAllTextures(ContentManager contentManager)
        {
            Textures.Add("player_movement", contentManager.Load<Texture2D>("graphics/player/player_movement"));
            Textures.Add("player_attack", contentManager.Load<Texture2D>("graphics/player/player_attack"));
        }
    }
}
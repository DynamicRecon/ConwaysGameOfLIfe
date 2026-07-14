using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConwaysGameOfLife.Utilities
{
    public class DebugOverlay
    {
        private SpriteFont _font;
        private double _fps;
        private double _elapsedTime;
        private int _frameCount;

        public double FPS => _fps;
        public double FrameCount => _frameCount;

        public DebugOverlay(SpriteFont font)
        {
            _font = font;
        }

        public void Update(GameTime gameTime)
        {
            // Calculate Frame Rate
            _elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            _frameCount++;

            if (_elapsedTime >= 1.0)
            {
                _fps = _frameCount / _elapsedTime;
                _frameCount = 0;
                _elapsedTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, string debugText)
        {
            // Draw text with a clean drop-shadow effect for readability
            spriteBatch.DrawString(_font, debugText, position + new Vector2(1, 1), Color.Black);
            spriteBatch.DrawString(_font, debugText, position, Color.LimeGreen);
        }
    }

}

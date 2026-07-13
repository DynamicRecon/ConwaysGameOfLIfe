using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ConwaysGameOfLIfe.Sprites
{
    internal class CellLife : DrawableGameComponent
    {
        private const int _CELLSIZE = 10;

        private Texture2D _pixel;
        private Color[] _pixelData;
        private Color _pixelColor;
        private Rectangle _cellForm;
        private bool _occupied;
        private SpriteBatch _spriteBatch;

        public Rectangle CellForm { set { _cellForm = value; } get { return _cellForm; } }
        public bool Occupied { set { _occupied = value; } get { return _occupied; } }

        public int CellSize => _CELLSIZE;

        public CellLife(Game game) : base(game) { }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.LoadContent();
        }

        public override void Initialize() 
        {
            _cellForm = new Rectangle(0, 0, _CELLSIZE, _CELLSIZE);
            _pixelData = new Color[_CELLSIZE * _CELLSIZE];
            _pixel = new Texture2D(Game.GraphicsDevice, CellForm.Width, CellForm.Height);
            base.Initialize(); 
        }

        public override void Update(GameTime gameTime)
        {
            if (_occupied)
            {
              for(int i = 0; i <= _pixelData.Length - 1; i++)
              {
                   _pixelData[i] = 
              }
            }

           base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (_occupied) 
            {
                _pixel.SetData(_pixelData);
                _spriteBatch.Begin();
                _spriteBatch.Draw(_pixel, _cellForm, Color.White);
                _spriteBatch.End();
            }
            
            base.Draw(gameTime);
        }
    }
}



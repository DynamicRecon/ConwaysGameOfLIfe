using ConwaysGameOfLIfe.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ConwaysGameOfLIfe
{
    public class Game1 : Game
    {
        private const int _MAXCELLS = 200;
        private const int _MAXROWS = 200;
        private const int _MAXGENERATIONS = 5;

        private GraphicsDeviceManager _graphics;
        private List<CellLife> _grid;
        private Random _rnd;
        private Color _rndColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _grid = new List<CellLife>();
            // TODO: Add your initialization logic here
            foreach(int i in Enumerable.Range(0, _MAXCELLS))
            {
                foreach(int j in Enumerable.Range(0, _MAXROWS))
                {
                    var cell = new CellLife(this);
                    cell.Occupied = false;
                    cell.Initialize();
                    Rectangle tmp = cell.CellForm;
                    tmp.X = j * cell.CellSize;
                    tmp.Y = i * cell.CellSize;
                    cell.CellForm = tmp;
                    _grid.Add(cell);
                }
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(CellLife cell in _grid)
            {
                cell.Update(gameTime);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            foreach(CellLife cell in _grid.Where(x => x.Occupied == true))
            {
                cell.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}

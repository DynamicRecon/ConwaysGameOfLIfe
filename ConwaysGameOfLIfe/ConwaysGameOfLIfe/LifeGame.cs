using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ConwaysGameOfLife.Models;
using ConwaysGameOfLife.Utilities;


namespace ConwaysGameOfLife
{
    public class LifeGame : Game
    {
        private const int _MAXCOLS = 150;
        private const int _MAXROWS = 150;
        private const int _CELLSIZE = 10;
        private const float _STARTDENSITY = 0.1f;

        private enum Screens
        {
            StartScreen,
            Simulation
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _spriteTexture;

        private CellLifeMatrix _matrix;
        private DebugOverlay _debug;
        private Screens _screenManager = Screens.StartScreen;

        private int _maxCols = 10;
        private int _maxRows = 10;
        private float _startDensity = 1.0f;

        private float _timer = 0f;
        private float _generationDelay = 0.1f;
        private int _generationCount = 0;

        private KeyboardState _curState;
        private KeyboardState _prevState;
        

       

        public LifeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            _spriteTexture = Content.Load<Texture2D>("greencell");
            _debug = new DebugOverlay(Content.Load<SpriteFont>("debugfont"));
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            _curState = Keyboard.GetState();

            switch(_screenManager)
            {
                case Screens.StartScreen:
                    if(_curState.IsKeyDown(Keys.Enter) && _prevState.IsKeyUp(Keys.Enter))
                    {
                        _matrix = new CellLifeMatrix(_maxRows, _maxCols);
                        _matrix.Initialize(_startDensity);
                        _screenManager = Screens.Simulation;
                    }
                    else if (_curState.IsKeyDown(Keys.Up) && _prevState.IsKeyUp(Keys.Up))
                    {
                        _maxRows = MathHelper.Min(_maxRows + 5, _MAXROWS);
                    } 
                    else if (_curState.IsKeyDown(Keys.Down) && _prevState.IsKeyUp(Keys.Down)) 
                    {
                        _maxRows = MathHelper.Max(_maxRows - 5, 10);
                    } 
                    else if(_curState.IsKeyDown(Keys.Left) && _prevState.IsKeyUp(Keys.Left)) 
                    { 
                        _maxCols = MathHelper.Min(_maxCols - 5, _MAXCOLS);
                    } 
                    else if (_curState.IsKeyDown(Keys.Right) && _prevState.IsKeyUp(Keys.Right)) 
                    { 
                       _maxCols = MathHelper.Max(_maxCols + 5, 10);
                    }
                    else if (_curState.IsKeyDown(Keys.W) && _prevState.IsKeyUp(Keys.W)) 
                    {

                        _startDensity = MathHelper.Min(_startDensity + 0.05f, _STARTDENSITY);
                    }
                    else if (_curState.IsKeyDown(Keys.S) && _prevState.IsKeyUp(Keys.S)) 
                    {
                        _startDensity = MathHelper.Max(_startDensity - 0.05f, 0.0f);
                    }
                    
                        break;
                case Screens.Simulation:
                    _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    while (_timer >= _generationDelay)
                    {
                        if (_curState.IsKeyDown(Keys.Escape) && _prevState.IsKeyUp(Keys.Escape))
                        {
                            _screenManager = Screens.StartScreen;
                        }
                        _matrix.Update();
                        _generationCount++;

                        _timer -= _generationDelay;


                    }
                    break;
            }

            _prevState = _curState;
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            switch(_screenManager) 
            {
                case Screens.StartScreen:
                    string menuText = "=== SIMULATION SPEC SETUP ===\n\n" +
                          $"[Left/Right] Max Cols: {_maxCols}\n" +
                          $"[Up/Down]    Max Rows: {_maxRows}\n" +
                          $"[W/S Keys]   Start Density: {_startDensity:P0}\n\n" +
                          "Press [ENTER] to Generate and Run!";
                    _debug.Draw(_spriteBatch, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), menuText);
                    break;
                case Screens.Simulation:
                    for (int x = 0; x <= _maxRows - 1; x++)
                    {
                        for (int y = 0; y <= _maxCols - 1; y++)
                        {
                            if (_matrix.CellMatrix[x, y])
                            {
                                var rect = new Rectangle(x * _CELLSIZE, y * _CELLSIZE, _CELLSIZE, _CELLSIZE);
                                _spriteBatch.Draw(_spriteTexture, rect, Color.White);
                            }
                        }
                    }
                    string prompt = "[press Escape to end simulation]\n" +
                        $"Generation Count: {_generationCount}\n";
                    _debug.Draw(_spriteBatch, Vector2.Zero, prompt);
                    break;
            
            }
            
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongTest;

public class Game1 : Game
{
    Texture2D gameBallTexture;
    Vector2 ballPosition;
    float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Ball ball;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ball = new Ball(
            1000f,
            new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight),
            Content.Load<Texture2D>("ball"));

        //ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
        //                           _graphics.PreferredBackBufferHeight / 2);

        //ballSpeed = 1000f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        //ball.BallTexture = Content.Load<Texture2D>("ball");
        //ball.LoadBall(Content.Load<Texture2D>("ball"));
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        //ballTexture = Content.Load<Texture2D>("ball");


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        //Time since update was last called
        //Every frame is a max speed of ballspeed and not more,
        //otherwise the speed goes out of hand and framerate depicts how fast the game runs
        float updateBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        //var kstate = Keyboard.GetState();

        ball.moveBall(ballPosition.Y, ballPosition.X, updateBallSpeed);

        //if (kstate.IsKeyDown(Keys.Up))
        //{
        //    ballPosition.Y -= updateBallSpeed;
        //}
        //if (kstate.IsKeyDown(Keys.Down))
        //{
        //    ballPosition.Y += updateBallSpeed;
        //}
        //if (kstate.IsKeyDown(Keys.Left))
        //{
        //    ballPosition.X -= updateBallSpeed;
        //}
        //if (kstate.IsKeyDown(Keys.Right))
        //{
        //    ballPosition.X += updateBallSpeed;
        //}

        ball.checkWindowCollision(ballPosition.Y, ballPosition.X, _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight);

        //if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
        //{
        //    ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
        //}
        //else if (ballPosition.X < ballTexture.Width / 2)
        //{
        //    ballPosition.X = 0 + ballTexture.Width /2;
        //}
        //if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
        //{
        //    ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
        //}
        //else if (ballPosition.Y < ballTexture.Height / 2)
        //{
        //    ballPosition.Y =  0 + ballTexture.Height / 2;
        //}

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        gameBallTexture = ball.BallTexture;
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            gameBallTexture,
            ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(gameBallTexture.Width /2, gameBallTexture.Height /2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
        _spriteBatch.End();

        base.Draw(gameTime);
    }

}

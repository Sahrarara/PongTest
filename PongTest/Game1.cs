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
        ball = new Ball(
            10000f,
            new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
            Content.Load<Texture2D>("ball"));


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
        float updateBallSpeed = ball.BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


        updateBallSpeed = ball.moveBall(ball.BallPosition.Y, ball.BallPosition.X, updateBallSpeed);


        ball.checkWindowCollision(ball.BallPosition.Y, ball.BallPosition.X, _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight);


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        //gameBallTexture = ball.BallTexture;
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            ball.BallTexture,
            ball.BallPosition,
            null,
            Color.White,
            0f,
            new Vector2(ball.BallTexture.Width /2, ball.BallTexture.Height /2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
        _spriteBatch.End();

        base.Draw(gameTime);
    }

}

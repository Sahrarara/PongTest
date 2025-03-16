using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Ball
{
    private float _ballSpeed;
    public float BallSpeed { get => _ballSpeed; set => _ballSpeed = value; }

    private Vector2 _ballPosition;
    public Vector2 BallPosition { get => _ballPosition; set => _ballPosition = value; }

    private Texture2D _ballTexture;
    public Texture2D BallTexture { get => _ballTexture; set => _ballTexture = value; }

    public Ball(float ballSpeed, Vector2 ballPosition, Texture2D ballTexture)
    {
        this.BallSpeed = ballSpeed;
        this.BallPosition = ballPosition;
        this.BallTexture = ballTexture;
    }

    public Ball moveBall(Ball currentBall, float ballSpeed)
    {
        var kstate = Keyboard.GetState();
        float ballPositionY = currentBall.BallPosition.Y;
        float ballPositionX = currentBall.BallPosition.X;

        if (kstate.IsKeyDown(Keys.Up))
        {
            currentBall.BallPosition = new Vector2(currentBall.BallPosition.X, ballPositionY -= ballSpeed);
        }
        if (kstate.IsKeyDown(Keys.Down))
        {
            currentBall.BallPosition = new Vector2(currentBall.BallPosition.X, ballPositionY += ballSpeed);
        }
        if (kstate.IsKeyDown(Keys.Left))
        {
            currentBall.BallPosition = new Vector2(ballPositionX -= ballSpeed, currentBall.BallPosition.Y);
        }
        if (kstate.IsKeyDown(Keys.Right))
        {
            currentBall.BallPosition = new Vector2(ballPositionX += ballSpeed, currentBall.BallPosition.Y);
        }

        //checkWindowCollision(currentBall.BallPosition.Y, currentBall.BallPosition.X, currentBall.BallTexture.Width, currentBall.BallTexture.Height);

        return currentBall;
    }

    public void checkWindowCollision (Ball currentBall,int BufferWidth,int BufferHeight)
    {
        CheckWindowCollisionX(currentBall, currentBall.BallPosition.X,BufferWidth, this.BallTexture.Width);
        CheckWindowCollisionY(currentBall, currentBall.BallPosition.Y, BufferHeight, this.BallTexture.Height);
    }

    private void CheckWindowCollisionY(Ball currentBall,float ballPositionY,int BufferHeight, float ballTextureHeight)
    {

        if (ballPositionY > BufferHeight - ballTextureHeight / 2)
        {
            currentBall.BallPosition = new Vector2(currentBall.BallPosition.X, BufferHeight - ballTextureHeight / 2);
        }
        else if (ballPositionY < ballTextureHeight / 2)
        {
            currentBall.BallPosition = new Vector2(currentBall.BallPosition.X, 0 + ballTextureHeight / 2);
        }
    }

    private void CheckWindowCollisionX(Ball currentBall,float ballPositionX, int BufferWidth, float ballTextureWidth)
    {

        if (ballPositionX > BufferWidth - ballTextureWidth / 2)
        {
            currentBall.BallPosition = new Vector2(BufferWidth - ballTextureWidth / 2, currentBall.BallPosition.Y);
        }
        else if (ballPositionX < ballTextureWidth / 2)
        {
            currentBall.BallPosition = new Vector2(0 + ballTextureWidth / 2, currentBall.BallPosition.Y);
        }
    }

}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongTest;
using System;
using System.Reflection.Metadata;

public class Ball
{
    float ballSpeed;
    private Vector2 _ballPosition;
    public Vector2 BallPosition { get => _ballPosition; set => _ballPosition = value; }

    private Texture2D _ballTexture;
    public Texture2D BallTexture { get => _ballTexture; set => _ballTexture = value; }

    public Ball(float ballSpeed, Vector2 ballPosition, Texture2D ballTexture)
    {
        this.ballSpeed = ballSpeed;
        this.BallPosition = ballPosition;
        this.BallTexture = ballTexture;
    }

    public void SpawnBall(float SpawnpositionY, float SpawnpositionX, float baseSpeed)
    {
        ballSpeed = baseSpeed;
        BallPosition = new Vector2(SpawnpositionX / 2,
                           SpawnpositionY/ 2);
    }

    public void LoadBall(Texture2D Texture)
    {
        this.BallTexture = Texture;
    }

    public float moveBall(float ballPositionY, float ballPositionX, float ballSpeed)
    {
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            ballPositionY -= ballSpeed;
        }
        if (kstate.IsKeyDown(Keys.Down))
        {
            ballPositionY += ballSpeed;
        }
        if (kstate.IsKeyDown(Keys.Left))
        {
            ballPositionX -= ballSpeed;
        }
        if (kstate.IsKeyDown(Keys.Right))
        {
            ballPositionX += ballSpeed;
        }

        return ballSpeed;
    }

    public void checkWindowCollision (float ballPositionY,float ballPositionX,int BufferWidth,int BufferHeight)
    {
        
        CheckWindowCollisionX(ballPositionX,BufferWidth, this.BallTexture.Width);
        CheckWindowCollisionY(ballPositionY,BufferHeight, this.BallTexture.Height);
    }

    private float CheckWindowCollisionY(float ballPositionY,int BufferHeight, float ballTextureHeight)
    {

        if (ballPositionY > BufferHeight - ballTextureHeight / 2)
        {
            ballPositionY = BufferHeight - ballTextureHeight / 2;
        }
        else if (ballPositionY < ballTextureHeight / 2)
        {
            ballPositionY = 0 + ballTextureHeight / 2;
        }
        return ballPositionY;
    }

    private float CheckWindowCollisionX(float ballPositionX, int BufferWidth, float ballTextureWidth)
    {

        if (ballPositionX > BufferWidth - ballTextureWidth / 2)
        {
            ballPositionX = BufferWidth - ballTextureWidth / 2;
        }
        else if (ballPositionX < ballTextureWidth / 2)
        {
            ballPositionX = 0 + ballTextureWidth / 2;
        }
        return ballPositionX;
    }

}

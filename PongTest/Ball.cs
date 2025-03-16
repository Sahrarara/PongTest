using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongTest;
using System;
using System.Reflection.Metadata;

public class Ball
{
    float ballSpeed;
    Vector2 ballPosition;
    Texture2D ballTexture;


    public Ball()
    {
        //ballSpeed = 0;
        //ballPosition = new Vector2(0,0);
        //ballTexture = new Texture2D(null,0,0);

        //ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
        //                   _graphics.PreferredBackBufferHeight / 2);
        //ballSpeed = 1000f;
        //_spriteBatch = new SpriteBatch(GraphicsDevice);
        //float updateBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void SpawnBall(float SpawnpositionY, float SpawnpositionX, float baseSpeed)
    {
        ballSpeed = baseSpeed;
        ballPosition = new Vector2(SpawnpositionX / 2,
                           SpawnpositionY/ 2);
    }

    public void LoadBall(Texture2D Texture)
    {
        Texture = Texture;
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
        CheckWindowCollisionX(ballPositionX,BufferWidth);
        CheckWindowCollisionY(ballPositionY, BufferHeight);
    }

    private float CheckWindowCollisionY(float ballPositionY,int BufferHeight)
    {

        float ballTextureHeight = ballTexture.Height;

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

    private float CheckWindowCollisionX(float ballPositionX, int BufferWidth)
    {
        float ballTextureWidth = ballTexture.Width;


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

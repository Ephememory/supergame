using System;
using System.Collections.Generic;
using System.Text;
using Cool.Entities;
using Raylib_cs;
using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Dynamics.World;
using Box2D.NetStandard.Dynamics.Bodies;
using Box2D.NetStandard.Dynamics;
using Box2D.NetStandard.Common;
using System.Numerics;
namespace Cool.Player
{
    public class Player : Entity
    {

        public struct UserCommand
        {
            public Vector2 InputVector;
            public byte KeysDown;
        }

        public Player(World world, BodyDef bodyDef) : base(world, bodyDef)
        {
            _visual = new Visuals
            {
                Texture = Raylib.LoadTexture("assets/tex/tileset1.png"),
                Tint = Raylib_cs.Color.WHITE,
                Mode = TextureFilterMode.FILTER_POINT,
                Scale = new System.Numerics.Vector2(32, 32)
            };
    
        }

        public override void Render(float dT)
        {
            Raylib.DrawTexturePro(_visual.Texture,
                new Rectangle { x = 144, y = 224, width = 16, height = 16 },
                new Rectangle { x = _body.GetPosition().X, y = _body.GetPosition().Y, width = _visual.Scale.X, height = _visual.Scale.Y },
                new System.Numerics.Vector2 { X = _visual.Scale.X / 2, Y = _visual.Scale.Y / 2 },
                0,
                _visual.Tint);
        }

        public override void Tick(float dT)
        {
            float InputY = 0;
            float InputX = 0;
            if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                InputY = -1.0f;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                InputY = 1.0f;
            }

            if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                InputX = 1.0f;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                InputX = -1.0f;
            }

            var cmd = new UserCommand 
            {
                InputVector = new Vector2 
                { 
                    X = InputX,
                    Y = InputY
                },
            };

            var newVelocity = cmd.InputVector * _stats.BaseMoveSpeed;
            _body.SetLinearVelocity(newVelocity);
        }
    }

}

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

        public Player(World world, BodyDef bodyDef) : base(world, bodyDef)
        {
            _visual = new VisualComponent
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
            if(Raylib.IsKeyReleased(KeyboardKey.KEY_W))
            {
                _body.ApplyLinearImpulseToCenter(new System.Numerics.Vector2{X = 0,  Y = 2});
                Console.WriteLine($"velocity: {_body.GetLinearVelocity()}");
            }
        }
    }

}

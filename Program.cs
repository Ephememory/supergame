using System;
using System.Numerics;
using Raylib_cs;
using Cool.Entities;
using System.Collections.Generic;
using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Dynamics.World;
using Box2D.NetStandard.Dynamics.Bodies;
using Box2D.NetStandard.Dynamics;
using Box2D.NetStandard.Common;

namespace Cool
{
    class Program
    {
        public static int ScreenWidth = 800;
        public static int ScreenHeight = 800;

        private static List<Entity> _ents;
        private static World _world;
        private static Camera2D _cam;
        static void Main(string[] args)
        {
            _ents = new List<Entity>();

            _world = new World(new Vector2 {X = 0, Y= 0 });
            
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "C# Raylib Game");
            _cam = new Camera2D();
            var player = new Player.Player(_world, new BodyDef
            {
                awake = true,
                enabled = true,
                allowSleep = false,
                position = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2),
                type = BodyType.Dynamic
            });


            _ents.Add(player);


            while(!Raylib.WindowShouldClose())
            {
                _cam.target = System.Numerics.Vector2.Lerp(_cam.target, 
                    new System.Numerics.Vector2(player.Body.GetPosition().X, player.Body.GetPosition().Y), 0.3f);
                _cam.offset = new System.Numerics.Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
                _world.Step(1.0f / 60.0f, 6, 2);
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.DARKGRAY);

                foreach(var e in _ents)
                {
                    e.Tick(Raylib.GetFrameTime());
                    e.Render(Raylib.GetFrameTime());
                }

                Raylib.EndDrawing();
            }
        }
    }
}

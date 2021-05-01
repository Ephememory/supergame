using System;
using Raylib_cs;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;
using Cool.Entities;
using System.Collections.Generic;

namespace Cool
{
    class Program
    {
        public static int ScreenWidth = 800;
        public static int ScreenHeight = 800;

        private static List<Entity> _ents;
        private static World _world;
        static void Main(string[] args)
        {
            var worldAABB = new AABB
            {
                UpperBound = new Vec2 {X = -100, Y = 100},
                LowerBound = new Vec2 { X = 100, Y= 0},

            };

            _world = new World(worldAABB, new Vec2 { X = 0, Y = 0}, true);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "C# Raylib Game");
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.DARKGRAY);
                Raylib.EndDrawing();
            }
        }
    }
}

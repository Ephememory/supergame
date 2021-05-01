using System.Numerics;
using Raylib_cs;
using Box2DX.Dynamics;

namespace Cool.Entities
{
    public abstract class Entity
    {
        protected Body _body;

        public Entity(World world, BodyDef bodyDef)
        {
            _body = world.CreateBody(bodyDef);
        }
        public abstract void Tick(float dT);
        public abstract void Render(float dT);
    }
}

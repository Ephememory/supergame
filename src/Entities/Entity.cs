using System.Numerics;
using Raylib_cs;
using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Dynamics.World;
using Box2D.NetStandard.Dynamics.Bodies;
using Box2D.NetStandard.Dynamics;
using Box2D.NetStandard.Common;
using Box2D.NetStandard.Collision.Shapes;
using Box2D.NetStandard.Dynamics.Fixtures;

namespace Cool.Entities
{
    public abstract class Entity
    {
        protected Body _body;
        public Body Body => _body;
        protected bool _markedForDelete;
        protected VisualComponent _visual;

        public Entity(World world, BodyDef bodyDef)
        {            
            PolygonShape shape = new PolygonShape(1.0f, 1.0f);
            var fixDef = new FixtureDef {
                density = 1.0f,
                shape = shape
                
            };
            
            _body = world.CreateBody(bodyDef);
            _body.CreateFixture(fixDef);
        }

        public abstract void Tick(float dT);
        public abstract void Render(float dT);
    }
}

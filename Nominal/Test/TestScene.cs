using Nominal.Engine.SceneManagement;
using Nominal.Engine;
using System;
using Nominal.Components;

namespace Nominal.Test
{
    public class TestScene : Scene
    {
        public override void Initialize()
        {
            GameObject camGo = new GameObject();
            GameObject go = new GameObject();
            camGo.AddComponent<Components.Cam.Camera>();
            SpriteRenderer rend = go.AddComponent<SpriteRenderer>();

            go.AddComponent<TestComponent>();

            GameObject go1 = new GameObject();
            SpriteRenderer rend1 = go1.AddComponent<SpriteRenderer>();

            go1.AddComponent<TestComponent>();
            go1.transform.parent = go.transform;
            go1.GetComponent<TestComponent>().o = new OrbitalMechanics.Orbit(1, 0.2, 1, 100, 2, true);
        }
    }
}

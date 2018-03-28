using Nominal.Engine.SceneManagement;
using Nominal.Engine;
using System;
using Nominal.Components;

namespace Nominal.Test
{
    public class TestScene2 : Scene
    {
        public override void Initialize()
        {
            GameObject camGo = new GameObject();
            GameObject go = new GameObject();
            camGo.AddComponent<Components.Cam.Camera>();
            SpriteRenderer rend = go.AddComponent<SpriteRenderer>();

            go.AddComponent<TestComponent>();
        }
    }
}

using Nominal.Engine.SceneManagement;
using Nominal.Engine;
using System;
using Nominal.Components;
using Microsoft.Xna.Framework;

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

            TestUIObject uiObj = new TestUIObject();
            uiObj.SetAnchorPreset(AnchorPreset.StretchStretch);
            uiObj.anchorMax = new DVector2(0.5, 0.5);
            uiObj.color = Color.Green;

            TestUIObject uiObj2 = new TestUIObject();
            uiObj2.SetAnchorPreset(AnchorPreset.LeftTop);
            uiObj2.offsetMax = new Point(960, 540);
            uiObj2.color = Color.Red;
            uiObj2.parent = uiObj;
        }
    }
}

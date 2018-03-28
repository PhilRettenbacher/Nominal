using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.SceneManagement
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();
        private static bool isStarted = false;
        private static Scene toLoad = null;

        public static int currLevel
        {
            get
            {
                return _currLevel;
            }
        }
        private static int _currLevel;

        public static void InitializeScene(Scene scene)
        {
            if(!isStarted)
            {
                scenes.Add(scene);
            }
            else
            {
                Console.WriteLine("Scenes can't be initialized after the Game has started!");
            }
        }
        public static void UpdateSceneManager()
        {
            if(toLoad != null&&!GameObject.onClear)
            {
                toLoad.Initialize();
                toLoad = null;
            }
        }
        public static void LoadLevel(int levelId)
        {
            if (!isStarted)
                isStarted = true;
            if(levelId>=scenes.Count||levelId<0)
            {
                Console.WriteLine("The LevelId is out of range!");
                return;
            }
            Console.WriteLine("Load Level: " + levelId);
            GameObject.ClearAll();
            toLoad = scenes[levelId];
            _currLevel = levelId;
        }
    }
}

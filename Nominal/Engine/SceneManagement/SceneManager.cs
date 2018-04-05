using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.SceneManagement
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>(); //Scenenliste wird angeschmissen
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
            if(levelId>=scenes.Count||levelId<0)        //hier schicken wir die Level ID in die Zukunft
            {
                Console.WriteLine("The LevelId is out of range!");      //Die Levelid befindet sich außer reichweite
                return;
            }
            Console.WriteLine("Load Level: " + levelId);        //Welches Level wird geladen? hier erfährt man das
            GameObject.ClearAll();
            toLoad = scenes[levelId];
            _currLevel = levelId;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public sealed class SceneLoadManager : Singleton<SceneLoadManager>
    {
        public static readonly string SCENE_MAINMENU = "MainMenu";

        public static readonly string SCENE_GAMEPLAY = "WorkScene"; //todo: rename scene to "Gameplay" when ready to realase

        public static readonly string SCENE_EXITGAME = "GameOver";

        protected override void Awake()
        {
            base.Awake();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
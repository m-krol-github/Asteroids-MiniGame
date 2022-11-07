using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitGameButton;
        [SerializeField] private TMP_InputField playerNameField;

        private void Awake()
        {
            playButton.onClick.AddListener(() =>
            {
                SceneLoadManager.Instance.LoadScene(SceneLoadManager.SCENE_GAMEPLAY);
            });
            
            exitGameButton.onClick.AddListener(() =>
            {
                SceneLoadManager.Instance.ExitGame();
            });
        }
        
            
    }
}
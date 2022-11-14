using Gameplay.GamePlayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public sealed class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private PlayerInformation playerInfo;

        [SerializeField] private Button playButton;
        [SerializeField] private Button exitGameButton;
        [SerializeField] private TMP_InputField playerNameField;

        private void Awake()
        {
            if(playerNameField.text == null)
            {

            }
            else
            {
                playerNameField.text = playerInfo.playerName;
            }

            playButton.onClick.AddListener(() =>
            {
                SceneLoadManager.Instance.LoadScene(SceneLoadManager.SCENE_GAMEPLAY);
            });
            
            exitGameButton.onClick.AddListener(() =>
            {
                SceneLoadManager.Instance.ExitGame();
            });

            playerNameField.onSubmit.AddListener((string input) => 
            { 
                SavePlayerName(input); 
            });
        }

        private void SavePlayerName(string t)
        {
            playerInfo.playerName = t;
        }
        
            
    }
}
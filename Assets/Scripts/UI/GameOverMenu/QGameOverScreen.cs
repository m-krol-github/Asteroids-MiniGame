using MainMenu;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class QGameOverScreen : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitGameButton;

    private void Awake()
    {
        menuButton.onClick.AddListener(() =>
        {
            SceneLoadManager.Instance.LoadScene(SceneLoadManager.SCENE_MAINMENU);
        });

        exitGameButton.onClick.AddListener(() =>
        {
            SceneLoadManager.Instance.ExitGame();
        });
    }
}

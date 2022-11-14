using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gameplay.UI
{
    public sealed class UIPause : BaseView
    {
        [SerializeField] private Button gameExit;
        [SerializeField] private Button closeView;
        [SerializeField] private TextMeshProUGUI playerName;

        private GameManager _manager;
        
        public void InitPause(GameManager manager)
        {
            _manager = manager;

            playerName.text = _manager.PlayerInformation.playerName;

            closeView.onClick.AddListener(() =>
            {
                _manager.PauseUnpause();
            });
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }
    }
}
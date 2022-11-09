using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public sealed class UIGameInfo : BaseView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI levelText;

        private GameManager _manager;

        public void InitGameInfo(GameManager manager)
        {
            _manager = manager;
        }
    }
}
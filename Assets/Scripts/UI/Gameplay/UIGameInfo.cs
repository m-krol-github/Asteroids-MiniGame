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

            scoreText.text = 0.ToString();
            levelText.text = 0.ToString();
            livesText.text = 3.ToString();
        }

        public void AddScore(int score)
        {
            scoreText.text += score.ToString();
        }

        public void AddLevel(int level)
        {
            levelText.text += level.ToString();
        }

        public void TakeLife(int lifes)
        {
            livesText.text += lifes.ToString();
        }
    }
}
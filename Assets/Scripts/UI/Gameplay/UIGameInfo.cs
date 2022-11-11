using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public sealed class UIGameInfo : BaseView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI levelText;

        private int score;
        private int lifes;
        private int level;

        private GameManager _manager;

        public void InitGameInfo(GameManager manager)
        {
            _manager = manager;

            scoreText.text = 0.ToString("D5");
            levelText.text = 0.ToString("D3");
            livesText.text = 3.ToString("D3");
        }

        public void AddScore(int score)
        {
            this.score += score;
            scoreText.text = this.score.ToString("D5");
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
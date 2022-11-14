using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public sealed class UIGameInfo : BaseView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI lifesText;
        [SerializeField] private TextMeshProUGUI levelText;

        private int score;
        private int lifes;
        private int level;

        private GameManager _manager;

        public void InitGameInfo(GameManager manager)
        {
            _manager = manager;

            lifes = manager.PlayerLifes;
            level = manager.Levels.CurrentLevel;

            score = 0;

            scoreText.text = score.ToString("D7");
            levelText.text = level.ToString("D2");
            lifesText.text = lifes.ToString("D2");
        }

        public void AddScore(int score)
        {
            this.score += score;
            scoreText.text = this.score.ToString("D7");
        }

        public void AddLevel(int level)
        {
            this.level += level;
            levelText.text = this.level.ToString();
        }

        public void TakeLife(int lifes)
        {
            this.lifes -= lifes;
            lifesText.text = this.lifes.ToString();
        }
    }
}
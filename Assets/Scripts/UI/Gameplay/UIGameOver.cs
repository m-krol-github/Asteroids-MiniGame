using UnityEngine;

namespace Gameplay.UI
{
    public sealed class UIGameOver : BaseView
    {

        private GameManager _manager;

        public void InitGameOver(GameManager manager)
        {
            this._manager = manager;
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
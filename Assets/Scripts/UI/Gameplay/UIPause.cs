using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public sealed class UIPause : BaseView
    {
        [SerializeField] private Button gameExit;
        [SerializeField] private Button closeView;

        private GameManager _manager;
        
        public void InitPause(GameManager manager)
        {
            _manager = manager;
        }

        public void PauseUnpause()
        {
            
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
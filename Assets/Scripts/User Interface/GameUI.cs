using UnityEngine;

namespace Game {

    internal abstract class GameUI : MonoBehaviour {

        protected virtual void OnEnable() {
            GameLifeCycle.OnGameStart += DeactivateUI;
            LevelGoal.OnLevelComplete += ActivateUI;
        }

        protected virtual void OnDisable() {
            GameLifeCycle.OnGameStart -= DeactivateUI;
            LevelGoal.OnLevelComplete -= ActivateUI;
        }

        private void ActivateUI() {
            OnActivateUI();
        }

        private void DeactivateUI() {
            OnDeactivateUI();
        }

        protected abstract void OnActivateUI();
        protected abstract void OnDeactivateUI();

    }
}
using UnityEngine;

namespace Game {

    internal abstract class GameUI : MonoBehaviour {

        private void OnEnable() {
            GameLifeCycle.OnGameStart += DeactivateUI;
            LevelGoal.OnLevelComplete += ActivateUI;

        }

        private void OnDisable() {
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
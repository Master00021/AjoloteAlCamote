using UnityEngine.SceneManagement;
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

        public void OnMainMenu() {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        private void ActivateUI() {
            OnActivateUI();
        }

        private void DeactivateUI() {
            OnDeactivateUI();
        }

        public abstract void OnRestart();
        protected abstract void OnActivateUI();
        protected abstract void OnDeactivateUI();

    }
}
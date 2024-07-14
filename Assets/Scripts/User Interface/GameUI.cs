using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

namespace Game {

    internal abstract class GameUI : MonoBehaviour {

        public static Action OnSaveData;

        protected virtual void OnEnable() {
            GameLifeCycle.OnGameStart += DeactivateUI;
            LevelGoal.OnLevelComplete += ActivateUI;
        }

        protected virtual void OnDisable() {
            GameLifeCycle.OnGameStart -= DeactivateUI;
            LevelGoal.OnLevelComplete -= ActivateUI;
        }

        public void OnMainMenu() {
            OnSaveData?.Invoke();
            StartCoroutine(CO_GoToMainMenu());
        }

        private IEnumerator CO_GoToMainMenu() {
            while (true) {
                yield return new WaitForSecondsRealtime(0.1f);
                
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
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
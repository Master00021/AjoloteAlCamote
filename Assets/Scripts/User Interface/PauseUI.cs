using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace Game {

    internal sealed class PauseUI : GameUI {

        public static Action<bool> OnGamePaused;
    
        [SerializeField] private GameObject _uiToActivate;
        [SerializeField] private LevelData _levelData;

        private bool _paused;

        protected override void OnEnable() {
            base.OnDisable();

            Player.OnPause += Pause;

            OnDeactivateUI();
        }

        protected override void OnDisable() {
            base.OnDisable();

            Player.OnPause -= Pause;
        }

        private void Pause() {
            if (_paused) {
                OnDeactivateUI();
                _paused = false;
            }
            else {
                OnActivateUI();
                _paused = true;
            }

            OnGamePaused?.Invoke(_paused);
        }

        public void OnResume() {
            Pause();
        }

        public override void OnRestart() {
            SceneManager.LoadScene(_levelData.LevelName, LoadSceneMode.Single);
        }

        protected override void OnActivateUI() {
            _uiToActivate.SetActive(true);
        }

        protected override void OnDeactivateUI() {
            _uiToActivate.SetActive(false);
        }
    
    }
}
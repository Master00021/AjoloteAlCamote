using UnityEngine;
using System;

namespace Game {

    internal sealed class GameLifeCycle : MonoBehaviour {
    
        public static Action OnGameStart;
        public static Action OnGameStop;
        public static Action OnGamePause;	
        public static Action OnGameUnPaused;

        private void OnEnable() {
            PauseUI.OnGamePaused += GamePaused;

            Time.timeScale = 1.0f;
        }

        private void OnDisable() {
            PauseUI.OnGamePaused -= GamePaused;
        }
        
        private void Start() {
            OnGameStart?.Invoke();
        }

        private void GamePaused(bool paused) {
            if (paused) {
                Time.timeScale = 0.0f;
                OnGamePause?.Invoke();
            }
            else {
                Time.timeScale = 1.0f;
                OnGameUnPaused?.Invoke();
            }
        }

        public void OnExit() {
            Application.Quit();
        }

    }
}
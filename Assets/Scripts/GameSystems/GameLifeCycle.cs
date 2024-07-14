using UnityEngine;
using System;

namespace Game {

    internal sealed class GameLifeCycle : MonoBehaviour {
    
        public static Action OnGameStart;
        public static Action OnGameStop;
        public static Action OnGamePause;	

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
            print(paused);
            if (paused) {
                Time.timeScale = 0.0f;
            }
            else {
                Time.timeScale = 1.0f;
            }
        }

        public void OnExit() {
            Application.Quit();
        }

    }
}
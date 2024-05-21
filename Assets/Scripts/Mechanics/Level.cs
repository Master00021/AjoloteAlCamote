using System;

namespace Game {

    internal sealed class Level : LevelDataHandler {

        public static Action<LevelData> OnLevelEntry;

        private void OnEnable() {
            GameLifeCycle.OnGameStart += GameStarted;
        }

        private void OnDisable() {
            GameLifeCycle.OnGameStart -= GameStarted;
        }

        private void GameStarted() {
            OnLevelEntry?.Invoke(_LevelData);
        }

    }
}
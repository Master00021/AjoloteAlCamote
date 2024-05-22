using UnityEngine;
using System;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class LevelGoal : LevelDataHandler {

        public static Action OnLevelComplete;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<Player>()) {
                Complete();
            }
        }

        private void Complete() {
            _LevelData.Completed = true;
            OnLevelComplete?.Invoke();
        }

    }
}
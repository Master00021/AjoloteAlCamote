using UnityEngine;
using System;

namespace Game {

    internal sealed class LevelManager : MonoBehaviour {

        [SerializeField] private Levels _levels;
        [SerializeField] private int _starsCollected = 0; // Las estrellas recolectadas.

        public static Action OnLevelCompletedForLevelMovement;
        public static Action<LevelResult> OnLevelCompleted; 
        public static Action<Levels> OnLevelStart;

        private void Awake() {
            OnLevelStart?.Invoke(_levels);
            Time.timeScale = 1.0f;
        } 

        //private void OnEnable() => Shell.OnShellCollected += StarCollected;
        //private void OnDisable() => Shell.OnShellCollected -= StarCollected;

        //private void StarCollected() => _starsCollected++; // Aumentar las estrella recolectadas.

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                Completed();
            }
        }

        private void Completed() {
            _levels._completed = true;
            _levels._percentage = 100;
            _levels._stars = _starsCollected;

            OnLevelCompleted?.Invoke(new LevelResult(_starsCollected, true, 100, _levels._levelID)); // Enviar los resultados del nivel.

            OnLevelCompletedForLevelMovement?.Invoke();

            Time.timeScale = 0.0f;
        }        
    }

    public struct LevelResult {
        public int TotalStars;
        public bool Completed;
        public float Percentage;
        public int LevelID;

        public LevelResult(int starsCollected, bool v1, int v2, int levelID) {
            TotalStars = starsCollected;
            Completed = v1;
            Percentage = v2;
            LevelID = levelID;
        }
    }
}

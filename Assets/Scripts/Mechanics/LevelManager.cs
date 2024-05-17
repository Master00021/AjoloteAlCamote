using UnityEngine;
using System;

namespace Game {

    internal sealed class LevelManager : MonoBehaviour {

        [SerializeField] private Levels _levels; // Informacion de los niveles, ScriptableObject.
        
        [SerializeField] private int _starsCollected = 0; // Las estrellas recolectadas.

        //[SerializeField] private GameContext _victoryContext; // El conexto de victoria del juego.

        //private IAudioService _audioService;

        //private IGameContextService _contextService; 

        public static event Action<LevelResult> OnLevelCompleted = null; 

        public static event Action<Levels> OnLevelStart = null;

        public static event Action OnLevelCompletedForLevelMovement = null;

        private void Awake() {

            //_audioService = Services.Instance.GetService<IAudioService>();

            //_contextService = Services.Instance.GetService<IGameContextService>();

            OnLevelStart?.Invoke(_levels);

            Time.timeScale = 1.0f;
        } 

        private void OnEnable() => Shell.OnShellCollected += StarCollected;
        private void OnDisable() => Shell.OnShellCollected -= StarCollected;

        private void StarCollected() => _starsCollected++; // Aumentar las estrella recolectadas.

        private void OnTriggerEnter2D(Collider2D other) {
            
            if (other.CompareTag("Player")) {

                Completed(); // Cuando se termina el nivel.
            }
        }

        private void Completed() {

            //_audioService.PlaySound("sfx_Victoria02");

            //_contextService.UpdateGameContext(_contextService.Data.CurrentContext, _victoryContext); // Cambiar el contexto del juego.
            
            _levels._completed = true;
            _levels._percentage = 100;
            _levels._stars = _starsCollected;

            OnLevelCompleted?.Invoke(new LevelResult(_starsCollected, true, 100, _levels._levelID)); // Enviar los resultados del nivel.

            OnLevelCompletedForLevelMovement?.Invoke();

            Time.timeScale = 0.0f;
        }        
    }

    

    public struct LevelResult { // Todos los resultados del nivel.

        public int TotalStars;
        public bool Completed;
        public float Percentage;
        public int LevelID;

        public LevelResult(int starsCollected, bool v1, int v2, int levelID)
        {
            this.TotalStars = starsCollected;
            this.Completed = v1;
            this.Percentage = v2;
            this.LevelID = levelID;
        }
    }
}

using UnityEngine;
using TMPro;

namespace Game {
    
    internal sealed class LevelMenuStats : MonoBehaviour {

        // Objetos de estrella de la UI
        [SerializeField] private GameObject _starsLevel1;
        [SerializeField] private GameObject[] _starsLevel2;
        [SerializeField] private GameObject[] _starsLevel3;

        // Texto de la UI del LevelsMenu
        [SerializeField] private TextMeshProUGUI _completedLevel1;
        [SerializeField] private TextMeshProUGUI _completedLevel2;
        [SerializeField] private TextMeshProUGUI _completedLevel3;

        // 
        [SerializeField] private Levels[] _niveles;

        private Levels _levels; 

        public void Ejecutar() {
            
            UpdateLevelStatsUI(_niveles);
        }

        private void OnEnable() {

            LevelManager.OnLevelCompleted += UpdateLevelStats; // Actualiza los datos del nivel en cuestion

            LevelManager.OnLevelStart += GetLevel; // Consigue el nivel en cuestion
        } 
        private void OnDisable() {
            
            LevelManager.OnLevelCompleted -= UpdateLevelStats;

            LevelManager.OnLevelStart -= GetLevel;
        } 

        private void GetLevel(Levels level) {

            _levels = level;
        }

        public void UpdateLevelStatsUI(Levels[] niveles) {

            if (niveles[0]._levelID == 1) { // Nivel 1

                if (_niveles[0]._completed) {
                    
                    _completedLevel1.text = "Completed";

                    _starsLevel1.SetActive(true);
                }
            }

            if (niveles[1]._levelID == 2) { // Nivel 2

                if (_niveles[1]._completed) {
                    
                    _completedLevel2.text = "Completed";
                    
                    if (_niveles[1]._stars < 3) {

                        for (int i = 0; i < niveles[1]._stars; i++) {

                            _starsLevel2[i].SetActive(true);
                        }
                    }
                    else {

                        for (int i = 0; i < 3; i++) {

                            _starsLevel2[i].SetActive(true);
                        }
                    }
                }
            }

            if (niveles[2]._levelID == 3) { // Nivel 3

                if (_niveles[2]._completed) {
                    
                    _completedLevel3.text = "Completed";
                    
                    if (_niveles[2]._stars < 3) {

                        for (int i = 0; i < niveles[2]._stars; i++) {

                            _starsLevel3[i].SetActive(true);
                        }
                    }
                    else {

                        for (int i = 0; i < 3; i++) {

                            _starsLevel3[i].SetActive(true);
                        }
                    }
                }
            }
        }

        private void UpdateLevelStats(LevelResult levelResult) {

            if (_levels._levelID == 1) { // Nivel 1

                if (_levels._completed) {
                    
                    _completedLevel1.text = "Completed";

                    _starsLevel1.SetActive(true);
                }
            }

            if (_levels._levelID == 2) { // Nivel 2

                if (_levels._completed) {
                    
                    _completedLevel2.text = "Completed";
                    
                    if (_levels._stars < 3) {

                        for (int i = 0; i < levelResult.TotalStars; i++) {

                            _starsLevel2[i].SetActive(true);
                        }
                    }
                    else {

                        for (int i = 0; i < 3; i++) {

                            _starsLevel2[i].SetActive(true);
                        }
                    }
                }
            }

            if (_levels._levelID == 3) { // Nivel 3

                if (_levels._completed) {
                    
                    _completedLevel3.text = "Completed";
                    
                    if (_levels._stars < 3) {

                        for (int i = 0; i < levelResult.TotalStars; i++) {

                            _starsLevel3[i].SetActive(true);
                        }
                    }
                    else {

                        for (int i = 0; i < 3; i++) {

                            _starsLevel3[i].SetActive(true);
                        }
                    }
                }
            }
        }
        
    }
}
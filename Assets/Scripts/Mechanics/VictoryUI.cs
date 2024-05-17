using UnityEngine;

namespace Game {

    internal sealed class VictoryUI : MonoBehaviour {    

        // Los objetos de las estrellas
        [SerializeField] private GameObject[] _starsImages;

        private void OnEnable(){

            LevelManager.OnLevelCompleted += StarCollected; // Actualiza los datos cuando se acaba el nivel
        }
        private void OnDisable() {

            LevelManager.OnLevelCompleted -= StarCollected;
        } 

        private void StarCollected(LevelResult levelResult) {

            // Apagar las estrellas
            for (int i = 0; i < _starsImages.Length; i++) {

                    _starsImages[i].SetActive(false);
                }

            // Prender las estrellas
            for (int i = 0; i < levelResult.TotalStars; i++) {

                _starsImages[i].SetActive(true);
            }
        }   

    }  
}
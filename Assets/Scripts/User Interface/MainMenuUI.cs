using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace Game {

    internal sealed class MainMenuUI : MonoBehaviour {

    
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _tutorialImage;
        [SerializeField] private GameObject _levelsMenu;
        [SerializeField] private GameObject _credits;

        private void Awake() {
            _mainMenu.SetActive(true);
            _tutorialImage.SetActive(false);
            _levelsMenu.SetActive(false);
        }

        public void ShowTutorial() {
            _tutorialImage.SetActive(true);
            _mainMenu.SetActive(false);
        }

        public void ShowLevelsMenu() {
            _levelsMenu.SetActive(true);
            _tutorialImage.SetActive(false);
        }

        public void ShowMainMenu() {
            _mainMenu.SetActive(true);
            _levelsMenu.SetActive(false);
            _credits.SetActive(false);
        }

        public void ShowCredits() {
            _credits.SetActive(true);
            _mainMenu.SetActive(false);
        }

        public void StartGoToLevel(string levelName) {
            StartCoroutine(CO_GoToLevel(levelName));
        }

        private IEnumerator CO_GoToLevel(string levelName) {
            while (true) {
                yield return new WaitForSeconds(0.1f);
                
                SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            }
        }
    
    }
}


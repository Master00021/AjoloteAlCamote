using UnityEngine;

namespace Game {

    internal sealed class MainMenuUI : MonoBehaviour {
    
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _tutorialImage;
        [SerializeField] private GameObject _levelsMenu;

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
        }
    
    }
}


using UnityEngine;
using UnityEngine.UI;

namespace Game {
    
    internal sealed class ColorblindUISprites : MonoBehaviour {
        
        public Sprite _protanopiaImage;
        private Image _myImageComponent;

        public Sprite _deuteranopiaImage;
        private Image _myImageComponent2;

        private void Start() {
            
            if (PlayerPrefs.GetInt("ToggleBool2") == 1) {

                _myImageComponent = this.GetComponent<Image>();
                _myImageComponent.sprite = _protanopiaImage;
            }

            if (PlayerPrefs.GetInt("ToggleBool3") == 1) {

                _myImageComponent2 = this.GetComponent<Image>();
                _myImageComponent2.sprite = _deuteranopiaImage;
            }
        }

    }
}

using UnityEngine;

namespace Game {

    internal sealed class ColorblindSprites : MonoBehaviour {

        public SpriteRenderer _withoutForms;
        public Sprite _withForms;

        private void Start() {
        
            if (PlayerPrefs.GetInt("ToggleBool2") == 1) {

                _withoutForms.sprite = _withForms;  
            }
        }
        
    }
}

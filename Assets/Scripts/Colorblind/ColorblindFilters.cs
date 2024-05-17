using UnityEngine.UI;
using UnityEngine;

namespace Game {

    internal sealed class ColorblindFilters : MonoBehaviour {
        
        public Toggle _toggleDisabled;
        public Toggle _toggleEnabled;

        private void Start() {
        
            if (PlayerPrefs.GetInt("ToggleBool") == 1) {

                _toggleEnabled.isOn = true;
            }
            else {

                _toggleEnabled.isOn = false;
            }
            if (PlayerPrefs.GetInt("ToggleBool2") == 1) {

                _toggleEnabled.isOn = true;
            }
            else {

                _toggleEnabled.isOn = false;
            }
        }

        private void Update() {            
            
            if (_toggleEnabled.isOn == true) {

                PlayerPrefs.SetInt("ToggleBool", 1);
            }
            else {

                PlayerPrefs.SetInt("ToggleBool", 0);
            }
            if (_toggleEnabled.isOn == true) {

                PlayerPrefs.SetInt("ToggleBool2", 1);
            }
            else {

                PlayerPrefs.SetInt("ToggleBool2", 0);
            }
        }
    }
}

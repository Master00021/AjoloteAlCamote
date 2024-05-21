using UnityEngine;
using TMPro;

namespace Game {

    internal sealed class GameplayUI : MonoBehaviour {
        
        [SerializeField] private TextMeshProUGUI _currentDistance;

        private void CurrentDistance(float currentDistance) {
            _currentDistance.text = currentDistance.ToString("0000") + "m";
        }

    }
}
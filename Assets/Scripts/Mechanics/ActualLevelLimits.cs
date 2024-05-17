using UnityEngine;

namespace Game {

    internal sealed class ActualLevelLimits : MonoBehaviour {

        private void OnEnable() {
            DesactivateLimits.OnLevelChange += TurnOffLimits;
        }

        private void OnDisable() {
            DesactivateLimits.OnLevelChange -= TurnOffLimits;
        }

        private void TurnOffLimits() {

            gameObject.SetActive(false);
        }

    }
}

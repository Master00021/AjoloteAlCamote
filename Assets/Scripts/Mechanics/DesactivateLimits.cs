using UnityEngine;
using System;

namespace Game {

    internal sealed class DesactivateLimits : MonoBehaviour {

        public static event Action OnLevelChange = null;

        public void LimitsOff() {

            OnLevelChange?.Invoke();
        }
        
    }
}

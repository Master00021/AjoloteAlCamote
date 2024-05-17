using UnityEngine;

namespace Game {

    internal sealed class Vsync : MonoBehaviour {

        public void VsyncMethod(bool _bool) {

            var _numero = _bool ? 1 : 0;

            QualitySettings.vSyncCount = _numero;
        }
        
    }
}

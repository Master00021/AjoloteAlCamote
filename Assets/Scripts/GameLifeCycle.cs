using UnityEngine;
using System;

namespace Game {

    internal sealed class GameLifeCycle : MonoBehaviour {
    
        public static Action OnGameStart;
        public static Action OnGameStop;
        
        private void Start() {
            OnGameStart?.Invoke();
        }

    }
}
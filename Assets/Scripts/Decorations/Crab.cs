using UnityEngine;

namespace Game {

    internal sealed class Crab : MonoBehaviour {
    
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationName;

        private void Awake() {
            _animator.SetBool(_animationName, true);
        }

        public void Destroy() {
            Destroy(gameObject);
        }
    
    }
}
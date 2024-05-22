using UnityEngine;

namespace Game {

    internal sealed class AngelFish : DecorationAnimal {
    
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _redFish;

        private void Awake() {
            _animator.SetBool("RedFish", _redFish);
        }
    
    }
}
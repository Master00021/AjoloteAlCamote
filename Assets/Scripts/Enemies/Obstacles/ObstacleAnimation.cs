using UnityEngine;

namespace Game {

    internal sealed class ObstacleAnimation : MonoBehaviour {

        [SerializeField] private Animator _animator;

        private void Start() {
            _animator.SetBool("Activate", true);
        }

    }
}
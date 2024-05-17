using UnityEngine;
using System;

namespace Game {

    internal sealed class Shell : MonoBehaviour {

        public static Action OnShellCollected;
        public static Action<AudioClip> OnPlayCollected;
        
        [SerializeField] private AudioClip _collected;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;

        private Transform _fishToFollow;
        private Transform _offset;
        private float _speed;

        private void Update() {
            if (_fishToFollow) {

                transform.LookAt(_fishToFollow.position, transform.up);

                var direction = _fishToFollow.position - _offset.position;
                var velocity = direction * _speed * Time.deltaTime;
                transform.Translate(velocity, Space.World);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<Player>()) {
                OnPlayCollected?.Invoke(_collected);
                OnShellCollected?.Invoke();
                Destroy(gameObject);
            }
        }

        internal void SetFish(Transform fish) {
            _fishToFollow = fish;
        }

    }
}
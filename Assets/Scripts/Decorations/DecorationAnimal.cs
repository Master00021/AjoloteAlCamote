using UnityEngine;

namespace Game {

    internal class DecorationAnimal : MonoBehaviour, ITriggerActivator {
    
        [SerializeField] private float _speed;

        private bool _activate;

        private void Update() {
            if (_activate) {
                transform.Translate(_speed * Time.deltaTime * -Vector2.right, Space.World);
            }
        }

        public void ActivateObject() {
            _activate = true;
        }

    }
}


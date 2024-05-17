using UnityEngine;

namespace Game {

    internal sealed class DecorationMovements : MonoBehaviour, ITriggerActivator {

        [SerializeField] private GameObject _fishesToMove;
        [SerializeField] private float _speed;

        [SerializeField] private bool _leftMovement;

        private bool _activate = false;

        private void Update()
        {
            if (_activate && _fishesToMove != null)
            {

                LeftMovement();
            }
        }

        private void LeftMovement()
        {

            _fishesToMove.transform.Translate(-_fishesToMove.transform.right * (_speed * Time.deltaTime), 0.0f);
        }

        public void ActivateObject()
        {

            _activate = true;
        }

    }  
}


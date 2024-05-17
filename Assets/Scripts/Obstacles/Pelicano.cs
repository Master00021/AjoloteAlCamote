using UnityEngine;

namespace Game {

    internal sealed class Pelicano : MonoBehaviour, ITriggerActivator {

        [SerializeField] private GameObject _objetoARotar;
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private Animator _activateAnimation;

        private float _initialPos;

        private bool _activarObstaculo = false;

        public void ActivateObject() {

            _activarObstaculo = true;

            _activateAnimation.SetBool("Activate", true);

            _objetoARotar.transform.rotation = Quaternion.Euler(_objetoARotar.transform.rotation.x,
                                                                    _objetoARotar.transform.rotation.y,
                                                                    180.0f);
        }

        private void FixedUpdate() {

            if (_activarObstaculo) {             

                _initialPos += Time.deltaTime;

                _objetoARotar.transform.rotation = Quaternion.Euler(_objetoARotar.transform.rotation.x, 
                                                                    _objetoARotar.transform.rotation.y,
                                                                    _objetoARotar.transform.rotation.z + _initialPos * _rotationSpeed);
            }
        }

    }
}
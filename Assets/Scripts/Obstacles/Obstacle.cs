using System.Collections;
using UnityEngine;

namespace Game {

    internal abstract class Obstacle : MonoBehaviour, ITriggerActivator {

        [SerializeField] private float _horizontalSpeed = 2.0f;

        private void Start() {
            ActivateObject();
        }

        protected abstract void OnActivateObject();

        protected IEnumerator CO_HorizontalMovement() {
            while (true) {
                transform.Translate(_horizontalSpeed * Time.deltaTime * -Vector3.right, Space.World);

                yield return null;
            }
        }

        public void ActivateObject() {
            StartCoroutine(CO_HorizontalMovement());
            OnActivateObject();
        }

    }
}
using System.Collections;
using UnityEngine;

namespace Game {

    internal abstract class Obstacle : MonoBehaviour, ITriggerActivator, IDestroyable {

        [SerializeField] private float _horizontalSpeed = 2.0f;

        public void ActivateObject() {
            StartCoroutine(CO_HorizontalMovement());
            OnActivateObject();
        }

        protected IEnumerator CO_HorizontalMovement() {
            while (true) {
                transform.Translate(_horizontalSpeed * Time.deltaTime * -Vector3.right, Space.World);
                yield return null;
            }
        }

        protected abstract void OnActivateObject();

        public void Destroy() {
            Destroy(gameObject);
        }
    
    }
}
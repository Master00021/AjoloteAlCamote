using System.Collections;
using UnityEngine;

namespace Game {

    internal abstract class Obstacle : MonoBehaviour, ITriggerActivator {

        [SerializeField] private float _horizontalSpeed;

        public abstract void ActivateObject();

        protected IEnumerator CO_HorizontalMovement() {
            while (true) {
                transform.Translate(_horizontalSpeed * Time.deltaTime * -transform.right, Space.World);
                yield return null;
            }
            //transform.localPosition = new Vector3(transform.localPosition.x * -_forwardSpeed, transform.localPosition.y);
        }

    }
}
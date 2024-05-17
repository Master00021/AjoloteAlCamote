using UnityEngine;

namespace Game {

    internal sealed class ItemRemover : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D other) {

            if (other.CompareTag("Obstaculo") || other.CompareTag("Decoration") || other.CompareTag("EnemigoEstrella")) {

                Destroy(other.gameObject);
            }
        }

    }
}
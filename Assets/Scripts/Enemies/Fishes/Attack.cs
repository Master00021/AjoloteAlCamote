using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Attack : MonoBehaviour {
    
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<Player>(out var player)) {
                player.Death();
            }
        }
    
    }
}


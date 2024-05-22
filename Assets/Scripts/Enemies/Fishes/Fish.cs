using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Fish : MonoBehaviour, IDestroyable {

        [SerializeField] private GameObject _objectToDestroy;
    
        public void Destroy() {
            Destroy(_objectToDestroy);
        }
    
    }
}


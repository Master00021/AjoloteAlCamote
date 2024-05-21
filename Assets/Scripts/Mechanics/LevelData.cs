using UnityEngine;

namespace Game {

    [CreateAssetMenu]
    internal sealed class LevelData : ScriptableObject {
        
        [SerializeField] internal bool Completed;
        [SerializeField] internal bool FirstShell;
        [SerializeField] internal bool SecondShell;
        [SerializeField] internal bool ThirdShell;
        [SerializeField] internal int ID;

    }
}
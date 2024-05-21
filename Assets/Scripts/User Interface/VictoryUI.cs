using UnityEngine;

namespace Game {

    internal sealed class VictoryUI : MonoBehaviour {    

        [SerializeField] private GameObject[] _shells;

        private void OnEnable(){
            Shell.OnShellCollected += StarCollected;
        }

        private void OnDisable() {
            Shell.OnShellCollected -= StarCollected;
        } 

        private void StarCollected(ShellNumber shellNumber) {
            if (shellNumber == ShellNumber.First) {
                _shells[0].SetActive(true);
            }

            if (shellNumber == ShellNumber.Second) {
                _shells[1].SetActive(true);
            }

            if (shellNumber == ShellNumber.Third) {
                _shells[2].SetActive(true);
            }
        }   

    }  
}
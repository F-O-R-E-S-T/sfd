using UnityEngine;

namespace ZombiesMinigame
{
    public class AreaDetection : MonoBehaviour
    {

        [SerializeField] private bool _isDirt;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(_isDirt)
                    other.GetComponent<PlayerController>().floorType = PlayerController.FloorType.Dirt;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_isDirt)
                    other.GetComponent<PlayerController>().floorType = PlayerController.FloorType.Concrete;
            }
        }
    }
}



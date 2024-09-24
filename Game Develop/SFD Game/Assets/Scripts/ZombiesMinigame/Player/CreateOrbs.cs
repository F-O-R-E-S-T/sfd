using UnityEngine;

namespace ZombiesMinigame
{
    public class CreateOrbs : MonoBehaviour
    {
        [SerializeField] private GameObject _orbPrefab;
        [SerializeField] private int _orbssAmount;

        private void Start()
        {
            for (int i = 0; i < _orbssAmount; i++)
            {
                Instantiate(_orbPrefab, transform).GetComponent<Orb>().SetAngle(i * (360 / _orbssAmount));
            }
        }
    }
}



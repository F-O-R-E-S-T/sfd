using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class LookAtMouse : MonoBehaviour
    {
        [SerializeField] private LayerMask floorLayer;

        void FixedUpdate()
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Debug.DrawRay(ray.origin, ray.direction*100, Color.red, Mathf.Infinity);
            if (Physics.Raycast(ray.origin, ray.direction*100, out RaycastHit hit, 60, floorLayer))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                Vector3 direction = targetPosition - transform.position;
                direction.y = 0;

                if (direction != Vector3.zero)
                {

                    Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);
                    Quaternion targetRotation = Quaternion.LookRotation(direction) * additionalRotation;

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15f);
                }
            }
        }
    }

}


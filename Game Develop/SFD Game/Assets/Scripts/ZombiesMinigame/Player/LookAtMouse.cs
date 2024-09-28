using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class LookAtMouse : MonoBehaviour
    {
        void Update()
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point;

                Vector3 direction = targetPosition - transform.position;
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);
                    targetRotation *= additionalRotation;

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                }
            }
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByCollisison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Other. name= " + other.name);
            other.gameObject.SetActive(false);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.CompareTag("MainCamera") && gameObject.GetComponent<MeshRenderer>().enabled)
        {
            Debug.Log("Other. name= " + collision.collider.name);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
            
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            Debug.Log("Other. name= " + collision.collider.name);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

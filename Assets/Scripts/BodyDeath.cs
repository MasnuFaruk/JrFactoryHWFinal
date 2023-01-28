using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            GetComponentInParent<PlayerPower>().BodyKilled();
            Destroy(gameObject);
        }
    }
}

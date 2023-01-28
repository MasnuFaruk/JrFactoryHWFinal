using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharachters : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 moveVector =-transform.localPosition*Time.deltaTime;
        
        transform.Translate(moveVector);
    }
}

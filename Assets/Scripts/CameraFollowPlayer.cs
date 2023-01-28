using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float cameraFollowSpeed=3f;
    private Vector3 offsetDistance;
    // Start is called before the first frame update
    void Start()
    {
        offsetDistance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 newCameraPosition = player.transform.position + offsetDistance;
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraFollowSpeed*Time.deltaTime);
    }
}

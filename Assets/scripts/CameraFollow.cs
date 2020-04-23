using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform TargetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        TargetToFollow = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(TargetToFollow.position.x, -7.2f, 7.2f),
            Mathf.Clamp(TargetToFollow.position.y, -5f, 2f),
            transform.position.z
            );
    }
}

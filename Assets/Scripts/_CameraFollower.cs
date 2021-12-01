using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CameraFollower : MonoBehaviour
{
    [SerializeField] private float lerpSpeed = 3f;

    private Transform target;
    private Vector3 offset;
    private Vector3 newPos;

    void Start()
    {
        
        target = GameObject.FindWithTag("Player").transform;
        offset = transform.position;
    }
    void LateUpdate()
    {
        
        newPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed * Time.deltaTime);

    }
}

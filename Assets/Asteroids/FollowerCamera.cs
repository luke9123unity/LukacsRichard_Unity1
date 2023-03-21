using UnityEngine;

class FollowerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        transform.position= target.position + offset;
    }
}

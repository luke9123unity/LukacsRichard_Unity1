using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient;
    [SerializeField] Light light;

    float originalIntensity;

    void Start()
    {
        originalIntensity=light.intensity;
    }

    void Update()
    {
        Vector3 p = transform.position;
        Vector3 t = target.position;

        float dist = Vector3.Distance(p, t);

        float x = dist / maxDistance;
        float speed = distanceToSpeedCurve.Evaluate(x) * maxSpeed;

        Color c = gradient.Evaluate(x);
        light.color = c;
        light.intensity = c.a * originalIntensity;

        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}

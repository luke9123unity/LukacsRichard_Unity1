using System.Collections.Generic;
using UnityEngine;

class LongPathMover : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] float speed;

    int currentIndex = 0;

    void Update()
    {
        if (points.Count == 0) return;

        if (currentIndex >= points.Count)
        {
            currentIndex = 0;
            List<Transform> randomList = new List<Transform>();

            while(points.Count > 0)
            {
                int randomIndex = Random.Range(0, points.Count);
                randomList.Add(points[randomIndex]);
                points.RemoveAt(randomIndex);
            }

            points = randomList;


        }

        Transform target = points[currentIndex];

        if (target == null)
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!");
        }
        if (target == null) return;

        Vector3 selfPos = transform.position;
        Vector3 targetPos = target.position;

        transform.position = Vector3.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            currentIndex++;
        }
    }


}

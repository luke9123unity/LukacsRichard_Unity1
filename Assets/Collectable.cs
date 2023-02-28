using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int value=1;
    [SerializeField] Bounds teleportArea;

    void OnTriggerEnter(Collider other)
    {
        Collector collect = other.GetComponent<Collector>();

        if (collect != null)
        {
            collect.Collect(value);
            Teleport();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(teleportArea.center, teleportArea.size);
    }

    void Teleport()
    {
        float x = Random.Range(teleportArea.min.x, teleportArea.max.x);
        float y = Random.Range(teleportArea.min.y, teleportArea.max.y);
        float z = Random.Range(teleportArea.min.z, teleportArea.max.z);

        transform.position = new Vector3(x,y,z);
    }
}

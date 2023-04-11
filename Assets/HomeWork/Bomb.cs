using UnityEngine;

class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;
    [SerializeField] float maxForce = 100;
    [SerializeField] float upwardModifier = 0.5f;

    void Start()
    {
        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        Vector3 selfPos = transform.position;

        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);
            if (dist >= range)
                continue;
            /*
            //robbantunk, ha nem ugrottunk ki a ciklusból
            float forceRate = 1 - (dist / range);
            float currentForce = maxForce * forceRate;

            Vector3 dir = (rb.position - selfPos).normalized;

            rb.AddForce(dir * currentForce, ForceMode.Impulse);

            //rb.velocity += dir * currentForce / rb.mass; //ugyan az, mint a felette lévõ
            */


            rb.AddExplosionForce(maxForce, selfPos, range, upwardModifier);
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

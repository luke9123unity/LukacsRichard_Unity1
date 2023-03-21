using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
class BoxColliderAutoSize : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

    void OnValidate()
    {
        if(boxCollider==null)
            boxCollider= GetComponent<BoxCollider2D>();

        if(spriteRenderer==null)
            spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (Application.isPlaying)
        {
            //this.enabled=false;
            Destroy(this);
        }
    }

    void Update()
    {
        boxCollider.size=spriteRenderer.size;
    }
}

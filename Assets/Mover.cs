using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if (up)
        {
            transform.position += new Vector3(0,0,1) * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
        }
        if (down)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
        }
        if (left)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
        }
        if (right)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));

        }

        
    }
}

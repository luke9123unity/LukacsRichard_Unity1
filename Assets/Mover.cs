using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        /*if (up)
        {
            transform.position += cameraTransform.transform.forward * Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x,0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
        }
        if (down)
        {
            transform.position -= cameraTransform.transform.forward * Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
        }
        if (left)
        {
            transform.position -= cameraTransform.transform.right * Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
        }
        if (right)
        {
            transform.position += cameraTransform.transform.right * Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));

        }*/

        
    }
}

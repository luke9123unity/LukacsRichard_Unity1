using System.Security.Cryptography;
using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace;
    [SerializeField] float angularVelocity = 90f;

    [SerializeField] HealthObject healthObject;

    void OnValidate()
    {
        if(healthObject == null)
            healthObject = gameObject.GetComponent<HealthObject>();
    }

    void Update()
    {
        if(healthObject != null)
        {
            if(!healthObject.IsAlive()) return;
        }

        /*if(healthObject != null && healthObject.IsAlive())
        {
            return;
        }*/

        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);


        float x = 0;
        if (right)
        {
            x += 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
        }
            
        if (left)
        {
            x -= 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
        }
            

        float z = 0;
        if (up)
        {
            z += 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
        }
        if (down)
        {
            z -= 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
        }
           

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

        /*Vector3 inputVector1 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        float x1 = Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 0;
        float x2 = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        float z1 = Input.GetKeyDown(KeyCode.DownArrow) ? -1 : 0;
        float z2 = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        Vector3 inputVector2 = new Vector3(x1 + x2, 0, z1 + z2);

       
        inputVector1 = inputVector1.normalized;

        transform.Translate(inputVector1 * (Time.deltaTime * speed));*/

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;

        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;

        velocity.Normalize();

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);

        transform.position = newPos;
        if(velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            cameraTransform.rotation = Quaternion.RotateTowards(currentRotation,targetRotation,angularVelocity*Time.deltaTime);
        }
        

    }
}

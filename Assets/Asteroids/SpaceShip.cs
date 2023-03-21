using UnityEngine;

class SpaceShip : MonoBehaviour
{
    [SerializeField] float acceleration = 1;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;
    [SerializeField] float maxSpeed = 5;
    [SerializeField] float boostSpeed = 5;

    Vector2 velocity;
    void FixedUpdate()
    {
        //gyors�t�s
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration*Time.fixedDeltaTime);

            if (velocity.magnitude>maxSpeed)
            {
                //A megold�s
                velocity.Normalize();
                velocity *= maxSpeed;

                //B megold�s
                //velocity= velocity.normalized*maxSpeed;
            }
        }
        //lass�t�s
        velocity -= velocity * (drag * Time.fixedDeltaTime);
    }
    void Update()
    {
        //dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity += (Vector2)transform.up * boostSpeed;
        }
        //Mozg�s
        transform.position += (Vector3)(velocity * Time.deltaTime);

        //Forg�s
        float rotate = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime));
    }


}

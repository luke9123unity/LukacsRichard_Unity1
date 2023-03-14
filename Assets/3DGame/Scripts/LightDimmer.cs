using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    //[SerializeField, Range(0,1)] float dim = 0;
    [SerializeField] float frequency = 1;


    void OnValidat()
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;
        t *= frequency;
        t *= Mathf.PI * 2;

        float sin = Mathf.Sin(t);
        
        light.color = Color.Lerp(c1,c2,(sin+1)/2);
    }
}

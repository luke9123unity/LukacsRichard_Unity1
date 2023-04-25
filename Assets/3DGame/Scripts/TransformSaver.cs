using UnityEngine;
//https://marosicsaba.notion.site/Unity-j-t-kfejleszt-s-s-programoz-s-b957fdc3c4fa4c15b8f79d2ce51eaabc
public class TransformSaver : MonoBehaviour
{
    [SerializeField] string key="UNDEFINED";

    void Awake()
    {
        if (!PlayerPrefs.HasKey(key + "/x")) return;
        float posX = PlayerPrefs.GetFloat(key + "/x");
        float posY = PlayerPrefs.GetFloat(key + "/y");
        float posZ = PlayerPrefs.GetFloat(key + "/z");

        transform.position = new Vector3(posX, posY, posZ);
    }

    void OnDestroy()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        PlayerPrefs.SetFloat(key + "/x", pos.x);
        PlayerPrefs.SetFloat(key + "/y", pos.y);
        PlayerPrefs.SetFloat(key + "/z", pos.z);
    }
}

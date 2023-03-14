using TMPro;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    //[SerializeField] Color minColor=Color.red, maxColor = Color.green;
    [SerializeField] Gradient textColor;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        HealthUpdate();
    }

    public void Damage(int damage)
    {

        if (currentHealth <= 0)
            return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        HealthUpdate();
        //currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            //GetComponent<Collider>().enabled=false;
            //GetComponent<Mover>().enabled = false;
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    private void HealthUpdate()
    {
        if (uiText == null)
            return;

        uiText.text = "HEALTH: " + currentHealth;
        //uiText.color = Color.Lerp(minColor,maxColor,(float)currentHealth/maxHealth);
        uiText.color = textColor.Evaluate((float)currentHealth / maxHealth);

        restartUI.SetActive(!IsAlive());

    }
}

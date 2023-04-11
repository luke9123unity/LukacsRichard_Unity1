using System.Collections;
using TMPro;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    //[SerializeField] Color minColor=Color.red, maxColor = Color.green;
    [SerializeField] Gradient textColor;
    //[SerializeField] Collider hitBox;
    //[SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 0.1f;
    [SerializeField, Min(0)] float flickTime = 0.1f;

    int currentHealth;

    bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        HealthUpdate();
    }

    public void Damage(int damage)
    {

        if (currentHealth <= 0)
            return;
        if (isInvincible)
            return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        //hitBox.enabled = false;
        //Invoke(nameof(EnableHitBox), invincibilityFrames);

        StartCoroutine(InvincibilityCoroutine());

        HealthUpdate();
        //currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            //GetComponent<Collider>().enabled=false;
            //GetComponent<Mover>().enabled = false;
        }
    }

    /*void EnableHitBox()
    {
        hitBox.enabled = true;
    }*/

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        isInvincible = true;

        //hitBox.enabled = false;
        float startTime = Time.time;

        var wait = new WaitForSeconds(flickTime);

        while (startTime + invincibilityFrames > Time.time)
        {
            /*if (meshRenderer.enabled)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }*/

            foreach(MeshRenderer renderer in allMeshRenderer)
            {
                renderer.enabled = !renderer.enabled;
            }

            //meshRenderer.enabled = !meshRenderer.enabled;

            yield return wait;
        }

        foreach (MeshRenderer renderer in allMeshRenderer)
        {
            renderer.enabled = true;
        }

        //meshRenderer.enabled = true;
        //hitBox.enabled = true;
        isInvincible = false;

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

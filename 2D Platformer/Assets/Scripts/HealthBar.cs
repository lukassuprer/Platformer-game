using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private PlayerScript playerScript;

    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        slider.value = playerScript.curHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

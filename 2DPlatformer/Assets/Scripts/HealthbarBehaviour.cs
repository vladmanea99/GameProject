using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthbarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public Vector3 Ajuster;
    public void SetHealth(float health, float maxHealth){
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low,High,slider.normalizedValue);
    }
    void Update()
    {
        Ajuster.x = 0f;
        Ajuster.y = 1.5f;
        Ajuster.z = 0f;
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset + Ajuster);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float health;
    public float maxHP;
    private Animator anim;
    [SerializeField] Slider HPSlider;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        health = maxHP;
        HPSlider.maxValue = maxHP;
    }
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Damage");
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
    private void OnGUI()
    {
        float t = Time.deltaTime / 0.1f;
        HPSlider.value = Mathf.Lerp(HPSlider.value, health, t);
    }
}

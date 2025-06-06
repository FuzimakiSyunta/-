using UnityEngine;
using UnityEngine.UI;

public class EnemyHPController : MonoBehaviour
{
    public int enemyHP;
    private int EnemyNowHP;
    public Slider hpSlider;
    public bool sliderBool;

    void Start()
    {
        EnemyNowHP = enemyHP;
        hpSlider.value = enemyHP;
        hpSlider.gameObject.SetActive(false);
        sliderBool = false;
    }

    void Update()
    {
        hpSlider.transform.rotation = Camera.main.transform.rotation;

        if (sliderBool)
        {
            hpSlider.gameObject.SetActive(true);
        }

        if (EnemyNowHP <= 0)
        {
            hpSlider.value = 0;
            hpSlider.gameObject.SetActive(false);
        }
    }

    public void ApplyDamage(int amount)
    {
        EnemyNowHP -= amount;
        hpSlider.value = (float)EnemyNowHP / enemyHP;
        sliderBool = true;
    }

    public bool IsDead() => EnemyNowHP <= 0;
    public int GetCurrentHP() => EnemyNowHP;
}

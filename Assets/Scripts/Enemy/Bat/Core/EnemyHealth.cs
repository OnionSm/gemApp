using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable, IDeadable
{
    [SerializeField] private float max_health;
    [SerializeField] private float current_health;
    [SerializeField] private Rigidbody2D rigid_body;
    public float CurrentHealth
    {
        get { return current_health; }
    }
    private EnemyAnimationManager animationManager;
    private SpriteRenderer model;
    private bool is_alive;
    private float time_to_disappear;
    private float count_to_disappear;

    [SerializeField] private Image health_bar;
    [SerializeField] private Image health_bar_erase;
    [SerializeField] private float lerp_speed;
    [SerializeField] private Canvas bat_canvas;
    private void Awake()
    {
        this.animationManager = GetComponentInChildren<EnemyAnimationManager>();
        this.model = GetComponentInChildren<SpriteRenderer>();
        this.rigid_body = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        this.DismissModel();
        this.UpdateHealthBar();
        this.SetEaseHealthBar();
    }
    public void TakeDamage(float amount)
    {
        if (current_health - amount <= 0)
        {
            current_health = 0;
            if (is_alive)
            {
                bat_canvas.gameObject.SetActive(false);
                animationManager.SetDeathTrigger();
                rigid_body.gravityScale = 100f;
                StartCoroutine(DestroyBat());
                Death();
                this.is_alive = false;
            }
        }
        else
        {
            current_health -= amount;
        }
    }
    private void LoadComponent()
    {
        this.is_alive = true;
        this.max_health = 100f;
        this.current_health = 100f;
        this.time_to_disappear = 10f;
        this.count_to_disappear = time_to_disappear;
        this.lerp_speed = 0.8f;
    }
    private void DismissModel()
    {
        if(current_health <= 0)
        {
            count_to_disappear -= Time.deltaTime;
            if (model != null)
            {
                Color color = model.color;
                color.a = Mathf.Clamp01(count_to_disappear / 5f);
                model.color = color;
            }
        }
    }
    IEnumerator DestroyBat()
    {
        yield return new WaitForSeconds(time_to_disappear);
        Destroy(gameObject);
        yield return null;
    }
    private void UpdateHealthBar()
    {
        float fill = current_health / max_health;
        if (fill != health_bar.fillAmount)
        {
            health_bar.fillAmount = fill;
        }
    }
    public void SetEaseHealthBar()
    {
        if (health_bar_erase.fillAmount != health_bar.fillAmount)
        {
            health_bar_erase.fillAmount = Mathf.MoveTowards(health_bar_erase.fillAmount, health_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
    public void Death()
    {
        PlayerManager.Instance.AddExp(Random.Range(3,8));
    }

    public bool IsDead()
    {
        if (current_health <= 0)
            return true;
        return false;
    }
}

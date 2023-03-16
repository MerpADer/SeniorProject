using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("HP stuff")]
    public int hp;
    [HideInInspector] public int maxHealth;
    public HealthBar healthBar;
    private float immuneTimer;

    [Header("Damage stuff")]
    [SerializeField] GameObject deathMenu;
    [SerializeField] AudioClip takeDamage;
    [SerializeField] AudioClip playerDeath;

    private Movement movement;
    private Animator anim;
    private SpriteRenderer spr;
    private Camera cam;

    [Header("Material stuff")]
    [SerializeField] Material FlashWhite;
    private Material defaultMat;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        maxHealth = hp;
        healthBar.SetMaxHealth(hp);

        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        spr = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<Camera>();

        defaultMat = spr.material;
    }

    private void Update()
    {
        immuneTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRoll") && immuneTimer <= 0)
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            healthBar.SetHealth(hp);

            // sound
            movement.oneShotSound.PlayOneShot(takeDamage);

            // reset immune timer
            immuneTimer = 0.5f;

            // flash player red
            ThisFlashRed();
            CameraShake.Instance.Shake(1, 1, 0.1f);

            // move player back
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                StartCoroutine(Hurt(-1));
            }
            else
            {
                StartCoroutine(Hurt(1));
            }

            // death condition
            if (hp <= 0)
            {
                movement.oneShotSound.PlayOneShot(playerDeath);
                deathMenu.SetActive(true);
                cam.cullingMask = layerMask;
            }
        }
    }

    IEnumerator Hurt(int dir)
    {
        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(new Vector2(0.03f * dir, 0));
        }
    }

    void ThisFlashRed()
    {
        // player flashes red to signify damage being dealt
        spr.material = FlashWhite;

        Invoke(nameof(ResetMat), 0.1f);
    }

    void ResetMat()
    {
        spr.material = defaultMat;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class EnemyKing : EnemyBaseClass
{

    private int dir;

    private int temp;

    private float timer;

    private bool isDead;

    private CinemachineVirtualCamera cam;

    private SceneEditor sceneEditor;

    [Header("Attack Variables")]
    [SerializeField] List<float> attackRadius;

    [SerializeField] float timerLen;

    [SerializeField] Vector2 offset;
    [SerializeField] GameObject spawnfxPrefab;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] GameObject atkPrefab;

    [Header("Win Variables")]
    [SerializeField] GameObject winScreen;
    [SerializeField] Button mainMenu;

    void Start()
    {
        isDead = false;
        dir = -1;
        temp = 2;
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        sceneEditor = FindObjectOfType<SceneEditor>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // attacking the player
        if (isFacingObject(gameObject, Player) || !playerIsDetected(0.5f))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") && dmgBox != null)
            {
                int dirMult = ChangeDir();

                dir *= dirMult;
                dmgBox.transform.localScale = new Vector2(dmgBox.transform.localScale.x * dirMult, 1);
                Move();
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (timer <= 0 && playerIsDetected(attackRadius[temp - 1]) && !isDead)
        {
            timer = timerLen;
            if (temp == 1)
            {
                Attack1();
            }
            else if (temp == 2)
            {
                StartCoroutine(nameof(Attack2));
            }
            else
            {
                StartCoroutine(nameof(Attack3));
            }
            anim.SetBool("Walking", false);
            temp = Random.Range(1, 4);
        }

        DeathConditionsBoss();
    }

    void Move()
    {
        anim.SetBool("Walking", true);
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);
    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
    }

    IEnumerator Attack2()
    {
        anim.SetTrigger("Attack2");

        Instantiate(spawnfxPrefab, new Vector2(transform.position.x + offset.x * dir, transform.position.y + offset.y), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(spawnPrefab, new Vector2(transform.position.x + offset.x * dir, transform.position.y + offset.y), Quaternion.identity);
    }

    IEnumerator Attack3()
    {
        anim.SetTrigger("Attack3");

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.4f);
            Instantiate(atkPrefab, new Vector2(transform.position.x + (offset.x + i * 0.7f) * dir, transform.position.y + offset.y), Quaternion.identity);
        }

    }

    public void DeathConditionsBoss()
    {
        if (hp <= 0)
        {
            isDead = true;
            anim.SetBool("Die", true);

            // hide damage collider
            Destroy(dmgBox);

            cam.Follow = transform;
            cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector2(0, 0);
            Time.timeScale = 0.25f;

            Player.GetComponent<Movement>().enabled = false;
            Player.GetComponent<Health>().enabled = false;
            winScreen.SetActive(true);
            mainMenu.onClick.AddListener(delegate { sceneEditor.NextScene(0); });
        }
    }

}

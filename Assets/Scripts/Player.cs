using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField][RangeAttribute(0, 100)] float moveSpeed;
    [SerializeField] ScoreController scoreController;
    int lives;
    [SerializeField] GameObject[] lifeImgs;
    Cursor cursor;
    Animator animator;
    Shot shot;
    public Transform gunBarrel;
    [SerializeField] AudioSource gunshot;
    [SerializeField] AudioSource playerDeath;
    int isSound;
    bool isDead;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;

        cursor = FindObjectOfType<Cursor>();
        navMeshAgent.updateRotation = false;

        shot = FindObjectOfType<Shot>();
        animator = GetComponentInChildren<Animator>();

        isDead = false;
        lives = 3;
        isSound = PlayerPrefs.GetInt("Sound", 1);

        for (int i = 0; i < lifeImgs.Length; i++)
        {
            lifeImgs[i].SetActive(true);
        }
    }

    void Update()
    {
        if (!isDead)
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dir.z = -1.0f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                dir.z = 1.0f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dir.x = -1.0f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                dir.x = 1.0f;
            }
            navMeshAgent.velocity = dir.normalized * moveSpeed;
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);

            Vector3 forward = cursor.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));

            if (Input.GetMouseButtonDown(0))
            {
                var from = gunBarrel.position;
                var target = cursor.transform.position;
                var to = new Vector3(target.x, from.y, target.z);

                var direction = (to - from).normalized;

                RaycastHit hit;
                if (Physics.Raycast(from, to - from, out hit, 100))
                {
                    to = new Vector3(hit.point.x, from.y, hit.point.z);
                }
                else
                {
                    to = from + direction * 100;
                }

                if (hit.transform != null)
                {
                    var zombie = hit.transform.GetComponent<Zombie>();
                    if (zombie != null)
                    {
                        if (!zombie.IsDead)
                        {
                            scoreController.Kills++;
                        }
                        zombie.Kill();
                    }
                }

                shot.Show(from, to);
                if (isSound == 1)
                {
                    gunshot.Play();
                }
            }
        }
    }
    public void Damaged()
    {
        if (!isDead)
        {
            if (lives > 1)
            {
                lives--;
                lifeImgs[lives].SetActive(false);
            }
            else
            {
                playerDeath.Play();
                lifeImgs[0].SetActive(false);
                isDead = true;
                animator.SetTrigger("IsDead");
                Destroy(GetComponent<CapsuleCollider>());
                Destroy(GetComponent<Rigidbody>());
                Destroy(GetComponent<MovementAnimator>());
                scoreController.SaveScore(scoreController.Kills);
                GetComponentInChildren<ParticleSystem>().Play();
                scoreController.EndgameUI.SetActive(true);
            }
        }
        StartCoroutine(DamagedUI());
    }
    IEnumerator DamagedUI()
    {
        scoreController.Damaged.color = new Color(1f, 0f, 0f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        scoreController.Damaged.color = new Color(1f, 1f, 1f, 0f);
    }
}

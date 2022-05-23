using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Player player;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movementAnimator;
    bool isDead;
    public bool IsDead { get => isDead; set => isDead = value; }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        navMeshAgent.SetDestination(player.transform.position);
        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }

    public void Kill()
    {
        if (!isDead)
        {
            isDead = true;
            Destroy(capsuleCollider);
            Destroy(movementAnimator);
            Destroy(navMeshAgent);
            Destroy(this.gameObject, 3f);
            animator.SetTrigger("IsDead");
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isDead)
            {
                other.gameObject.GetComponent<Player>().Damaged();
            }
        }
    }
}

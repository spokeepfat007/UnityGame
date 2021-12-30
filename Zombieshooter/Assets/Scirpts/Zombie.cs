using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Player player;
    NavMeshAgent navMeshAgent;
    bool dead;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movement;
    ParticleSystem particleSystem;
    ZombieCounter zombieCounter;
    float distance;
    float timer = 0.0f;
    float cooldownTime = 1.0f;
    bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<MovementAnimator>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        zombieCounter = FindObjectOfType<ZombieCounter>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;

        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x,2) + Mathf.Pow(player.transform.position.z - transform.position.z,2));
        animator.SetFloat("distance", distance);
        if (cooldown)
        {
            if (timer < cooldownTime + 1)
                timer += Time.deltaTime;
            else
            {
                timer = 0;
                cooldown = false;
            }
            return;
        }
        navMeshAgent.SetDestination(player.transform.position);
        if (distance <4)
        {
            cooldown = true;
            player.GetDamage();
        }
    }
    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            particleSystem.Play();
            zombieCounter.AddKill();
            Destroy(capsuleCollider);
            Destroy(movement);
            Destroy(navMeshAgent);
            animator.SetTrigger("died");

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Enemy velocity")]
    [SerializeField] private float attackDistance = 3f;
    [SerializeField] private float runDistance = 14f;
    [SerializeField] private float agentSpeedRun;
    [SerializeField] private float stoppingDistance = 1f;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip walkSound;

    [SerializeField] private Transform objetivo;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isAttacking;

    public GameObject bloodImage;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }


    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, objetivo.position);

        if (distanceToTarget <= attackDistance && !isAttacking)
        {
            isAttacking = true;
            agent.isStopped = true;
            anim.SetTrigger("Attack");
            audioSource.PlayOneShot(attackSound);
            bloodImage.SetActive(true);
            StartCoroutine(ResetAttack());
        }

        else if (distanceToTarget <= runDistance)
        {
            agent.isStopped = false;

            agent.speed = agentSpeedRun;

            anim.SetTrigger("Run");

            if (!audioSource.isPlaying || audioSource.clip != runSound)
            {
                audioSource.Stop();
                audioSource.clip = runSound;
                audioSource.Play();
            }

            agent.SetDestination(objetivo.position);
        }

        else if (!isAttacking)
        {
            agent.isStopped = false;
            agent.speed = 1;
            anim.SetTrigger("Walk");
            if (!audioSource.isPlaying || audioSource.clip != walkSound)
            {
                audioSource.Stop();
                audioSource.clip = walkSound;
                audioSource.Play();
            }

            agent.SetDestination(objetivo.position);
        }
    }

    IEnumerator ResetAttack()
    {
        if (objetivo != null && objetivo.GetComponent<Rigidbody>() != null)
        {
            objetivo.GetComponent<Rigidbody>().isKinematic = true;
        }

        Invoke("LoadGameOver", 2.2f);

        yield return new WaitForSeconds(1f);

        agent.isStopped = false;

        agent.speed = 1;
        
        isAttacking = false;
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(ResetAttack());
            audioSource.Stop();
            anim.SetTrigger("Attack");
            audioSource.PlayOneShot(attackSound);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Cursor cursor;
    NavMeshAgent navMeshAgent;
    Shot shot;
    public float moveSpeed;
    public Transform eyeBarrel;
    public int health;
    public Slider slider;
    Cartridges cartridges;
    int patr = 7;
    bool cooldown = false;
    float timer = 0.0f;
    float cooldownTime = 1.0f;
    public GameObject canvas;
    int Pause;
    public GameOverScreen GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        cursor = FindObjectOfType<Cursor>();
        shot = FindObjectOfType<Shot>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        cartridges = FindObjectOfType<Cartridges>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause==1)
            return;
        slider.value = health;
        if (health < 0)
        {
            GameOverScreen.Setup();
            Time.timeScale = 0;
            Pause = 1;
        }
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            dir.z = -1.0f;
        if (Input.GetKey(KeyCode.D))
            dir.z = 1.0f;
        if (Input.GetKey(KeyCode.S))
            dir.x = 1.0f;
        if (Input.GetKey(KeyCode.W))
            dir.x = -1.0f;
        if (Input.GetKey(KeyCode.R))
        {
            cooldown = true;
            timer = 0;
        }
        navMeshAgent.velocity = dir.normalized*moveSpeed;
        if (Input.GetMouseButtonDown(0) && patr>0 && !cooldown)
        {
            var from = eyeBarrel.position;
            var target = cursor.transform.position;
            var to = new Vector3(target.x, from.y, target.z);
            var direction = (to - from).normalized;
            RaycastHit hit;
            if (Physics.Raycast(from, direction, out hit, 100))
            {
                if (hit.transform != null)
                {
                    var zombie = hit.transform.GetComponent<Zombie>();
                    if (zombie != null)
                        zombie.Kill();
                }
                to = new Vector3(hit.point.x, from.y, hit.point.z);
            }
            else
            {
                to = from + direction * 100;
            }

            shot.Show(from, to);
            patr = cartridges.Shot();
        }
        if (cooldown)
        {
            if (timer < cooldownTime + 1)
                timer += Time.deltaTime;
            else
            {
                cooldown = false;
                patr = cartridges.Recharge();
            }
            return;
        }
        Vector3 forward = cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
    }
    public void GetDamage()
    {
        if (health > 20)
        {
            health -= 30;
            return;
        }
        if (health > 0)
        {
            health -= 20;
            return;
        }
    }
    public void AddHealth()
    {
        if (health <= 50)
            health += 50;
        else health = 100;
    }
}
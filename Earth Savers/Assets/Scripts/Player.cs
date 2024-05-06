using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] public float movementSpeed = 1f;
    [SerializeField] private float rotationAmount = 1f;
    [SerializeField] private Transform handPos;
    public bool holdingWaste = false;
    private GameObject pickedUpItem;
    Rigidbody rb;
    private AudioManager audioManager;
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime,Space.World);

        if(movementDirection != Vector3.zero)
        {
            animator.Play("run");
            transform.forward = Vector3.Slerp(transform.forward, movementDirection, rotationAmount * Time.deltaTime);
        }
        else if(movementDirection == Vector3.zero)
        {
            animator.Play("idle");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Main Menu");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plastic"|| other.CompareTag("glass") || other.CompareTag("cans"))
        {
            if(holdingWaste)
            {
                return;
            }
            audioManager.PlaySFX(audioManager.pickWaste);
            other.transform.position = handPos.position;
            other.transform.SetParent(handPos,true);
            holdingWaste = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    private bool winned = false;
    Animator animator;
    public TextMeshPro timeText;
    public Button backButton;
    Player player;
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        animator = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0 && !winned && !player.holdingWaste)
        {
            player.movementSpeed = 0;
            float finishTime = Time.time;
            timeText.text = "You Finished in: " + finishTime.ToString("F2")+"s";
            winned = true;
            animator.Play("win");

            backButton.interactable = true;
            backButton.GetComponentInChildren<TextMeshProUGUI>().alpha = 255f;
            print("win");
        }
    }
    public void MainMenu()
    {
        Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene("Main Menu");
    }
}

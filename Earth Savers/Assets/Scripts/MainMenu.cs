using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Animator animator;
    [SerializeField]Button[] buttons;
    private void Start()
    {
        animator = GameObject.Find("Main Camera").GetComponent<Animator>();
    }
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit()
    {
        print("Quit");
        Application.Quit();
    }
    public void Guide()
    {
        animator.Play("guide");
        for(int i=0;i<buttons.Length - 1; i++)
        {
            buttons[i].interactable = false;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().alpha = 0f;
        }
        buttons[buttons.Length-1].interactable= true;
        buttons[buttons.Length-1].GetComponentInChildren<TextMeshProUGUI>().alpha = 255f;
    }
    public void Return()
    {
        animator.Play("return");
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            buttons[i].interactable = true;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().alpha = 255f;
        }
        buttons[buttons.Length - 1].interactable = false;
        buttons[buttons.Length - 1].GetComponentInChildren<TextMeshProUGUI>().alpha = 0f;
    }
}

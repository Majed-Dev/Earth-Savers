using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    Player player;
    [SerializeField] bool glassBin, plasticBin, cansBin;
    AudioManager audioManager;
    Score score;
    private void Start()
    {
        score = GameObject.Find("Score Manager").GetComponent<Score>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (plasticBin && other.CompareTag("plastic"))
        {
            score.score++;
            audioManager.PlaySFX(audioManager.correctWaste);
            player.holdingWaste = false;
            Destroy(other.gameObject);
        }
        else if (glassBin && other.CompareTag("glass"))
        {
            score.score++;
            audioManager.PlaySFX(audioManager.correctWaste);
            player.holdingWaste = false;
            Destroy(other.gameObject);
        }
        else if (cansBin && other.CompareTag("cans"))
        {
            score.score++;
            audioManager.PlaySFX(audioManager.correctWaste);
            player.holdingWaste = false;
            Destroy(other.gameObject);
        }
        else
        {
            //when not putting a waste in the right bin
            score.score--;
            audioManager.PlaySFX(audioManager.notCorrectWaste);
            player.holdingWaste = false;
            Destroy(other.gameObject);
        }

    }
}

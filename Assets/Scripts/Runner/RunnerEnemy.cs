using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour
{

    public List<AudioClip> Clips;

    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoseHealth()
    {
        Health--;
        if (Health <= 0)
        {
            PlaySound();
            gameObject.SetActive(false);

            
        }
    }

    public void PlaySound()
    {
        if (Clips.Count > 0)
        {
            int rand = Random.Range(0, Clips.Count);


            AudioManager.Instance.PlaySFX(Clips[rand]);
        }


    }
}

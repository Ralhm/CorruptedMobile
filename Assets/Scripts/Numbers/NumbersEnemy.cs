using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumbersEnemy : MonoBehaviour
{
    public float Speed;
    public int NumMax;
    public int NumMin = 1;
    public int Num;
    public bool IsCorrupted;

    public bool ActivateNextLevel;

    public bool PlaySoundOnAwake;
    public bool PlaySoundOnDeath;
    public List<AudioClip> Clips;

    public bool IsStationary = false;


    public int Lifespan;
    public float CorruptionRate = 0.1f;
    public bool DieAfterTimeLimit = true;

    public TextMeshProUGUI NumText;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsCorrupted)
        {
            Num = Random.Range(NumMin, NumMax);
            NumText.text = Num.ToString();
        }
        else
        {
            Num = Random.Range(NumMin, NumMax);
            NumText.text = Num.ToString();
            StartCoroutine(CorruptionText());
        }

        if (DieAfterTimeLimit)
        {
            Destroy(this.gameObject, Lifespan);
        }
        if (PlaySoundOnAwake) {
            PlaySound();
        }
    }

    IEnumerator CorruptionText()
    {
        while (true) {

            NumText.text = Random.Range(100, 2000).ToString();
            yield return new WaitForSeconds(CorruptionRate);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsStationary) {
            transform.position += new Vector3(-Speed, 0, 0);
        }
        
    }

    public void Die()
    {
        if (ActivateNextLevel)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
            return;
        }

        if (PlaySoundOnDeath)
        {
            PlaySound();
        }
        Debug.Log("Dying!!!!");
        gameObject.SetActive(false);
        NumbersPlayer.instance.IncreaseNum(Num);
    }

    public void Attack()
    {
        NumbersPlayer.instance.DecreaseNum(Num);
    }

    public void PlaySound()
    {
        if (Clips.Count > 0) {
            int rand = Random.Range(0, Clips.Count);


            AudioManager.Instance.PlaySFX(Clips[rand]);
        }


    }

}

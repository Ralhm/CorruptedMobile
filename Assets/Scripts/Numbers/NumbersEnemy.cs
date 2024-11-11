using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumbersEnemy : MonoBehaviour
{
    public float Speed;
    public int NumMax;
    public int NumMin;
    public int Num;
    public bool IsCorrupted;


    public int Lifespan;
    public float CorruptionRate = 0.1f;
    public bool DieAfterTimeLimit = true;

    public TextMeshProUGUI NumText;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsCorrupted)
        {
            Num = Random.Range(1, NumMax);
            NumText.text = Num.ToString();
        }
        else
        {
            NumText.text = Random.Range(100, 9999).ToString();
            StartCoroutine(CorruptionText());
        }

        if (DieAfterTimeLimit)
        {
            //Destroy(this.gameObject, Lifespan);
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
        transform.position += new Vector3(-Speed, 0, 0);
    }

    public void Die()
    {
        if (IsCorrupted)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
            return;
        }


        gameObject.SetActive(false);
        NumbersPlayer.instance.IncreaseNum(Num);
    }

    public void Attack()
    {
        NumbersPlayer.instance.DecreaseNum(Num);
    }


}

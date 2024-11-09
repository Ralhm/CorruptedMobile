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

    public TextMeshProUGUI NumText;

    // Start is called before the first frame update
    void Start()
    {
        Num = Random.Range(1, NumMax);

        NumText.text = Num.ToString();

        Destroy(this.gameObject, Lifespan);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(-Speed, 0, 0);
    }

    public void Die()
    {
        gameObject.SetActive(false);

        NumbersPlayer.instance.IncreaseNum(Num);
    }

    public void Attack()
    {
        NumbersPlayer.instance.DecreaseNum(Num);
    }


}

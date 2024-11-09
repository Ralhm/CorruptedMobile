using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;


    // Start is called before the first frame update
    void Start()
    {
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetHitTarget();

        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    public void GetHitTarget()
    {
        Debug.Log("Shooting!");

        Ray trace = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Physics.Raycast(trace, out Hit))
        {
            Debug.Log(Hit.collider.gameObject.name);
            if (Hit.collider != null)
            {
   
                NumbersEnemy enemy = Hit.collider.gameObject.GetComponent<NumbersEnemy>();
                if (enemy != null)
                {
                    NumbersPlayer.instance.Attack(enemy);
                    Debug.Log("Hit Enemy!");

                }

            }




        }
        

    }


}

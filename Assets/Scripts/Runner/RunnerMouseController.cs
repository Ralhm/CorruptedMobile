using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMouseController : MonoBehaviour
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
        //FindLookRotation();
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }


}

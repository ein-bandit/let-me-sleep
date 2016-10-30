using UnityEngine;
using System.Collections;

public class crosshairManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 1f);
        print(this.gameObject.transform.position);
        if (Time.timeScale == 0)
        {
            Cursor.visible = true;
        }
    }
}

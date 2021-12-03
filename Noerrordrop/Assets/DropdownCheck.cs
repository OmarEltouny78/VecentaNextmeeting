using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownCheck : MonoBehaviour
{
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            textBox.text = "Item 1 is cool";
        }
        if (val == 1)
        {
            textBox.text = "Item 2 is cool";
        }
        
    }
}

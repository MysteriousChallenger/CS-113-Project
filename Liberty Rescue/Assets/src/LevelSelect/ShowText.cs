using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    // Start is called before the first frame update

    public bool showText = false;
    public Text textPrefab;
    public string message;

    private Text myText;
    void Start()
    {
        myText = (Text) Instantiate(textPrefab, this.transform.position, Quaternion.identity);
        myText.transform.SetParent(GameObject.Find("Canvas").transform, true);
        myText.horizontalOverflow = HorizontalWrapMode.Overflow;
        myText.verticalOverflow = VerticalWrapMode.Overflow;
        myText.fontSize = 24;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleText() {
        if (showText == false) {
            myText.text = message;
            showText = true;
        } else {
            myText.text = "";
            showText = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ToolTipManager : MonoBehaviour
{
    public static ToolTipManager _instance;

    public TextMeshProUGUI textComponent;


    private void Awake()
    {
        //makes sure that there is only on tooltip showing t a time
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); //if another tooltip exists then this destroys that tooltip instance
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowToolTip(string tooltipString)
    {
        gameObject.SetActive(true);
        textComponent.text = tooltipString;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}

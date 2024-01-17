using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    InputField IPInputField;
    InputField PortInputField;
    // Start is called before the first frame update
    void Start()
    {
        IPInputField = transform.Find("IPInputField").GetComponent<InputField>();
        PortInputField = transform.Find("PortInputField").GetComponent<InputField>();
        if (IPInputField.text.Length == 0)
        {
            IPInputField.text = "127.0.0.1";
        }

        if (PortInputField.text.Length == 0)
        {
            PortInputField.text = 12345.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLogin()
    {
        if (IPInputField.text.Length == 0)
        {
            IPInputField.text = "127.0.0.1";
        }

        if (PortInputField.text.Length == 0)
        {
            PortInputField.text = 12345.ToString();
        }
        
        GlobalVariables.IPstr = IPInputField.text;
        GlobalVariables.PortStr = PortInputField.text;

        SceneManager.LoadScene("Login");
    }
}

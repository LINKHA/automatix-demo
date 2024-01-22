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
            PortInputField.text = 8888.ToString();
        }

        _G.AmxCli = new Amx.AmxClient();

        _G.HttpCli = new Amx.HttpCli();
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
            PortInputField.text = 8888.ToString();
        }
        
        _G.IPstr = IPInputField.text;
        _G.PortStr = PortInputField.text;
        _G.HttpCli.SetOpt(_G.IPstr, _G.PortStr);

        SceneManager.LoadScene("Login");
    }
}

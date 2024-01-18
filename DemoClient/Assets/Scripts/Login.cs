using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    InputField AccountInputField;
    InputField PasswordInputField;
    // Start is called before the first frame update
    void Start()
    {
        AccountInputField = transform.Find("AccountInputField").GetComponent<InputField>();
        PasswordInputField = transform.Find("PasswordInputField").GetComponent<InputField>();
        if (AccountInputField.text.Length == 0)
        {
            AccountInputField.text = "188";
        }

        if (PasswordInputField.text.Length == 0)
        {
            PasswordInputField.text = 123456.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLogin() {
        //GlobalVariables.IPstr = IPInputField.text;
        //GlobalVariables.PortStr = PortInputField.text;

        Automatix.Http httpCli = new Automatix.Http("http://" + GlobalVariables.IPstr + ":");
        httpCli.Post(GlobalVariables.PortStr + "/login/fastLogin");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public class LoginFastLoginReq
    {
        public string mobile;
        public string password;
    }

    public class LoginFastLoginResp
    {
        public string accessToken;
        public int accessExpire;
        public int refreshAfter;
    }


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

    public async void OnClickLogin() {

        string json = JsonUtility.ToJson(new LoginFastLoginReq
        {
            mobile = "1885740001",
            password = "123456"
        });

        string result = await _G.HttpCli.Post("/login/fastLogin", json);
        LoginFastLoginResp resp = JsonUtility.FromJson<LoginFastLoginResp>(result);
    }
}

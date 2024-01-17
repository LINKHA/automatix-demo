using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLogin() {
        //GlobalVariables.IPstr = IPInputField.text;
        //GlobalVariables.PortStr = PortInputField.text;

        Automatix.Http httpCli = new Automatix.Http("http://" + GlobalVariables.IPstr);
        httpCli.Post(GlobalVariables.PortStr + "/login/fastLogin");
    }
}

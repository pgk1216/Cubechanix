using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCoolDown : MonoBehaviour {

    public PlayerMovement movement;
    public Text txt;

    // Update is called once per frame
    void Update()
    {
        if(!movement.jumpIsOnCD) {
            txt.text = "Jump: READY";
        }
        else {
            txt.text = "Jump: " + ((int)movement.jumpCoolDown + 1);
        }
    }
}

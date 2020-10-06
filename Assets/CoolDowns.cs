using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDowns : MonoBehaviour {

    public PlayerMovement movement;
    public Text txt;

    // Update is called once per frame
    void Update() {
        Debug.Log(txt.name);
        if(txt.name == "JumpCoolDown") {
            if (!movement.jumpIsOnCD) {
                txt.text = "Jump: READY";
            }
            else {
                txt.text = "Jump: " + ((int)movement.jumpCoolDown + 1);
            }
        }

        if(txt.name == "FlashCoolDown") {
            if (!movement.flashIsOnCD) {
                txt.text = "Flash: READY";
            }
            else {
                txt.text = "Flash: " + ((int)movement.flashCoolDown + 1);
            }
        }
    }
}

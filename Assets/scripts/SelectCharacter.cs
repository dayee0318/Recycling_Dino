using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public SwitchCharacterScript change;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            change.SwitchAvatar(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            change.SwitchAvatar(2);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            change.SwitchAvatar(3);
        }
    }
}

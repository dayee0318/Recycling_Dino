using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3;
    private Vector3 currentPos;
    

    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
    }

    public void SwitchAvatar(int num)
    {
        switch (num)
        {
            case 1:
                num = 2;

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                avatar3.gameObject.SetActive(false);
                break;


            case 2:
                num = 3;

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(true);



                break;


            case 3:
                num = 1;
                
                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                break;

        }
    }
}

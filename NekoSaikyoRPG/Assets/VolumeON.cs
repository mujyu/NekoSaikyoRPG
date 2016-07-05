using UnityEngine;
using System.Collections;

public class VolumeON : MonoBehaviour
{
    public void VolumeONController()
    {
        bool muteON = true;
        if (muteON == true)
        {
            muteON = false;
            AudioListener.volume = 1f;
        }
        if (muteON == false)
        {
            muteON = true;
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
using System.Collections;

public class VolumeOff : MonoBehaviour
{
    GameObject muteButton;
    public bool muteON = false;//後々、ON・OFFを切り替えられるようにするため

    public void MuteController()
    {
        if (muteON == false)
        {
            muteON = true;
            AudioListener.volume = 0f;
        }
        if (muteON == true)
        {
            muteON = false;
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

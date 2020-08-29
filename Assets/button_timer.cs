using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_timer : MonoBehaviour
{
    public AudioClip otherClip;
    public static int time_chk=0; //0 stop 1 play
    
    public void OnClickPlay() {
        AudioSource audio = GetComponent<AudioSource>();
        time_chk = 1;
        audio.Play();
    }
    public void OnClickStop()
    {
        AudioSource audio = GetComponent<AudioSource>();
        time_chk = 0;
        audio.Pause();
    }
    public void OnClickEnter()
    {
        time_chk = 2;
    }
    public void OnClickEnd()
    {
        time_chk = 3;
    }
}

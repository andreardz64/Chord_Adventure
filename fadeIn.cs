using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour {

    public Text text2;
    public Canvas instructions;
    public Canvas laberynth;
    public Canvas boss;
    public Canvas gameover;
    public Canvas youwin;


    float duration = 4;

    IEnumerator Change()
    {
        yield return new WaitForSeconds(8);
        instructions.enabled = false;
        laberynth.enabled = true;
    }

    // Use this for initialization
    void Start () {
        instructions.enabled = true;
        laberynth.enabled = false;
        boss.enabled = false;
        gameover.enabled = false;
        youwin.enabled = false;

        text2.text = " ";
        StartCoroutine("Change");

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > duration)
        {
            text2.text = "For this you need to match the Chord with its name";
        }
    }



    

    

}

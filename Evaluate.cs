using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Evaluate : MonoBehaviour {

	public Sprite puerta_abierta;
	public Sprite puerta_cerrada;
	public GameObject door1;
	public GameObject door2; 
	public GameObject panel_heart;
	public Text Chord; 
	public AudioClip[] izqAud;
	public AudioClip[] derAud;
    public Canvas laberynth;
    public Canvas boss;
    public Canvas gameover;
    public Canvas youwin;
    public Text Chord2;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject panel_heart2;
    public GameObject panel_heart_boss;



    int[] puertaCorrecta =new int[13] ;
	string[] acordeCorrecto =new string[13] ;


    int currentQuest = 0;
    

    // Use this for initialization
    void Start () {
		puertaCorrecta [0] = 1;
		puertaCorrecta [1] = 2;
		puertaCorrecta [2] = 2;
		puertaCorrecta [3] = 1;
		puertaCorrecta [4] = 2;
		puertaCorrecta [5] = 1;
		puertaCorrecta [6] = 1;
		puertaCorrecta [7] = 2;
		puertaCorrecta [8] = 1;
		puertaCorrecta [9] = 2;
        puertaCorrecta [10] = 2;
        puertaCorrecta [11] = 1;
        puertaCorrecta [12] = 1;

        acordeCorrecto[0] = "F";
		acordeCorrecto [1] = "Cm";
		acordeCorrecto [2] = "G7";
		acordeCorrecto [3] = "E";
		acordeCorrecto [4] = "Am";
		acordeCorrecto [5] = "C";
		acordeCorrecto [6] = "Bm";
		acordeCorrecto [7] = "D";
		acordeCorrecto [8] = "Fm";
		acordeCorrecto [9] = "A7";
        acordeCorrecto [10] = "C#";
        acordeCorrecto [11] = "F#";
        acordeCorrecto [12] = "Em7";

        laberynth.enabled = true;
        boss.enabled = false;
        gameover.enabled = false;
        youwin.enabled = false;
        
    }

    // Update is called once per frame
    void Update () {

	}	
	/*public void EvaluarPuertas(){
		if (puertaCorrecta==1) {
			door1.GetComponent<Image>().sprite= puerta_abierta;
			door2.GetComponent<Image> ().sprite = puerta_cerrada;
		} 
		else {
			door1.GetComponent<Image> ().sprite = puerta_cerrada;
			door2.GetComponent<Image>().sprite= puerta_abierta;
		}
	}*/

	IEnumerator WaitAndChangeQuestion() {
	
		yield return new WaitForSeconds(1);
		currentQuest++;
		door1.GetComponent<Image>().sprite= puerta_cerrada;
		door2.GetComponent<Image> ().sprite = puerta_cerrada;
		door1.GetComponent<AudioSource>().clip=izqAud [currentQuest];
		door2.GetComponent<AudioSource>().clip=derAud [currentQuest];
		Chord.text =acordeCorrecto [currentQuest];

        if (currentQuest == 10)
        {
            laberynth.enabled = false;
            boss.enabled = true;
        }

	}

    IEnumerator ChangeQuestion()
    {

        yield return new WaitForSeconds(1);
        currentQuest++;
        fire1.GetComponent<AudioSource>().clip = izqAud[currentQuest];
        fire2.GetComponent<AudioSource>().clip = derAud[currentQuest];
        Chord2.text = acordeCorrecto[currentQuest];
    }

    public void Door1(){
		// soy la correcta
		if (puertaCorrecta[currentQuest] == 1) {
			// abre   
			door1.GetComponent<Image>().sprite= puerta_abierta;
			// 2 cierra
			door2.GetComponent<Image> ().sprite = puerta_cerrada;
			// espere
           
			StartCoroutine("WaitAndChangeQuestion");
			// reinicie

		}
		else { Destroy(panel_heart.transform.GetChild(0).gameObject);
               Destroy(panel_heart2.transform.GetChild(0).gameObject);
          
            if (panel_heart.transform.childCount ==1)
            {
                laberynth.enabled = false;
                gameover.enabled = true;
                gameover.GetComponent<AudioSource>().Play();

            }
		}
	}


	public void Door2(){
		// soy la correcta
		if (puertaCorrecta[currentQuest] == 2) {
			// abre   
			door2.GetComponent<Image>().sprite= puerta_abierta;
			// 2 cierra
			door1.GetComponent<Image> ().sprite = puerta_cerrada;
			// espere
			StartCoroutine("WaitAndChangeQuestion");
			// reinicie

		}
		else { Destroy(panel_heart.transform.GetChild(0).gameObject);
               Destroy(panel_heart2.transform.GetChild(0).gameObject);
           
            if (panel_heart.transform.childCount == 1)
            {
                laberynth.enabled = false;
                gameover.enabled = true;
                gameover.GetComponent<AudioSource>().Play();
            }
        }
	}

	public void Hover1(){
		door1.GetComponent<AudioSource>().Play();
	}

	public void Hover2(){
		door2.GetComponent<AudioSource>().Play();
	}

	public void Exit1(){
		door1.GetComponent<AudioSource>().Stop();
	}

	public void Exit2(){
		door2.GetComponent<AudioSource>().Stop();
	}


    public void Fire1()
    {
        // soy la correcta
        if (puertaCorrecta[currentQuest] == 1)
        {
            // quita vida al monstruo   
            Destroy(panel_heart_boss.transform.GetChild(0).gameObject);
			if (panel_heart_boss.transform.childCount == 1) {
				boss.enabled = false;
				youwin.enabled = true;
                youwin.GetComponent<AudioSource>().Play();
            } else {
				StartCoroutine ("ChangeQuestion");
			}

        }
        else
        {
            Destroy(panel_heart2.transform.GetChild(0).gameObject);
            
            if (panel_heart2.transform.childCount == 1)
            {
                boss.enabled = false;
                gameover.enabled = true;
                gameover.GetComponent<AudioSource>().Play();
            }
        }
    }


    public void Fire2()
    {
        // soy la correcta
        if (puertaCorrecta[currentQuest] == 2)
        {
            // quita vida al monstruo  
            Destroy(panel_heart_boss.transform.GetChild(0).gameObject);
			if (panel_heart_boss.transform.childCount == 1) {
				boss.enabled = false;
				youwin.enabled = true;
                youwin.GetComponent<AudioSource>().Play();
            } else {
				StartCoroutine ("ChangeQuestion");
			}
        }
        else
        {      
            Destroy(panel_heart2.transform.GetChild(0).gameObject);
            if (panel_heart2.transform.childCount == 1)
            {
                boss.enabled = false;
                gameover.enabled = true;
                gameover.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void Hover3()
    {
        fire1.GetComponent<AudioSource>().Play();
    }

    public void Hover4()
    {
        fire2.GetComponent<AudioSource>().Play();
    }

    public void Exit3()
    {
        fire1.GetComponent<AudioSource>().Stop();
    }

    public void Exit4()
    {
        fire2.GetComponent<AudioSource>().Stop();
    }

    public void Reboot()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }


}


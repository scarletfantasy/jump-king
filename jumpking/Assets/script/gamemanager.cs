using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    int goldnum;
    float x, y;
    bool menu;
    public AudioSource audio;
    public GameObject player;
    public GameObject panel;
    public Text time;
    public GameObject fail;
    static gamemanager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 0;
        fail.SetActive(false);
        goldnum = 0;
        x = -2;
        y = 0;
        menu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            panel.SetActive(true);
            fail.SetActive(false);
            Time.timeScale = 0;
            menu = true;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            x = player.transform.position.x;
            y = player.transform.position.y;

        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            player.transform.position = new Vector3(x, y, 0.0f);
        }
        if((player.transform.position.y<-1)&&(!menu))
        {
            fail.SetActive(true);
            
        }
        else
        {
            fail.SetActive(false);
        }

        time.text ="you have cost:"+ Time.time.ToString().Split('.')[0]+"s \nyou have got "+ instance.goldnum +" coins" ;
    }
    public void startgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        instance.panel.SetActive(false);
        menu = false;
        Time.timeScale = 1;
    }

    public void endgame()
    {
        Application.Quit();
    }

    public static void getcoin()
    {
        instance.goldnum++;
    }
    public void offmusic()
    {
        audio.Stop();
    }
    public void onmusic()
    {
        audio.Play();
    }

}

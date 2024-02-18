using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventGenerater : MonoBehaviour
{
    PlayerData PlayerData;
    Timer TimerData;
    GameObject SystemManager;
    GameObject Timer; 
    GameObject Cat;
    GameObject Bird;
    GameObject Flower;
    bool bEnableCat = false;
    bool bEnableBird = false;
    int NowMin = 0;
    int CacheMin = -1;
    int EventCount = 1;
    public int OccurMin;
    private Animator catAnim;
    private Animator birdAnim;
    private Animator flowerAnim;
    // Start is called before the first frame update
    void Start()
    {
        SystemManager = GameObject.Find("SystemManager");
        PlayerData = SystemManager.GetComponent<PlayerData>();
        Timer = GameObject.Find("Timer");
        TimerData = Timer.GetComponent<Timer>();
        Cat = GameObject.Find("Cat");
        Cat.SetActive(false);
        Bird = GameObject.Find("Bird");
        Bird.SetActive(false);
        Flower = GameObject.Find("Flower");
        Flower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.GameMode == "Study")
        {
            NowMin = TimerData.Min + (TimerData.Hou * 60);
            if(NowMin > 0 && NowMin % OccurMin == 0 && NowMin != CacheMin)
            {
                catAnim = Cat.GetComponent<Animator>();
                birdAnim = Bird.GetComponent<Animator>();
                flowerAnim = Flower.GetComponent<Animator>();
                Cat.SetActive(true);
                if(!bEnableCat) {
                    bEnableCat = true;
                    birdAnim.SetBool("bStartAnim", false);
                    flowerAnim.SetBool("bStartAnim", false);
                    bEnableBird = false;
                    Bird.SetActive(false);
                    Flower.SetActive(false);
                    catAnim.SetBool("bStartAnim", true);
                }
                else {
                    bEnableCat = false; 
                    catAnim.SetBool("bStartAnim", false);
                }
                if(!bEnableBird && !bEnableCat)
                {
                    bEnableBird = true;
                    Bird.SetActive(true);
                    Flower.SetActive(true);
                    birdAnim.SetBool("bStartAnim", true);
                    flowerAnim.SetBool("bStartAnim", true);
                }
                EventCount++;
                CacheMin = NowMin;
            }
        }
        else
        {
            // ...
        }
    }
}

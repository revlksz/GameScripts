using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{ 
    public GameObject shopUIParent;
    public Button whipLevelbutton;
    public Button starLevelbutton;
    public Button gunLevelbutton;
    public Button bombLevelbutton;
    public Button ultiLevelbutton;
    public Button hpLevelbutton;
    public Button speedLevelbutton;
    public Button beklemeLevelbutton;


    public static Upgrade Instance;
    private float timeAge;
    private int whipLevel
    {
        get { return UpgradeManager.Instance.whipLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.whipLevelp.level = value; }//starlevele atama yapar 
    }
    private int starLevel
    {
        get { return UpgradeManager.Instance.starLevelp.level;}// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.starLevelp.level=value;}//starlevele atama yapar 
    }
    private int gunLevel
    {
        get { return UpgradeManager.Instance.gunLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.gunLevelp.level = value; }//starlevele atama yapar 
    }
    private int ultiLevel
    {
        get { return UpgradeManager.Instance.ultiLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.ultiLevelp.level = value; }//starlevele atama yapar 
    }
    private int bombLevel
    {
        get { return UpgradeManager.Instance.bombLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.bombLevelp.level = value; }//starlevele atama yapar 
    }
    private int hpLevel
    {
        get { return UpgradeManager.Instance.hplevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.hplevelp.level = value; }//starlevele atama yapar 
    }
    private int speedLevel
    {
        get { return UpgradeManager.Instance.speedLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.speedLevelp.level = value; }//starlevele atama yapar 
    }
    private int beklemeLevel
    {
        get { return UpgradeManager.Instance.beklemeLevelp.level; }// ok fonksiyonun aynýsý
        set { UpgradeManager.Instance.beklemeLevelp.level = value; }//starlevele atama yapar 
    }
    private bool isUpgradeSceneOpened;
    private bool isWhipLevelFull = false;
    private bool isStarpLevelFull = false;
    private bool isGunLevelFull = false;
    private bool isUltiLevelFull = false;
    private bool isBombLevelFull = false;
    private bool isHpLevelFull = false;
    private bool isSpeedLevelFull = false;
    private bool isBeklemeLevelFull = false;
    void Start()
    {
        Instance = this;
        timeAge = 0; 
    }

    // Update is called once per frame
    void Update()
    {   
        timeAge+= Time.deltaTime;

        if (timeAge >= 120 && !isUpgradeSceneOpened)
            {
            isUpgradeSceneOpened = true;
            Time.timeScale = 0f;
            checkButtons();
            shopUIParent.SetActive(true);
               

            }
        

    }
    public void enableGame()// buttona týklanýldýðýnda bu fonksiyonu çalýþtýr
    {
        isUpgradeSceneOpened = false;
        timeAge = 0;
        Time.timeScale = 1f;
        shopUIParent.SetActive(false);
       

    }
    private void checkButtons()
    {
        whipLevelbutton.enabled = whipLevel != UpgradeManager.Instance.whipLevelp.maxLevel;
        starLevelbutton.enabled = starLevel != UpgradeManager.Instance.starLevelp.maxLevel;
        gunLevelbutton.enabled = gunLevel != UpgradeManager.Instance.gunLevelp.maxLevel;
        bombLevelbutton.enabled = bombLevel != UpgradeManager.Instance.bombLevelp.maxLevel;
        ultiLevelbutton.enabled = ultiLevel != UpgradeManager.Instance.ultiLevelp.maxLevel;
        hpLevelbutton.enabled = hpLevel != UpgradeManager.Instance.hplevelp.maxLevel;
        speedLevelbutton.enabled = speedLevel != UpgradeManager.Instance.speedLevelp.maxLevel;
        beklemeLevelbutton.enabled = beklemeLevel != UpgradeManager.Instance.beklemeLevelp.maxLevel;
    }
    public void WhipLevelChecker()
    {   
        whipLevel++;
        enableGame();
       
    }
   
    public void starLevelchecker()
    {
        starLevel++;
        enableGame();

    }
    public void gunLevelChecker()
    {
        gunLevel++;
        enableGame();
    }
    public void ultiLevelChecker()
    {
        ultiLevel++;
        enableGame();
    }
    public void bombLevelChecker()
    {
        bombLevel++;
        enableGame();
    }
    public void hpLevelChecker()
    {
        hpLevel++;
        enableGame();
    }
    public void speedLevelChecker()
    {
        speedLevel++;
        enableGame();
    }
      
    public void beklemeLevelChecker()
    {   
        beklemeLevel++;
        enableGame();
    }

}

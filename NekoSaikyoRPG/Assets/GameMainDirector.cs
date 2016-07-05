using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMainDirector : MonoBehaviour {
    public static int Lv = 1;
    private static int nekoVal = 1;
    private static int money = 0;
    private static int LvCon = Lv * 10000 / 2;

    GameObject lvText;
    GameObject nekoValText;
    GameObject moneyValText;
    GameObject lvUPConText;
    GameObject clockText;

    //開始時の処理
	void Start () {
        lvText = GameObject.Find("LvText");
        nekoValText = GameObject.Find("NekoValText");
        moneyValText = GameObject.Find("MoneyValText");
        lvUPConText = GameObject.Find("LvUPConText");
        clockText = GameObject.Find("Clock");
        Screen.sleepTimeout = SleepTimeout.NeverSleep;//スリープ禁止にする
        PrefsGet();
        Reload();
    }
	
    //放置時の処理
	void Update () {
        nekoVal += Lv;
        this.nekoValText.GetComponent<Text>().text = ("侵略数：" + nekoVal + "匹");
        PrefsSet();
        System.DateTime nowTime = System.DateTime.Now;
        this.clockText.GetComponent<Text>().text = nowTime.ToString("HH:mm ss");
    }

    //Lvアップボタン押下時
    public void LvUP()
    {
        if(money >= LvCon)
        {
            Lv++;
            money = money - LvCon;
            Reload();
        }

    }

    //ネコイン回収ボタン押下時
    public void MoneyGet()
    {
        money += nekoVal * 2;
        nekoVal = 0;
        Reload();
    }

    //各ボタン押下時に数値を更新
    void Reload()
    {
        LvCon = Lv * 8000;
        this.lvText.GetComponent<Text>().text = ("Lv：" + Lv);
        this.moneyValText.GetComponent<Text>().text = ("おかね：" + money + "ネコイン");
        this.lvUPConText.GetComponent<Text>().text = ("LvUP条件：" + LvCon + "ネコイン");
    }

    //カンスト処理(intの限界値まで)
    void CountStop()
    {
        if (Lv > 2147483647)Lv = 2147483646;
        if (nekoVal > 2147483647)nekoVal = 2147483646;
        if (money > 2147483647) money = 2147483646;
        if (LvCon > 2147483647) LvCon = 2147483646;
    }


    //各数値をセーブする
    void PrefsSet()
    {
        PlayerPrefs.SetInt("Lv", Lv);
        PlayerPrefs.SetInt("nekoVal", nekoVal);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("LvCon", LvCon);
    }

    //各数値をロードする
    void PrefsGet()
    {
        Lv = PlayerPrefs.GetInt("Lv");
        nekoVal = PlayerPrefs.GetInt("nekoVal");
        money = PlayerPrefs.GetInt("money");
        LvCon = PlayerPrefs.GetInt("LvCon");
    }
}

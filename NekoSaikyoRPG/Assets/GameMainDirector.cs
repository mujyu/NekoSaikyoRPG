using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMainDirector : MonoBehaviour {
    private long longMaxVal = long.MaxValue;
    public static long Lv = 1;
    private static long nekoVal = 1;
    private static long money = 0;
    private static long LvCon = Lv * 5000 / 2;//LvUPの値

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
        CountStop();
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
        CountStop();
        LvCon = Lv * 2500;
        this.lvText.GetComponent<Text>().text = ("Lv：" + Lv);
        this.moneyValText.GetComponent<Text>().text = ("おかね：" + money + "ネコイン");
        this.lvUPConText.GetComponent<Text>().text = ("LvUP条件：" + LvCon + "ネコイン");
    }

    //カンスト処理(intの最大値まで)
    void CountStop()
    {
        if (Lv > longMaxVal || Lv < 0) Lv = longMaxVal;
        if (nekoVal > longMaxVal / 2  || nekoVal < 0) nekoVal = longMaxVal / 2;
        if (money > longMaxVal / 2 || money < 0) money = longMaxVal / 2;
        if (LvCon > longMaxVal / 2 || LvCon < 0) LvCon = longMaxVal / 2;
    }


    //各数値をセーブする
    void PrefsSet()
    {
        PlayerPrefsX.SetLong("Lv", Lv);
        PlayerPrefsX.SetLong("nekoVal", nekoVal);
        PlayerPrefsX.SetLong("money", money);
        PlayerPrefsX.SetLong("LvCon", LvCon);
    }

    //各数値をロードする
    void PrefsGet()
    {
        Lv = PlayerPrefsX.GetLong("Lv");
        nekoVal = PlayerPrefsX.GetLong("nekoVal");
        money = PlayerPrefsX.GetLong("money");
        LvCon = PlayerPrefsX.GetLong("LvCon");
    }
}

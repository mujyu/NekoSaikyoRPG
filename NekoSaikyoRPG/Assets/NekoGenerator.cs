using UnityEngine;
using System.Collections;

public class NekoGenerator : MonoBehaviour
{
    public GameObject NekoPrefab;
    private GameObject NekoGo;
    public GameObject NekoKuroPrefab;
    private GameObject NekoKuroGo;
    public GameObject NekoMikePrefab;
    private GameObject NekoMikeGo;
    private float span = 3f;
    private float span2 = 0;
    private float deltaT = 0;
    private float deltaT2 = 0;
    private int NekoStartXVal = 0;
    private int NekoStartYVal = 0;
    private int RanValX = 6;
    private int RanValY = 7;

    //Prefabを生成する。重力計算などはControllerで。
    void Update()
    {
        span = 500 / GameMainDirector.Lv;
        if(GameMainDirector.Lv >= 500)
        {
            span = 1f;
        }
        else if (GameMainDirector.Lv >= 1000)
        {
            span = 0.5f;
        }
        else if (GameMainDirector.Lv >= 5000)
        {
            span = 0.1f;
        }
        else if (GameMainDirector.Lv >= 10000)
        {
            span = 0.001f;
        }

        this.deltaT += Time.deltaTime;
        this.deltaT2 += Time.deltaTime;

        //出現頻度中
        if (this.deltaT > this.span)
        {
            this.deltaT = 0;
            NekoToraPref();
        }
        //出現頻度高
        span2 = span/2;
        if (this.deltaT2 > span2)
        {
            deltaT2 = 0;
            NekoKuroPref();
            NekoMikePref();
        }

    }

    //以下、各色のネコPrefabを用意する。
    void NekoToraPref()
    {
        NekoGo = Instantiate(NekoPrefab) as GameObject;
        NekoStartXVal = Random.Range(RanValX-RanValX*2, RanValX);
        NekoStartYVal = Random.Range(RanValY, RanValY*2);
        NekoGo.transform.position = new Vector3(NekoStartXVal, NekoStartYVal, -6);
    }
    void NekoKuroPref()
    {
        NekoKuroGo = Instantiate(NekoKuroPrefab) as GameObject;
        NekoStartXVal = Random.Range(RanValX - RanValX * 2, RanValX);
        NekoStartYVal = Random.Range(RanValY, RanValY * 2);
        NekoKuroGo.transform.position = new Vector3(NekoStartXVal, NekoStartYVal, -6);
    }
    void NekoMikePref()
    {
        NekoMikeGo = Instantiate(NekoMikePrefab) as GameObject;
        NekoStartXVal = Random.Range(RanValX - RanValX * 2, RanValX);
        NekoStartYVal = Random.Range(RanValY, RanValY * 2);
        NekoMikeGo.transform.position = new Vector3(NekoStartXVal, NekoStartYVal, -6);
    }
}

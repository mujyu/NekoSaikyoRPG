using UnityEngine;
using System.Collections;

public class NekoGenerator : MonoBehaviour
{
    public GameObject NekoPrefab;
    private float span = 5f;
    private float deltaT = 0;
    private GameObject NekoGo;
    private int NekoStartXVal = 0;

    void Update()
    {
        transform.Translate(0, -0.04f, 0);
        this.deltaT += Time.deltaTime;
        if (this.deltaT > this.span)
        {
            this.deltaT = 0;
            NekoGo = Instantiate(NekoPrefab) as GameObject;
            NekoStartXVal = Random.Range(-2, 2);
            NekoGo.transform.position = new Vector3(NekoStartXVal, 6, 6);
        }
        if(NekoGo.transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3(25,0,0);//スポーンする場所
    float elapsedTime;//経過時間
    PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;//毎Fの時間を足していく
        //！は否定なので、！playerControllerScript.gameOverの意味は、「ゲームオーバーではないなら」になる
        //もちろん、PlayerControllerScript.gameOver == falseと書いても同じ。
        if(elapsedTime > 2.0f　&& !playerControllerScript.gameOver)//経過時間が２秒を超えたら
        { 
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//経過時間リセット
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;//リピートの開始軸
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//ゲーム開始時の場所を記憶
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - transform.position.x  > 50.0f)
        {
            transform.position = startPos;//場所をリセット
        }
    }
}

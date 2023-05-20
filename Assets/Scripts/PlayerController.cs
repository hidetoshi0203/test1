using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)　&& isOnGround)//スペースキーが押されたら
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);//上に力を加える
            isOnGround = false;//ジャンプした＝地面にいない
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//ぶつかった相手が(colision)のタグがGroundなら
        {
            isOnGround = true;//地面についている状態に変更
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    public bool gameOver;
    Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)　&& isOnGround && !gameOver)//スペースキーが押されたら かつ　地面にいたら、ゲームオーバーではないのなら
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//上に力を加える
            isOnGround = false;//ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
        }

    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//ぶつかった相手が(colision)のタグがGroundなら
        {
            isOnGround = true;//地面についている状態に変更   
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        { 
            gameOver = true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b", true);//ここで死亡状態ｂにする。（Death_bというのは本来自分で定義できる)
            playerAnim.SetInteger("DeathType_int", 1);//intrgerは整数の意味。死亡のタイプ？を一番目のやつにする的な。
        }
    }
}

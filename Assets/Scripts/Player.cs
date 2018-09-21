using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Spaceshipコンポーネント
    Spaceship spaceship;

    //Start method をコルーチンとして呼び出す
    IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();

        while(true)
        {
            spaceship.Shot(transform);

            //shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    void Update()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動
        spaceship.Move(direction);
    }

    //ぶつかった瞬間に呼び出される
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //弾の削除
        Destroy(collision.gameObject);

        //爆発する
        spaceship.Explosion();

        //プレイヤーを削除
        Destroy(gameObject);
    }
}

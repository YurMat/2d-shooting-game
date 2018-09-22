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

            GetComponent<AudioSource>().Play();

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

        //移動の制御
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        //画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        //移動量を加える
        pos += direction * spaceship.speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    
    }

    //ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        //レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //レイヤー名がBullet(Enemy)のときは弾を削除
        if(layerName == "Bullet(Enemy)")
        {
            Destroy(c.gameObject);
        }
        
        //レイヤー名がBullet(Enemy)またはEnemyの場合は爆発
        if(layerName == "Bullet(Enemy)"|| layerName == "Enemy")
        {
            //爆発する
            spaceship.Explosion();

            //プレイヤーを削除
            Destroy(gameObject);
        }
    }
}

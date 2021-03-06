﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //spaceship コンポーネント
    Spaceship spaceship;

    IEnumerator Start()
    {
        //Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        //ローカル座標のY軸のマイナス方向に移動
        Move(transform.up * -1);

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (spaceship.canShot == false)
        {
            yield break;
        }

        while (true)
        {
            //子要素を全て取得する
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                //ShotPositionの位置/角度で弾を撃つ
                spaceship.Shot(shotPosition);
            }
            //shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    //機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //レイヤー名がBullet(Player)以外のときは何も行わない
        if (layerName != "Bullet(Player)") return;

        //弾の削除
        Destroy(c.gameObject);

        //爆発
        spaceship.Explosion();

        //エネミーの削除
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //spaceship コンポーネント
    Spaceship spaceship;

	// Use this for initialization
	void Start () {

        //Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        //ローカル座標のY軸のマイナス方向に移動
        spaceship.Move(transform.up * -1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

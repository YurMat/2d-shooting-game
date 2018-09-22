using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    public GameObject[] waves;

    //現在のプレハブ
    private int currentWave;

	IEnumerator Start () {
     　　
        //waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
        {
            yield break;
        }

        while (true)
        {
            //waveを作成する
            GameObject wave = (GameObject)Instantiate(waves[currentWave],
                transform.position,
                Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ)
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
	}
}

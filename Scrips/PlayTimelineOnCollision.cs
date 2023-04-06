using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimelineOnCollision : MonoBehaviour
{
    public PlayableDirector timeline;  // 用于存储要播放的timeline

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // 如果玩家碰撞了物体
        {
            timeline.Play();  // 播放timeline
        }
    }
}

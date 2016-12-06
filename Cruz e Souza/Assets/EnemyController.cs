using UnityEngine;
using System.Collections;

public class EnemyController : ObstacleController
{
    public AudioSource soundDestroy;
    public override void DeathAnimation()
    {
        soundDestroy.Play();
        base.DeathAnimation();
    }
}

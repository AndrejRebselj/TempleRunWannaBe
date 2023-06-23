using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningController : MonoBehaviour
{
    [SerializeField]
    List<VisualEffect> vfxs;
    float timer = 1f;
    float randomF = 5f;

    void Update()
    {
        timer-=Time.deltaTime;
        if (timer <= 0) 
        {
            vfxs.ForEach(vfx => { vfx.Play(); });
            timer = Random.Range(1f,5f);
        }
    }
}

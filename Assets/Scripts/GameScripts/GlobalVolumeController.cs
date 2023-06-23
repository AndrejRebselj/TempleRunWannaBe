using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeController : MonoBehaviour
{
    [SerializeField]
    Volume volume;
    LensDistortion ld;
    void Start()
    {
        GameEndTrigger.GameEndTriggered += TriggerCodeChange;
        volume.profile.TryGet(out ld);
        //if (!volume.profile.TryGet(out ld)) throw new Exception("I did not manage to get Lens Distortion");
    }

    private void TriggerCodeChange()
    {
        StartCoroutine(ChangeLensDestortion());
    }

    private IEnumerator ChangeLensDestortion()
    {
        Debug.Log("Zapoceo sam part 1");
        for (int i = 0; i < 100; i++)
        {
            ld.intensity.value-=0.01f;
            yield return null;
        }
        Debug.Log("Zapoceo sam part 2");
        for (int i = 0; i < 100; i++)
        {
            ld.intensity.value += 0.01f;
            yield return null;
        }
        Debug.Log("DONE");
    }

    private void OnDestroy()
    {
        GameEndTrigger.GameEndTriggered -= TriggerCodeChange;
    }
}

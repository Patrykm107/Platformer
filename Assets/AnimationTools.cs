using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTools : MonoBehaviour
{
    public void playSound(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }

    IEnumerator destroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}

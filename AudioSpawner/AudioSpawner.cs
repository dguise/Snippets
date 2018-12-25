using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AudioSpawner
{
    private static List<AudioSource> _pool = new List<AudioSource>();

    public static AudioSource SpawnAudio(this MonoBehaviour mono, AudioClip clip, Vector3? position = null, GameObject parent = null)
    {
        // Fetch from pool & activate component
        var ac = GetOrCreateObjectWithAudioSource();
        ac.gameObject.SetActive(true);

        // Set position & parent
        ac.transform.position = position ?? mono.transform.position;
        if (parent != null)
            ac.transform.SetParent(parent.transform);

        // Play non-looping clip
        ac.loop = false;
        ac.clip = clip;
        ac.Play();

        // Disable after done, lea  ving it up for grabs by pool
        mono.StartCoroutine(Disable(ac));

        return ac;
    }

    private static AudioSource GetOrCreateObjectWithAudioSource()
    {
        // Try to find an object that is disabled in pool
        AudioSource poolObj = _pool.Where(x => !x.gameObject.activeInHierarchy).FirstOrDefault();
        if (poolObj != null)
            return poolObj.GetComponent<AudioSource>();

        // Create new object and add to pool
        GameObject obj = new GameObject("[AudioSpawner Object]", typeof(AudioSource));
        var ac = obj.GetComponent<AudioSource>();
        _pool.Add(ac);
        return ac;
    }

    private static IEnumerator Disable(AudioSource ac)
    {
        yield return new WaitForSeconds(ac.clip.length + 0.1f);
        ac.gameObject.SetActive(false);
    }
}

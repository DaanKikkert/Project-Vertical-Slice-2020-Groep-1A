using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private float effectTimer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GameObject.FindGameObjectWithTag("AudioListener").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float dmg)
    {
        StartCoroutine("HitEffect");
        base.TakeDamage(dmg);
    }

    public override void Death()
    {
        Debug.Log("war");
        Instantiate(deathParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
        playRandomAudio();
        base.Death();
    }

    private void playRandomAudio()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        Debug.Log("Ow");
    }

    private IEnumerator HitEffect()
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(effectTimer);
        _sprite.color = Color.white;
    }

}

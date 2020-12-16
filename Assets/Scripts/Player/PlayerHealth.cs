using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private bool isInvincible = false;
    [SerializeField] private float invincibilityTimer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] _hurtSounds;
    [SerializeField] private SpriteRenderer _headSprite;
    [SerializeField] private SpriteRenderer _bodySprite;
    [SerializeField] private SpriteRenderer _hurtSprite;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioListener").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float _dmg)
    {
        if (isInvincible == false)
        {
            audioSource.clip = _hurtSounds[Random.Range(0, _hurtSounds.Length)];
            audioSource.Play();
            base.TakeDamage(_dmg);
        }
        
        StartCoroutine("IFrames");
    }

    private IEnumerator IFrames()
    {
        Debug.Log("Player turned invincible!");

        isInvincible = true;
        _headSprite.enabled = false;
        _bodySprite.enabled = false;
        _hurtSprite.enabled = true;

        yield return new WaitForSeconds(invincibilityTimer);

        _headSprite.enabled = true;
        _bodySprite.enabled = true;
        _hurtSprite.enabled = false;
        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }

}

using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 5;

    [SerializeField]
    private SimpleAudioEvent onDeathAudioEvent;

    [SerializeField]
    private int points = 100;


    private int currentHealth;

    private AudioSource audioSource;
    private bool characterDead;

    private ZombieGrunt grunt;
    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };
    public event Action<int, int> OnHealthChanged = delegate { };

    private void Awake()
    {
        OnDied += DeathSound_OnDied;
        OnDied += AddPoints_OnDied;
        grunt = GetComponent<ZombieGrunt>();
    }

    private void DeathSound_OnDied()
    {
        if(audioSource != null &&  onDeathAudioEvent != null)
            onDeathAudioEvent.Play(audioSource);
    }

    private void OnEnable()
    {
        currentHealth = health;

    }
    public void TakeHit(int damage)
    {
        ModifyHealth(-damage);
        if (currentHealth > 0)
            OnTookHit();
        else if (!characterDead)
        {
            if (gameObject.GetComponent<PlayerMovement>() != null)
                GameManager.instance.Reload();
            OnDied();
            characterDead = true;
            if (grunt != null)
                grunt.enabled = false;
        }

    }

    private void ModifyHealth(int amount)
    {
        currentHealth += amount;
        OnHealthChanged(currentHealth,health);
    }

    private void AddPoints_OnDied()
    {
        GameManager.instance.increaseGameScore(points);
    }

  



}

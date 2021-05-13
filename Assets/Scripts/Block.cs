using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticle;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] AudioClip[] noBreaksounds;


    // Cached
    Level level;
    GameSession gameStatus;
    AudioSource myAudioSource;

    //state
    [SerializeField] int totalHits;

    public void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        myAudioSource = GetComponent<AudioSource>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();

        }

    }
    private void HandleHit()
    {
        int maxHits = hitSprites.Length + 1;
        totalHits++;
        if (totalHits >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    public void ShowNextHitSprites()
    {
        int spriteIndex = totalHits - 1;
        
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            if (noBreaksounds.Length > 0)
            {
                PlayHitSound();
            }
        }
        else
        {
            Debug.LogError("Block sign is missing from Array" + gameObject.name);
        }
    }

    private void PlayHitSound()
    {
        
        AudioClip noBreakSound = noBreaksounds[Random.Range(0, noBreaksounds.Length)];
        myAudioSource.PlayOneShot(noBreakSound);
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.DestroyedBlock();
        TriggerParticle();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    public void TriggerParticle()
    {
        GameObject particles = Instantiate(blockParticle, transform.position, transform.rotation);
        Destroy(particles, 1f);
       
    }
}

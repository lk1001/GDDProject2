using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : MonoBehaviour
{
    #region Movement Variables
    [SerializeField]
    [Tooltip("Enemy speed")]
    private float moveSpeed;

    public Transform player;
    public bool enemySpotted;
    public bool wallProximity;

    Rigidbody2D enemyRB;
    private float idleCooldown;
    private Vector2 idlePushDirection;
    private Vector2 idlePushVelocity;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemySpotted = false;
    }

    public void Start()
    {
        transform.position = new Vector2(Random.Range(-24f, 19f), Random.Range(-10f, 10f));
        idleCooldown = Random.Range(1.0f,5.0f);
    }
    #endregion

    #region Updates
    private void Update()
    {
        Move();
    }
    #endregion

    #region Movement Functions
    private void Move()
    {
        if (enemySpotted)
        {
            Vector2 direction = player.position + transform.position;

            if (wallProximity)
            {
                direction = -direction;
            }

            enemyRB.velocity = direction.normalized * moveSpeed;
        }
        else if (idleCooldown <= 0)
        {
        
            idlePushDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            idlePushVelocity = idlePushDirection * 500;
            enemyRB.AddRelativeForce(idlePushVelocity);
            idleCooldown = 2f;
        }
        else
        {
            idleCooldown -= Time.deltaTime;
        }

    }
    #endregion

    #region Health? Functions
    bool isPlayer(GameObject obj)
    {
        return obj.CompareTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayer(collision.gameObject))
        {
            FindObjectOfType<ScoreManager>().AddScore(1);
            Destroy(this.gameObject);

        }
    }
    #endregion

}

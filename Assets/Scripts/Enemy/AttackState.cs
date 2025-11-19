using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    private float minDistance = 8f; // حداقل فاصله مجاز بین دشمن و پلیر

    // public Animator enemyenemyAnimator;

    private float shootCooldown = 1f; // یعنی هر 1.5 ثانیه یک‌بار شلیک کنه
    private float lastShootTime = -999f; // اول بازی عدد خیلی پایین باشه تا بتونه فوراً شلیک کنه

    // public AudioSource enemyAudio;
    // public AudioClip shootClip;

    public override void Enter()
    {

    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.Player.transform.position);

            enemy.enemyAnimator.SetBool("attackMod", true);

            // اگر بیش از حد نزدیک شد، عقب بره
            if (distanceToPlayer < minDistance)
            {
                Vector3 pushBackDirection = (enemy.transform.position - enemy.Player.transform.position).normalized;
                enemy.Agent.SetDestination(enemy.transform.position + pushBackDirection * 2f); // کمی عقب بره
                enemy.enemyAnimator.SetBool("shooting", false);
            }
            else
            {
                // اگر فاصله مناسب بود، شلیک کنه
                if (shotTimer > enemy.fireRate)
                {
                    if (Time.time - lastShootTime > shootCooldown)
                    {
                        lastShootTime = Time.time;
                        enemy.enemyAnimator.SetBool("shooting", true);
                        Shoot();
                    }
                    else
                    {
                        enemy.enemyAnimator.SetBool("shooting", false);
                    }
                }
                else
                {
                    enemy.enemyAnimator.SetBool("shooting", false);
                }
            }

            if(moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        AudioSource audio = enemy.GetComponent<AudioSource>();
        audio.Play();

        Transform gunbarrel = enemy.gunBarrel;

        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        bullet.GetComponent<Bullet>().shooter = enemy.gameObject; // تنظیم دشمن به عنوان شلیک‌کننده
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(Random.Range(-1f, 1f), Vector3.up) * shootDirection * 60;
        Debug.Log("Shoot");
        shotTimer = 0;
    }

    public override void Exit()
    {
        
    }
}

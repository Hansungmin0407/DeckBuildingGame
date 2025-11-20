using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class GameRuleMaster : MonoBehaviour
{

    public AniController playerAnimator;

    public float hitDelay = 1.0f;
    public float runningAnimTime = 7.0f;
    public bool isAttacking = false;
    private int currentStage = 0;

    public GameObject DiceMachine;

    //1. 다이스 정보 가져오기

    //- 다이스 값
    //- 플레이어의 선택한 키워드
    //- 다이스 개수 X 선택 키워드 

    public GameObject ItemManager;

    //2. 아이템 정보 가져오기

    //- 아이템 키워드
    //- 아이템 효과
    public GameObject Enemy;

    //3. 몬스터 정보 가져오기

    //- 몬스터 체력
    //- 몬스터 디버프

    //=============

    // 데미지 산출



    //=============

    DiceMachine diceMachine;

    ItemManager itemManager;

    public Startmenu startmenu;

    public List<Monster> Monsters;
    public AudioSource preAttackAudio;
    public AudioSource attackAudio;
    public ParticleSystem attackEffect;

    void Start()
    {
        diceMachine = DiceMachine.GetComponentInChildren<DiceMachine>();
        itemManager = ItemManager.GetComponentInChildren<ItemManager>();
        if (Enemy != null)
        {
            Monsters = new List<Monster>(Enemy.GetComponentsInChildren<Monster>());
        }

        Debug.Log("Game Rule Master is Running");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            diceMachine.RollDice();
        }

        if (diceMachine.playerSelectDiceCount > 0 && !isAttacking)
        {
            StartCoroutine(PlayerAttack(diceMachine.playerSelectDiceCount));
            diceMachine.playerSelectDiceCount = 0;
        }
    }

    private IEnumerator PlayerAttack(int count)
    {
        isAttacking = true;
        diceMachine.playerInput = false;

        playerAnimator.AttackAni();

        float targetVolume = 0.1f;
        float timer = 0f;
        preAttackAudio.volume = 0f;
        preAttackAudio.Play();

        while (timer < hitDelay)
        {
            timer += Time.deltaTime;
            preAttackAudio.volume = Mathf.Lerp(0f, targetVolume, timer / hitDelay);
            yield return null;
        }

        if (currentStage >= Monsters.Count)
        {
            isAttacking = false;
            yield break;
        }

        preAttackAudio.Stop();
        Monster currentMonster = Monsters[currentStage];
        if (attackEffect != null)
        {
            attackEffect.Play();
            attackAudio.Play();
        }
        int Damage = count * 10;
        float monsterAnimTime = currentMonster.TakeDamage(Damage);

        yield return new WaitForSeconds(monsterAnimTime);

        if (currentMonster.IsDead())
        {
            currentStage++;
            if (!(currentStage >= Monsters.Count))
            {
                StartCoroutine(playerAnimator.NextBattle(38.0f));

                yield return new WaitForSeconds(runningAnimTime);
            }
            else
            {
                playerAnimator.VictoryAni();
                playerAnimator.jumpAudio.Play();
                yield return new WaitForSeconds(1.0f);
                playerAnimator.kirat.Play();
                yield return new WaitForSeconds(hitDelay * 3);

                StartCoroutine(playerAnimator.NextBattle(38.0f));
                startmenu.StageClear();

                yield break;
            }
        }

        isAttacking = false;
        diceMachine.RollDice();
        diceMachine.playerInput = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class MVP : MonoBehaviour
{
    EnemyModel enemyModel;
    [SerializeField]
    private Button attackButton;
    [SerializeField]
    private Text hpText;
    void Start()
    {
        enemyModel = new EnemyModel(200);
        attackButton.OnClickAsObservable().Subscribe(_ => 
        {
            enemyModel.HP.Value -= 50;
        });
        enemyModel.HP.SubscribeToText(hpText);
        enemyModel.IsDead.Where(isDead => isDead).Select(isDead => !isDead).SubscribeToInteractable(attackButton);
    }
}

public class EnemyModel
{
    public LongReactiveProperty HP;
    public IReadOnlyReactiveProperty<bool> IsDead;

    public EnemyModel(long initialHP)
    {
        HP = new LongReactiveProperty(initialHP);
        IsDead = HP.Select(hp=>hp <= 0).ToReactiveProperty();
    }
}

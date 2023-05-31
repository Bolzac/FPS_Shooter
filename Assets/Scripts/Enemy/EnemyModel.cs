using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy")]
public class EnemyModel : ScriptableObject
{
    public string enemyName;
    [TextArea] public string description;
    public Health enemyHealth;
}

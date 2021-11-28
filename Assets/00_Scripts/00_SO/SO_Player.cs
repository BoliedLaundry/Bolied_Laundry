using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Player", menuName = "SO/SO_Player", order = 2)]
public class SO_Player : ScriptableObject
{
    [SerializeField] int money;
    public int Money => money;

    [SerializeField] float happyCount;
    public float HappyCount => happyCount;

    [SerializeField] bool isMove;
    public bool IsMove => isMove;

    public void setMove(bool _type) { isMove = _type; }
}

﻿using UnityEngine;
using System.Collections;

// 训练俘兵
public class TrainCaptiveCommand : ITrainCommand
{     
    private PBaseDefenseGame m_PBDGame = null;
    private ENUM_Enemy         m_emEnemy; // 兵种
    private Vector3        m_Position; // 出现位置
   
    public TrainCaptiveCommand(ENUM_Enemy emEnemy, Vector3 Position,PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
        m_emEnemy = emEnemy;
        m_Position = Position;
    }
   
    public override void Execute()
    {
        // 先产生Enemy
        ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
        IEnemy theEnemy = Factory.CreateEnemy ( m_emEnemy, ENUM_Weapon.Gun , m_Position ,Vector3.zero);

        // 再建立俘兵(转接器)
        SoldierCaptive NewSoldier = new SoldierCaptive( theEnemy );
            
        // 移除Enemy
        m_PBDGame.RemoveEnemy( theEnemy );

        // 加入Soldier
        m_PBDGame.AddSoldier( NewSoldier );
    }     
}
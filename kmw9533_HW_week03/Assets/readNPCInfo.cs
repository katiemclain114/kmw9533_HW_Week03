using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readNPCInfo : MonoBehaviour
{
    private const string DIR_LOGS = "/Logs";
    private const string FILE_NPC = DIR_LOGS + "/npcInfo.csv";
    private string FILE_PATH_NPC;

    private List<NPC> npcs = new List<NPC>();
    
    private void Start()
    {
        FILE_PATH_NPC = Application.dataPath + FILE_NPC;

        string[] npcData = File.ReadAllText(FILE_PATH_NPC).Split(new char[] {'\n'});
        Debug.Log(npcData[4]);

        for (int i = 0; i < npcData.Length - 1; i++)
        {
            string[] row = npcData[i].Split(new char[] {','});
            NPC npc = new NPC();
            npc.name = row[0];
            npc.age = Int32.Parse(row[1]);
            npc.location = row[2];
            npc.questGiver = row[3];
            
            npcs.Add(npc);
        }

        foreach (NPC npc in npcs)
        {
            Debug.Log(npc.name);
        }

    }
}

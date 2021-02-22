using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readNPCInfo : MonoBehaviour
{
    //directory and file for filepath
    private const string DIR_LOGS = "/Logs";
    private const string FILE_NPC = DIR_LOGS + "/npcInfo.csv";
    private string FILE_PATH_NPC;

    //list of all NPCs
    private List<NPC> npcs = new List<NPC>();
    
    private void Start()
    {
        //sets file path
        FILE_PATH_NPC = Application.dataPath + FILE_NPC;

        //reads in all data from path and splits it into seperate rows
        string[] npcData = File.ReadAllText(FILE_PATH_NPC).Split(new char[] {'\n'});
        Debug.Log(npcData[4]);

        //seperate rows into name, age, loc, and, quest giver
        for (int i = 0; i < npcData.Length - 1; i++)
        {
            string[] row = npcData[i].Split(new char[] {','});
            NPC npc = new NPC();
            npc.name = row[0];
            npc.age = Int32.Parse(row[1]);
            npc.location = row[2];
            npc.questGiver = row[3];
            
            //add npc to list
            npcs.Add(npc);
        }

        foreach (NPC npc in npcs)
        {
            Debug.Log(npc.age);
        }

    }

    private void Update()
    {
        //test the write to file 
        if (Input.GetKeyDown(KeyCode.A))
        {
            WriteToNpcInfo();
            foreach (NPC npc in npcs)
            {
                Debug.Log(npc.name);
            }
        }
    }

    //writes new npc to file and adds to file
    void WriteToNpcInfo()
    {
        string currentFile = File.ReadAllText(FILE_PATH_NPC);
        NPC npc = new NPC();
        npc.name = "Katie";
        npc.age = 23;
        npc.location = "new yerk";
        npc.questGiver = "false";
        
        npcs.Add(npc);
        
        File.WriteAllText(FILE_PATH_NPC, currentFile + npc.name + "," + npc.age + "," + npc.location + "," + npc.questGiver + "\n");
    }
}

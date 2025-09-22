using System;

[Flags]
public enum OptionState
{
    None     = 1 << 0,             // ����Ʈ ������ (1)
    isAccept = 1 << 1,             // ��        ��  (2)
    isReject = 1 << 2,             // ��        ��  (4)
    isClear  = 1 << 3              // Ŭ����    ��  (8)
}

[Serializable]
public class DialogDBs 
{
    public int Id;
    public int NPC_Id;
    public string Text;
    public string Choice1;
    public int Choice1_Next_Id;
    public string Choice2;
    public int Choice2_Next_Id;
    public OptionState State;
    public int Quest_Id;
    public int Clear_Id;
}

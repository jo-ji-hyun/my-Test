using System;

[Flags]
public enum ItemFlags
{
    None = 1 << 0,         // 0001 (1)
    isAcquired = 1 << 1,   // 0010 (2)  
    isBroken = 1 << 2,     // 0100 (4)

    isWindowOpen = isAcquired | isBroken,   // �Ѵ� ������ (6)
}

[Serializable]
public class ItemDBs
{
    // === ������ ���� ===
    public int id;
    public string name;
    public string description;
    public int attack;
    public string image_path;
    public float PosX;
    public float PosY;
    public ItemFlags Flags;
    public int Width;
    public int Length;
}

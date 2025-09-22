using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "04.Externals/Resources/DB")]
public class Quests : ScriptableObject
{
	public List<QuestDBs> QuestSheet;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public valueLevel bombLevelp;
    public genericLevel<Bullet> gunLevelp;
    public genericLevel<Bullet> starLevelp;
    public genericLevel<bomb> ultiLevelp;
    public valueLevel whipLevelp;
    public valueLevel hplevelp;
    public valueLevel damageLevelp;
    public valueLevel beklemeLevelp;
    public valueLevel speedLevelp;


    [System.Serializable]
    public class genericLevel<T> : levels
    {
        public new int maxLevel => list.Count;
        public List<T> list;
        public T value => list[index];
        public int index => level - 1;
    }
    
    [System.Serializable]
    public class levels
    {
        private int _level = 1;
        public int level
        {
            get { return _level; }
            set 
            {
                if(value >=maxLevel)
                {
                    _level = maxLevel;
                }
                else
                {
                    _level = value;
                }
            }
        }
        public int maxLevel = 4;
    }
    [System.Serializable]
    public class valueLevel : genericLevel<float> 
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

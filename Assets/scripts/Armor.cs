using Job;
using System;

public class Armor{

    private string name;
    private int def;
    private string type;
    private string desc;
    private bool[] canUse;

    public Armor(string name, int def, string type, string desc, int canUse){
        this.name = name;
        this.def = def;
        this.type = type;
        this.desc = desc;
        this.canUse = new bool[3];
        string binary = Convert.ToString(canUse, 2);
        for (int i = 0; i < binary.Length; i++){
            if (binary[i] == 1){
                this.canUse[i] = true;
            }else{
                this.canUse[i] = false;
            }
        }
    }

    public string GetName() { return this.name; }
    public int GetDef() { return this.def; }
    public string GetType() { return this.type; }
    public string GetDesc() { return this.desc; }
    public bool GetCanUse(int job) { return this.canUse[job]; }

    public void SetName(string name) { this.name = name; }
    public void SetAtk(int def) { this.def = def; }
    public void SetType(string type) { this.type = type; }
    public void SetDesc(string desc) { this.desc = desc; }

}

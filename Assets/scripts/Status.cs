using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status {
    private int hp;
    private int atk;
    private int def;
    private float speed;
    private float respawnTime;

    public Status(int hp, int atk, int def, float speed, float respawnTime) {
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.speed = speed;
        this.respawnTime = respawnTime;
    }

    public bool IsDead() {
        if (this.hp <= 0) {
            return true;
        }

        return false;
    }

    public int GetHp() { return this.hp; }
    public int GetAtk() { return this.atk; }
    public int GetDef() { return this.def; }
    public float GetSpeed() { return this.speed; }
    public float GetRespawnTime() { return this.respawnTime; }

    public void SetHp(int hp) { this.hp = hp; }
    public void SetAtk(int atk) { this.atk = atk; }
    public void SetDef(int def) { this.def = def; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetRespawnTime(float respawnTime) { this.respawnTime = respawnTime; }


}
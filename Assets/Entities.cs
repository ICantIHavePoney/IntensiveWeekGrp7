using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities {

    private int speed;
    private int jumpHeight;
    private bool canMoveRight;
    private bool canMoveLeft;
    private bool canDash;
    private bool doubleJump;
    private bool canJump;
    private bool canDoubleJump;
    private float newDash;
    private float dashTimer;
    private float gravity;



    public Entities()
    {

        this.speed = 10;
        this.jumpHeight = 10;
        this.canDash = false;
        this.canMoveLeft = false;
        this.canMoveRight = false;
        this.canJump = false;
        this.canDoubleJump = false;
        this.doubleJump = false;
        this.newDash = 0;
        this.dashTimer = 0.5f;
        this.gravity = 20;

    }

public int getSpeed(){
  return this.speed;
}

public int getJumpHeight(){
  return this.jumpHeight;
}

public bool getCanDash(){
  return this.canDash;
}

public bool getCanMoveLeft(){
  return this.canMoveLeft;
}

    public bool getCanMoveRight()
    {
        return this.canMoveRight;
    }

    public bool getCanJump(){
  return this.canJump;
}

public bool getCanDoubleJump(){
  return this.canDoubleJump;
}

public bool getDoubleJump(){
  return this.doubleJump;
}

public float getNewDash(){
  return this.newDash;
}

public float getDashtimer(){
  return this.dashTimer;
}

public float getGravity(){
  return this.gravity;
}

public void setSpeed(int s){
  this.speed = s;
}

public void setJumpHeight(int jH){
  this.jumpHeight = jH;
}

public void setCanDash(bool cD){
  this.canDash = cD;
}

public void setCanMoveLeft(bool cML){
  this.canMoveLeft = cML;
}
    public void setCanMoveRight(bool cMR)
    {
        this.canMoveRight = cMR;
    }

    public void setCanJump(bool cJ){
  this.canJump = cJ;
}

public void setCanDoubleJump(bool cDJ){
  this.canDoubleJump = cDJ;
}

public void setDoubleJump(bool dJ){
  this.doubleJump = dJ;
}

public void setNewDash(float nD){
  this.newDash = nD;
}

public void setDashtimer(float dT){
  this.dashTimer = dT;
}

public void setGravity(float g){
  this.gravity = g;
}






}

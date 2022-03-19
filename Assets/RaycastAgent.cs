using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;



// RaycastAgent
public class RaycastAgent : Agent
{

    Rigidbody rBody;
    int lastCheckPoint;
    int checkPointCount;

    // 初期化時に呼ばれる
    public override void Initialize()
    {
        this.rBody = GetComponent<Rigidbody>();
    }

    // エピソード開始時に呼ばれる
    public override void OnEpisodeBegin()
    {
        //リセット
        this.lastCheckPoint = 0;
        this.checkPointCount = 0;

    }

    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(rBody.velocity.x); // RollerAgentのX速度
        sensor.AddObservation(rBody.velocity.z); // RollerAgentのZ速度
    }

    // 行動実行時に呼ばれる
    public override void OnActionReceived(float[] vectorAction)
    {
       


        // RaycastAgentに力を加える
        Vector3 dirToGo = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;
        int action = (int)vectorAction[0];
    
        if(action == 1) dirToGo = transform.forward;
        if(action == 2) dirToGo = transform.forward *-1.0f;
        if(action == 3) rotateDir = transform.up *-1.0f;　//rotate
        if(action == 4) rotateDir = transform.up;
        this.transform.Rotate(rotateDir, Time.deltaTime*200f);
        this.rBody.AddForce(dirToGo * 0.4f, ForceMode.VelocityChange);


    
        //ステップ度の報酬
      AddReward(-0.001f); // 常に動くように

       
    }


               
 // checkpointに衝突時
    public void EnterCheckPoint(int checkPoint){
        if(checkPoint == (this.lastCheckPoint+1)%4){ 
           this.checkPointCount++;

            if(this.checkPointCount >= 4){//一周の確認
                AddReward(2.0f);
                EndEpisode();
            }
        }else if(checkPoint == (this.lastCheckPoint - 1 +4 )%4){　//戻るのcheckpointを触ったら、減点
            this.checkPointCount--;
        }

        //最終チェックポイントの更新
        this.lastCheckPoint = checkPoint;
    }


    // ヒューリスティックモードの行動決定時に呼ばれる
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0]=0;
        if(Input.GetKey(KeyCode.UpArrow)) actionsOut[0]=1;
        if(Input.GetKey(KeyCode.DownArrow)) actionsOut[0]=2;
        if(Input.GetKey(KeyCode.LeftArrow)) actionsOut[0]=3;
        if(Input.GetKey(KeyCode.RightArrow)) actionsOut[0]=4;
    }
}
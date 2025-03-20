using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class KejarBot : Bot
{   
    int turnDirection = 1;  // Untuk menentukan kiri atau kanan

    static void Main(string[] args)
    {
        new KejarBot().Start();
    }

    KejarBot() : base(BotInfo.FromFile("KejarBot.json")) { }

    public override void Run(){
        BodyColor = Color.Black;
        TurretColor = Color.DarkRed;
        RadarColor = Color.Orange;
        ScanColor = Color.Yellow;
       
        while (IsRunning){
            TurnLeft(20*turnDirection);
        }
    }

    /* Algoritma Greedy: Setiap melihat musuh, tembak lalu dekati (mengejar) tetapi tidak menabrak. */
    /* Jika terlalu dekat, tidak perlu menabrak */
    public override void OnScannedBot(ScannedBotEvent e){
        Fire(3);

        TurnToFaceTarget(e.X, e.Y);
        var distance = DistanceTo(e.X, e.Y);
        if(distance > 50){
            Forward(distance - 50);
        }
    }

    private void TurnToFaceTarget(double x, double y){
        var bearing = BearingTo(x, y);
        if (bearing >= 0)
            turnDirection = 1;
        else
            turnDirection = -1;
        TurnLeft(bearing);
    }

    public override void OnHitWall(HitWallEvent e){
        TurnRight(180);
        Forward(100);
    }
}
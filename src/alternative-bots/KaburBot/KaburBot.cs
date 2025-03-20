using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class KaburBot : Bot
{   
    private double lastEnemyDistance = double.MaxValue;
    private const double SAFE_DISTANCE = 400;
    private Random random = new Random();

    static void Main(string[] args)
    {
        new KaburBot().Start();
    }

    KaburBot() : base(BotInfo.FromFile("KaburBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.Green;
        TurretColor = Color.DarkGreen;
        RadarColor = Color.LightGreen;
        ScanColor = Color.Yellow;

        GunTurnRate = 20;

        /* Algoritma Greedy: Selalu bergerak untuk meminimalisir terkena tembakan */
        while (IsRunning){
            BodyColor = Color.Green;    // Untuk keperluan debugging

            Forward(400);
        }
    }

    /* Algoritma Greedy: Ketika melihat musuh yang dekat, 
    berpindah arah agar tidak sejajar dengan musuh dan tidak terkena tembakan */
    public override void OnScannedBot(ScannedBotEvent e)
    {
        Fire(3);

        lastEnemyDistance = DistanceTo(e.X, e.Y);

        if (lastEnemyDistance < SAFE_DISTANCE){
            BodyColor = Color.Yellow;
            double randomAngle = random.NextDouble() * 120 + 30;
            TurnRight(randomAngle);
            Forward(100);
        }
        
    }

    public override void OnHitWall(HitWallEvent e){
        TurnRight(180);
        Forward(100);
    }

    public override void OnHitBot(HitBotEvent e){
        Back(50);
        TurnRight(90 + random.Next(90));
        Forward(100);
    }
}
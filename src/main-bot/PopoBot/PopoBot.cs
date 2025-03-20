using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System.Drawing;

// ------------------------------------------------------------------
// Popo-Bot
// ------------------------------------------------------------------
// A bot that destined to win -created by popo?? shiroyoo~.
// ------------------------------------------------------------------
public class PopoBot : Bot
{
    private double spiralDistance = 100;
    private double angleIncrement = 10;

    static void Main(string[] args)
    {
        new PopoBot().Start();
    }

    PopoBot() : base(BotInfo.FromFile("PopoBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.Blue;
        TurretColor = Color.Yellow;
        RadarColor = Color.Blue;
        ScanColor = Color.Yellow;

        GunTurnRate = 15;

        /* Algoritma Greedy: Selalu bergerak agar meminimalisir ditembak musuh. */
        /* Bergerak secara spiral, dengan lama-lama semakin jauh dan anglenya menaik, tetapi di cap ke 500. */
        while (IsRunning)
        {
            if(spiralDistance > 500){
                spiralDistance = 100;
                angleIncrement = 10;
            }
            Forward(spiralDistance);
            TurnRight(angleIncrement);

            spiralDistance += 5;
            angleIncrement += 0.5;
        }
    }

    /* Algoritma Greedy: Setiap melihat musuh, DORRRR! */
    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(3);
    }

    public override void OnHitBot(HitBotEvent e)
    {
        if (e.IsRammed)
        {
            TurnRight(30);
            Forward(50);
        }
    }
}
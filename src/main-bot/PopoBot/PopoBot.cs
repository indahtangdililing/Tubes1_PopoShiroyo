using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System.Drawing;

// ------------------------------------------------------------------
// PopoBot
// ------------------------------------------------------------------
// A bot that moves in a spiral pattern, firing when an enemy is detected.
// ------------------------------------------------------------------
public class PopoBot : Bot
{
    private double spiralDistance = 100;
    private double angleIncrement = 10;

    // The main method starts our bot
    static void Main(string[] args)
    {
        new PopoBot().Start();
    }

    // Constructor, which loads the bot config file
    PopoBot() : base(BotInfo.FromFile("PopoBot.json")) { }

    // Called when a new round is started -> initialize and do some movement
    public override void Run()
    {
        BodyColor = Color.Blue;
        TurretColor = Color.Yellow;
        RadarColor = Color.Blue;
        ScanColor = Color.Yellow;

        GunTurnRate = 15;

        // Repeat while the bot is running
        while (IsRunning)
        {
            if(spiralDistance > 500){
                spiralDistance = 100;
                angleIncrement = 10;
            }
            // Move forward by current spiral distance
            Forward(spiralDistance);
            // Turn slightly to create spiral motion
            TurnRight(angleIncrement);

            // Gradually increase the distance and angle for spiral effect
            spiralDistance += 5;
            angleIncrement += 0.5;
        }
    }

    // We scanned another bot -> fire!
    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(3);
    }

    // We hit another bot -> adjust the movement slightly
    public override void OnHitBot(HitBotEvent e)
    {
        if (e.IsRammed)
        {
            // Change direction slightly to avoid getting stuck
            TurnRight(30);
            Forward(50);
        }
    }
}
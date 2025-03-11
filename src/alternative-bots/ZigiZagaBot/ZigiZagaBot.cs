using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System.Drawing;

public class ZigiZagaBot : Bot
{
    private double moveDistance = 1000;  // Jarak zigzag
    private double turnAngle = 145;      // Sudut zigzag
    private bool isMovingForward = true;
    private int moveCount = 0;
    private readonly int MAX_MOVES = 3;  // Berapa kali zigzag sebelum mengubah arah

    static void Main(string[] args)
    {
        new ZigiZagaBot().Start();
    }

    ZigiZagaBot() : base(BotInfo.FromFile("ZigiZagaBot.json")) { }

    public override void Run()
    {
        // Set warna bot
        BodyColor = Color.Red;
        TurretColor = Color.Blue;
        RadarColor = Color.Red;
        ScanColor = Color.Blue;

        // Set kecepatan putaran senjata
        GunTurnRate = 15;
        
        while (IsRunning)
        {
            // Implementasi gerakan zigzag
            if (moveCount >= MAX_MOVES)
            {
                isMovingForward = !isMovingForward;
                moveCount = 0;
            }

            // Gerak maju/mundur
            if (isMovingForward)
            {
                Forward(moveDistance);
            }
            else
            {
                Back(moveDistance);
            }

            // Berbelok ke kanan/kiri secara bergantian
            if (moveCount % 2 == 0)
            {
                TurnRight(turnAngle);
            }
            else
            {
                TurnLeft(turnAngle);
            }

            // Putar radar terus menerus
            //TurnRadarRight(360);
            
            moveCount++;
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(3);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        TurnRight(30);
        Forward(50);
        moveCount = 0;
    }

    public override void OnHitBot(HitBotEvent e)
    {
        // Hindari bot lain
        TurnRight(30);
        Forward(50);
    }
}
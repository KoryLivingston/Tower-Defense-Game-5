Public Class Form1

    Public currentEnemies As New List(Of Enemy)
    Public EnemiesLeft As Integer
    Dim WaveEnded As Boolean

    Dim NumberOfGoblins As Integer
    Dim PicGoblins(-1) As PictureBox
    Dim IntCount As Integer
    Dim GoblinCount As Integer

    Dim Goblin(-1) As Enemy

    Public Lives As Integer = 11
    Public Coins As Integer = 50
    Public Wave As Integer = 1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SpawnGoblins(5)

        If Wave = 2 Then
            ReDim Preserve PicGoblins(-1)
            ReDim Preserve Goblin(-1)
            IntCount = 0
            GoblinCount = 0
            SpawnGoblins(10)
        End If


    End Sub


    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        StartButton.Hide()
        QuitButton.Hide()

        EnemyLogic.Enabled = True
        EnemyLogic.Start()

        GameLogic.Enabled = True
        GameLogic.Start()

        WaveEndingTimer.Enabled = True
        WaveEndingTimer.Start()

    End Sub
    Private Sub GameLogic_Tick(sender As Object, e As EventArgs) Handles GameLogic.Tick

        LblLives.Text = "LIVES " & Lives
        LblCoins.Text = "COINS " & Coins
        LblWaves.Text = "WAVE " & Wave


        If Lives = 0 Then
            Endgame()
        End If

    End Sub



    Private Sub EnemyLogic_Tick(sender As Object, e As EventArgs) Handles EnemyLogic.Tick

        For counter = 0 To EnemiesLeft - 1
            Goblin(counter).Move()
            Goblin(counter).EnemyReachedBase()
        Next



    End Sub

    Public Sub SpawnGoblins(GoblinNumber As Integer)


        NumberOfGoblins = GoblinNumber

        For counter = 0 To NumberOfGoblins - 1

            ReDim Preserve PicGoblins(IntCount)
            PicGoblins(counter) = New PictureBox
            PicGoblins(counter).Location = New Point(-800 + (counter * 50), 288)
            PicGoblins(counter).Size = New Size(30, 30)
            PicGoblins(counter).BackColor = Color.Green
            PicGoblins(counter).Name = ("PicGoblin" & counter.ToString())
            Controls.Add(PicGoblins(counter))

            IntCount += 1

        Next


        For counter = 0 To NumberOfGoblins - 1


            ReDim Preserve Goblin(GoblinCount)
            Goblin(counter) = New Enemy(DirectCast(Controls("Picgoblin" & counter.ToString()), PictureBox), 3, 3, 5)
            Goblin(counter).Enemygraphic.BringToFront()
            currentEnemies.Add(Goblin(counter))
            EnemiesLeft += 1
            GoblinCount += 1
        Next







    End Sub


    Public Sub Endgame()

        EnemyLogic.Stop()
        GameLogic.Stop()

        LblGameOver.Show()
        RetryButton.Show()



    End Sub

    Private Sub RetryButton_Click(sender As Object, e As EventArgs) Handles RetryButton.Click

        Lives = 10

        SpawnGoblins(10)

        EnemyLogic.Start()
        GameLogic.Start()
        LblGameOver.Hide()
        RetryButton.Hide()


    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click


        Me.Close()

    End Sub

    Private Sub WaveEndingTimer_Tick(sender As Object, e As EventArgs) Handles WaveEndingTimer.Tick

        If EnemiesLeft = 0 Then
            Wave += 1
            WaveEndingTimer.Stop()
        End If

    End Sub


End Class

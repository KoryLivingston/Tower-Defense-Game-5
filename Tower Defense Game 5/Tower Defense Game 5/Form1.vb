

Public Class Form1

    Public TotalEnemiesInWave As Integer
    Public EnemiesKilledInWave As Integer

    Public currentEnemies As New List(Of Enemy)

    Public Goblins(-1) As Enemy
    Public PicGoblins(-1) As PictureBox
    Public Demons(-1) As Enemy
    Public PicDemons(-1) As PictureBox

    Public TowerPlacing As Boolean

    Public PicTower1 As PictureBox
    Public Tower1 As Tower = New Tower(Nothing, 20)

    Public Lives As Integer = 10
    Public Coins As Integer = 50
    Public Wave As Integer = 1



    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        SpawnGoblins(3)

        StartButton.Hide()
        QuitButton.Hide()

        TurretPanel.Show()
        TowerBuy1.Show()
        TurretPanel.BackColor = Color.FromArgb(130, TurretPanel.BackColor)

        GameLogic.Enabled = True
        GameLogic.Start()

        EnemyLogic.Enabled = True
        EnemyLogic.Start()


    End Sub


    Private Sub GameLogic_Tick(sender As Object, e As EventArgs) Handles GameLogic.Tick

        LblLives.Text = "LIVES " & Lives
        LblCoins.Text = "COINS " & Coins
        LblWave.Text = "WAVE " & Wave

        If EnemiesKilledInWave = TotalEnemiesInWave Then
            Wave += 1
            LblWaveCompleted.Show()
            LblWaveCompleted.BringToFront()
            WaveCompletionUI.Start()
            WaveSpawn()
        End If



        If Lives = 0 Then
            Endgame()
        End If

    End Sub




    Private Sub EnemyLogic_Tick(sender As Object, e As EventArgs) Handles EnemyLogic.Tick

        For counter = 0 To TotalEnemiesInWave - 1

            currentEnemies(counter).MoveEnemy()
            currentEnemies(counter).EnemyReachedBase()

        Next



    End Sub


    Public Sub SpawnGoblins(NumberOfGoblins)

        ReDim Goblins(NumberOfGoblins - 1)
        ReDim PicGoblins(NumberOfGoblins - 1)


        For counter = 0 To NumberOfGoblins - 1

            PicGoblins(counter) = New PictureBox With {
    .Location = New Point(-800 + (counter * 50), 275),
    .Size = New Size(30, 30),
    .BackColor = Color.Green,
    .Name = "PicGoblins" & counter.ToString()
                }

            Controls.Add(PicGoblins(counter))
            PicGoblins(counter).BringToFront()

            Goblins(counter) = New Enemy(PicGoblins(counter), 3, 2, 5)
            TotalEnemiesInWave += 1
            currentEnemies.Add(Goblins(counter))
        Next


    End Sub

    Public Sub SpawnDemons(NumberOfDemons)

        ReDim Demons(NumberOfDemons - 1)
        ReDim PicDemons(NumberOfDemons - 1)


        For counter = 0 To NumberOfDemons - 1

            PicDemons(counter) = New PictureBox With {
    .Location = New Point(-800 + (counter * 50), 275),
    .Size = New Size(33, 33),
    .BackColor = Color.DarkRed,
    .Name = "PicDemons" & counter.ToString()
                }

            Controls.Add(PicDemons(counter))
            PicDemons(counter).BringToFront()

            Demons(counter) = New Enemy(PicDemons(counter), 3, 4, 10)
            TotalEnemiesInWave += 1
            currentEnemies.Add(Demons(counter))
        Next


    End Sub



    Public Sub WaveSpawn()


        Do While Wave >= 2 And Wave <= 8

            InitializeGame()
            SpawnGoblins(3 + Wave)

            For counter = 0 To TotalEnemiesInWave - 1
                currentEnemies(counter).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 275)
            Next

            Exit Do

        Loop

    End Sub


    Private Sub TowerBuy1_Click(sender As Object, e As EventArgs) Handles TowerBuy1.Click

        If Coins >= Tower1.Price And TowerPlacing = False Then

            TowerPlacing = True

        End If

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If TowerPlacing = True And Tower1.TowerGraphic IsNot Nothing Then

            Tower1.TowerGraphic.Location = PointToClient(Cursor.Position)

        End If

    End Sub


    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick


        If TowerPlacing = True Then

            Dim newTower1 As New PictureBox With {
    .Size = New Size(37, 33),
    .BackColor = Color.CadetBlue,
    .Name = "PicTower1",
    .Location = PointToClient(Cursor.Position)
                              }


            Controls.Add(newTower1)
            newTower1.BringToFront()

            Coins -= Tower1.Price
            TowerPlacing = False


        End If


    End Sub


    Public Sub InitializeGame()


        For counter = 0 To TotalEnemiesInWave - 1
            Controls.Remove(currentEnemies(counter).Enemygraphic)
        Next

        Goblins = Nothing
        PicGoblins = Nothing
        currentEnemies.Clear()
        TotalEnemiesInWave = 0
        EnemiesKilledInWave = 0


    End Sub


    Private Sub WaveCompletionUI_Tick(sender As Object, e As EventArgs) Handles WaveCompletionUI.Tick

        LblWaveCompleted.Hide()
        WaveCompletionUI.Stop()

    End Sub



    Public Sub Endgame()

        EnemyLogic.Stop()
        GameLogic.Stop()


        LblGameOver.Show()
        LblGameOver.BringToFront()
        RetryButton.Show()
        RetryButton.BringToFront()

    End Sub

    Private Sub RetryButton_Click(sender As Object, e As EventArgs) Handles RetryButton.Click

        Lives = 10
        Coins = 50
        Wave = 1

        InitializeGame()


        EnemyLogic.Start()
        GameLogic.Start()

        LblGameOver.Hide()
        RetryButton.Hide()

        SpawnGoblins(3)

    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click

        Me.Close()


    End Sub

End Class

Imports System.Reflection

Public Class Form1

    Public TotalEnemiesInWave As Integer
    Public EnemiesKilledInWave As Integer
    Public WaveIncremented As Boolean

    Public currentEnemies As New List(Of Enemy)

    Public Goblins(-1) As Enemy
    Public PicGoblins(-1) As PictureBox

    Public Demons(-1) As Enemy
    Public PicDemons(-1) As PictureBox


    Public Lives As Integer = 50
    Public Coins As Integer = 50
    Public Wave As Integer = 1



    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        SpawnGoblins(5)

        StartButton.Hide()
        QuitButton.Hide()

        GameLogic.Enabled = True
        GameLogic.Start()

        EnemyLogic.Enabled = True
        EnemyLogic.Start()

    End Sub


    Private Sub GameLogic_Tick(sender As Object, e As EventArgs) Handles GameLogic.Tick

        LblLives.Text = "LIVES " & Lives
        LblCoins.Text = "COINS " & Coins
        LblWave.Text = "WAVE " & Wave

        If Not WaveIncremented AndAlso EnemiesKilledInWave = TotalEnemiesInWave Then
            Wave += 1
            WaveIncremented = True
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

        If Wave = 2 Then

            InitializeGame()
            SpawnGoblins(5)

            For counter = 0 To TotalEnemiesInWave - 1
                If Wave <> 1 Then
                    currentEnemies(counter).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 275)
                End If
            Next

        End If



        If Wave = 3 Then

            InitializeGame()
            SpawnGoblins(10)

            For counter = 0 To TotalEnemiesInWave - 1
                If Wave <> 1 Then
                    currentEnemies(counter).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 275)
                End If
            Next

        End If

        If Wave = 4 Then
            InitializeGame()
            SpawnGoblins(15)

            For counter = 0 To TotalEnemiesInWave - 1
                If Wave <> 1 Then
                    currentEnemies(counter).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 275)
                End If
            Next

        End If


        If Wave = 5 Then
            InitializeGame()
            SpawnGoblins(20)

            For counter = 0 To TotalEnemiesInWave - 1
                If Wave <> 1 Then
                    currentEnemies(counter).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 275)
                End If
            Next

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
        WaveIncremented = False


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

        Lives = 50
        Coins = 50
        Wave = 1

        InitializeGame()


        EnemyLogic.Start()
        GameLogic.Start()

        LblGameOver.Hide()
        RetryButton.Hide()

        SpawnGoblins(5)

    End Sub





    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click

        Me.Close()


    End Sub

End Class

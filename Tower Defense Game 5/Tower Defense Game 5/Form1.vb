Public Class Form1

    Public TotalEnemiesInWave As Integer
    Public EnemiesKilledInWave As Integer

    Public currentEnemies As New List(Of Enemy)

    Public Goblins(-1) As Enemy
    Public PicGoblins(-1) As PictureBox
    Public Demons(-1) As Enemy
    Public PicDemons(-1) As PictureBox

    Public WaveEnded As Boolean
    Public TowerPlacing As Boolean

    Public PicTower(-1) As PictureBox
    Public Tower(-1) As Tower

    Public TotalTowers As Integer
    Public IntTower As Integer

    Public Lives As Integer = 10
    Public Coins As Integer = 10000
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

        If WaveEnded = False And EnemiesKilledInWave = TotalEnemiesInWave Then

            LblWaveCompleted.Show()
            LblWaveCompleted.BringToFront()
            WaveCompletionUI.Start()
            WaveEnded = True

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

    Private Sub WaveCompletionUI_Tick(sender As Object, e As EventArgs) Handles WaveCompletionUI.Tick

        LblWaveCompleted.Hide()
        WaveCompletionUI.Stop()
        NextWaveButton.Show()
        NextWaveButton.BringToFront()

    End Sub


    Private Sub NextWaveButton_Click(sender As Object, e As EventArgs) Handles NextWaveButton.Click

        NextWaveButton.Hide()
        Wave += 1
        WaveSpawn()

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


        If Coins >= 20 And TowerPlacing = False Then

            TowerPlacing = True

            ReDim Preserve PicTower(IntTower)


            PicTower(IntTower) = New PictureBox With {
            .Size = New Size(37, 33),
            .BackColor = Color.CadetBlue,
            .Name = "PicTower" & IntTower.ToString(),
            .Location = New Point(-100, -100)
            }

            Controls.Add(PicTower(IntTower))
            PicTower(IntTower).BringToFront()


            ReDim Preserve Tower(IntTower)
            Tower(IntTower) = New Tower(PicTower(IntTower))




        End If

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If TowerPlacing = True Then


            TowerIndicator.Show()
            TowerIndicator.BringToFront()
            TowerIndicator.BackColor = Color.FromArgb(200, TowerIndicator.BackColor)

            TowerIndicatorUI.Enabled = True
            TowerIndicatorUI.Start()



        End If

    End Sub

    Private Sub TowerIndicatorUI_Tick(sender As Object, e As EventArgs) Handles TowerIndicatorUI.Tick

        Dim p As New Point(18, 16)

        TowerIndicator.Location = New Point(PointToClient(Cursor.Position) - p)

    End Sub


    Private Sub TowerIndicator_Click(sender As Object, e As EventArgs) Handles TowerIndicator.Click

        Dim p As New Point(18, 16)



        If TowerPlacing = True Then


            For Each picBox As PictureBox In Controls.OfType(Of PictureBox)

                If picBox IsNot TowerIndicator AndAlso TowerIndicator.Bounds.IntersectsWith(picBox.Bounds) Then
                    Exit Sub
                End If

            Next


            TowerIndicatorUI.Stop()
            TowerIndicator.Hide()

            Tower(IntTower).TowerGraphic.Location = New Point(PointToClient(Cursor.Position) - p)
            Coins -= 20
            IntTower += 1
            TotalTowers += 1
            TowerPlacing = False

        End If


    End Sub






    Public Sub InitializeGame()


        For counter = 0 To TotalEnemiesInWave - 1
            Controls.Remove(currentEnemies(counter).Enemygraphic)
        Next

        Goblins = Nothing
        PicGoblins = Nothing
        Demons = Nothing
        PicDemons = Nothing
        currentEnemies.Clear()
        TotalEnemiesInWave = 0
        EnemiesKilledInWave = 0
        WaveEnded = False


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


        For counter = 0 To TotalTowers - 1
            Controls.Remove(Tower(counter).TowerGraphic)
        Next

        Tower = Nothing
        PicTower = Nothing
        TowerPlacing = False
        TotalTowers = 0
        IntTower = 0

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

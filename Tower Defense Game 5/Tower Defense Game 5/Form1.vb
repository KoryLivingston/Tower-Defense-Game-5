

Imports System.Reflection

Public Class Form1

    'Variables for wave ending condition and enemy logic

    Public TotalEnemiesInWave As Integer
    Public EnemiesKilledInWave As Integer

    'List holds all enemies to be used in that wave

    Public currentEnemies As New List(Of Enemy)

    'Arrays of objects and pictureboxes for each enemy type

    Public Goblins(-1) As Enemy
    Public PicGoblins(-1) As PictureBox
    Public Demons(-1) As Enemy
    Public PicDemons(-1) As PictureBox

    'Condition variable to check if a wave has ended or started

    Public WaveEnded As Boolean

    'Variable to be incremented every time a wave has ended, new value will then be added on the next wave

    Public additionalenemies As Integer

    'List holds all towers that have been placed

    Public CurrentTowers As New List(Of Tower)

    'A variable that increments the array of objects and picturebox array, to hold new towers that have been created

    Public TowerCount As Integer

    'Picturebox array and an array of objects for towers

    Public PicTower(-1) As PictureBox
    Public Tower(-1) As Tower

    'Condition to check if the player is placing a tower for relevant code to be run

    Public TowerPlacing As Boolean

    'Player stats

    Public Lives As Integer = 10
    Public Coins As Integer = 50
    Public Wave As Integer = 1

    Dim EnemiesSpawned As Integer
    Dim EnemiesLeftOver As Integer


    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        'Code to be run for wave 1 game state

        SpawnGoblins(3)

        StartButton.Hide()
        QuitButton.Hide()

        TurretPanel.Show()
        TurretPanel.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTower1Cost.Show()
        LblTower1Cost.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        TowerBuy1.Show()

        GameLogic.Enabled = True
        GameLogic.Start()

        EnemyLogic.Enabled = True
        EnemyLogic.Start()

        TowerLogic.Enabled = True
        TowerLogic.Start()

        TowerShooting.Enabled = True
        TowerShooting.Start()


    End Sub


    Private Sub GameLogic_Tick(sender As Object, e As EventArgs) Handles GameLogic.Tick

        'Updates the labels

        LblLives.Text = "LIVES " & Lives
        LblCoins.Text = "COINS " & Coins
        LblWave.Text = "WAVE " & Wave

        'Checks if wave has ended
        Console.WriteLine($"Wave: {Wave}, TotalEnemies: {TotalEnemiesInWave}, KilledEnemies: {EnemiesKilledInWave}, WaveEnded: {WaveEnded}")

        If WaveEnded = False And EnemiesKilledInWave = TotalEnemiesInWave Then

            LblWaveCompleted.Show()
            LblWaveCompleted.BringToFront()
            WaveCompletionUI.Start()
            WaveEnded = True

        End If


        'condition for endgame

        If Lives = 0 Then
            Endgame()
        End If

    End Sub




    Private Sub EnemyLogic_Tick(sender As Object, e As EventArgs) Handles EnemyLogic.Tick

        'For every enemy alive it will move and check if it reached the base

        For counter = 0 To TotalEnemiesInWave - 1

            currentEnemies(counter).MoveEnemy()
            currentEnemies(counter).EnemyReachedBase()

        Next



    End Sub


    'Spawns goblins, creating their pictureboxes and associated objects

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



            Goblins(counter) = New Enemy(PicGoblins(counter), 5, 5, 5)
            TotalEnemiesInWave += 1
            currentEnemies.Add(Goblins(counter))

        Next


    End Sub

    'Spawns demons, creating their pictureboxes and associated objects

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

            Demons(counter) = New Enemy(PicDemons(counter), 3, 8, 10)
            TotalEnemiesInWave += 1
            currentEnemies.Add(Demons(counter))

        Next


    End Sub

    'Runs when wave ends then stops 2.0 seconds later

    Private Sub WaveCompletionUI_Tick(sender As Object, e As EventArgs) Handles WaveCompletionUI.Tick

        LblWaveCompleted.Hide()
        WaveCompletionUI.Stop()
        NextWaveButton.Show()
        NextWaveButton.BringToFront()

    End Sub


    Private Sub NextWaveButton_Click(sender As Object, e As EventArgs) Handles NextWaveButton.Click

        'Once clicked it hides the button increments the wave and the amount of new enemies to be spawned that wave and it calls the wavespawn so the next wave can spawn


        additionalenemies += 2
        NextWaveButton.Hide()
        Wave += 1
        WaveSpawn()

    End Sub

    Public Sub WaveSpawn()

        'Between the waves 2 to 10, initialize the game and spawn a new amount of enemies each wave and change their location closer to the enemy base
        'exit do to prevent errors


        Do While Wave >= 2 And Wave <= 10
            InitializeGame()
            SpawnGoblins(3 + additionalenemies)


            EnemySpawnAdjustments()


            If EnemiesSpawned < TotalEnemiesInWave Then

                EnemySpawnTimer.Start()

            End If

            If EnemiesSpawned = TotalEnemiesInWave Then
                Exit Do
            End If

        Loop


    End Sub
    Public Sub EnemySpawnAdjustments()

        Dim EnemiesSpawnedNow As Integer

        Do While EnemiesSpawnedNow < 9
            Dim index As Integer
            If currentEnemies(EnemiesSpawned).IsSpawn = False Then
                currentEnemies(EnemiesSpawned).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (index * 50), 275)
                currentEnemies(EnemiesSpawned).IsSpawn = True
                index += 1
                EnemiesSpawned += 1
                EnemiesSpawnedNow += 1

                If EnemiesSpawned = TotalEnemiesInWave Then
                    Exit Sub
                End If

            End If

        Loop

    End Sub

    Private Sub EnemySpawnTimer_Tick(sender As Object, e As EventArgs) Handles EnemySpawnTimer.Tick

        EnemySpawnAdjustments()

        EnemySpawnTimer.Stop()

    End Sub

    Private Sub TowerBuy1_Click(sender As Object, e As EventArgs) Handles TowerBuy1.Click

        'If the players coins are valid and they are not currently placing a tower then create a new tower to be placed

        If Coins >= 30 And TowerPlacing = False Then

            TowerPlacing = True

            ReDim Preserve PicTower(TowerCount)


            PicTower(TowerCount) = New PictureBox With {
    .Size = New Size(37, 33),
    .BackColor = Color.CadetBlue,
    .Name = "PicTower" & TowerCount.ToString(),
    .Location = New Point(-1000, -1000)
            }

            Controls.Add(PicTower(TowerCount))
            PicTower(TowerCount).BringToFront()


            ReDim Preserve Tower(TowerCount)
            Tower(TowerCount) = New Tower(PicTower(TowerCount), 160, 1)


        End If

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        'If the player is placing a new tower then show the tower indicator for where the mouse moves

        If TowerPlacing = True Then


            TowerIndicator.Show()
            TowerIndicator.BringToFront()
            TowerIndicator.BackColor = Color.FromArgb(200, TowerIndicator.BackColor)

            TowerIndicatorUI.Enabled = True
            TowerIndicatorUI.Start()



        End If

    End Sub

    'Timer to run the timer indicator animation to match the speed of the mouse

    Private Sub TowerIndicatorUI_Tick(sender As Object, e As EventArgs) Handles TowerIndicatorUI.Tick

        Dim p As New Point(18, 16)

        TowerIndicator.Location = New Point(PointToClient(Cursor.Position) - p)

    End Sub

    Private Sub TowerIndicator_Click(sender As Object, e As EventArgs) Handles TowerIndicator.Click

        'Once the tower indicator has been placed if the location is valid then stop and hide towerindicator code,
        'move tower to location and add to current towers, detuct coins and increment tower count, towerplcacing is false

        Dim p As New Point(18, 16)


        If TowerPlacing = True Then


            For Each PictureBox As PictureBox In Controls.OfType(Of PictureBox)

                If PictureBox IsNot TowerIndicator AndAlso TowerIndicator.Bounds.IntersectsWith(PictureBox.Bounds) Then
                    Exit Sub
                End If

            Next


            TowerIndicatorUI.Stop()
            TowerIndicator.Hide()

            Tower(TowerCount).TowerGraphic.Location = New Point(PointToClient(Cursor.Position) - p)
            CurrentTowers.Add(Tower(TowerCount))
            Coins -= 30
            TowerCount += 1
            TowerPlacing = False

        End If


    End Sub


    Private Sub TowerLogic_Tick(sender As Object, e As EventArgs) Handles TowerLogic.Tick

        'Checks every tower to see if they have a target, if not it assigns the closest one

        For Each PlayerTower As Tower In CurrentTowers

            If PlayerTower.TargetEnemy Is Nothing Then

                For Each Enemy As Enemy In currentEnemies

                    If EnemyIsInRange(PlayerTower, Enemy) Then

                        PlayerTower.TargetEnemy = Enemy
                        Exit For

                    End If

                Next

            End If

        Next

    End Sub

    Private Sub TowerShooting_Tick(sender As Object, e As EventArgs) Handles TowerShooting.Tick

        'Checks every tower to see if their enemy has already been killed to avoid logic errors with enemieskilledinwave

        For Each PlayerTower As Tower In CurrentTowers

            If PlayerTower.TargetEnemy IsNot Nothing Then

                For Each otherTower As Tower In CurrentTowers

                    If otherTower.TargetEnemy IsNot Nothing Then

                        If otherTower.TargetEnemy.Health <= 0 Then
                            otherTower.TargetEnemy = Nothing

                        End If
                    End If

                Next

            End If

            'If this tower does have a target, deal damage to it every second, if this targets health reaches zero on this instance run the enemykilled logic

            If PlayerTower.TargetEnemy IsNot Nothing Then


                PlayerTower.DealDamage(PlayerTower.TargetEnemy)


                If PlayerTower.TargetEnemy.Health <= 0 And PlayerTower.TargetEnemy.IsDead = False Then

                    PlayerTower.TargetEnemy.Enemygraphic.Top -= 1000
                    EnemiesKilledInWave += 1

                    If WaveEnded = False Then
                        Coins += PlayerTower.TargetEnemy.CoinsDropped
                    End If

                    PlayerTower.TargetEnemy.IsDead = True
                    PlayerTower.TargetEnemy = Nothing

                End If
            End If

        Next


    End Sub

    Public Function EnemyIsInRange(Tower As Tower, Enemy As Enemy) As Boolean

        ' Uses distance formula to calculate the distance between the two centers between the tower and the enenmy
        'If this distance is less than or equal to the range it must be in range
        'The range = radius of the area of the circle for a towers range 
        'Therefor if the distance is less than the "radius", it must be in range

        Dim towerCenterX As Integer = Tower.TowerGraphic.Location.X + Tower.TowerGraphic.Width \ 2
        Dim towerCenterY As Integer = Tower.TowerGraphic.Location.Y - Tower.TowerGraphic.Height \ 2
        Dim enemyCenterX As Integer = Enemy.Enemygraphic.Location.X + Enemy.Enemygraphic.Width \ 2
        Dim enemyCenterY As Integer = Enemy.Enemygraphic.Location.Y - Enemy.Enemygraphic.Height \ 2

        Dim distance As Double = Math.Sqrt((towerCenterX - enemyCenterX) ^ 2 + (towerCenterY - enemyCenterY) ^ 2)


        Return Enemy.Enemygraphic.Location.X >= 20 And
    distance <= Tower.Range

    End Function


    Public Sub InitializeGame()

        'Removes pictureboxes of current wave before clearing arrays

        For counter = 0 To TotalEnemiesInWave - 1
            currentEnemies(counter).Enemygraphic.Dispose()
            Controls.Remove(currentEnemies(counter).Enemygraphic)
        Next

        'clearing arrays and the list and logic variables, setting waveneded to false since a new wave has started

        Goblins = Nothing
        PicGoblins = Nothing
        Demons = Nothing
        PicDemons = Nothing
        currentEnemies.Clear()
        TotalEnemiesInWave = 0
        EnemiesKilledInWave = 0
        WaveEnded = False


    End Sub

    'If the player runs out of lives this will run , stoping the timers to stop the game and showing the game over ui
    Public Sub Endgame()

        GameLogic.Stop()
        EnemyLogic.Stop()
        TowerLogic.Stop()
        TowerShooting.Stop()

        LblGameOver.Show()
        LblGameOver.BringToFront()
        RetryButton.Show()
        RetryButton.BringToFront()

    End Sub

    Private Sub RetryButton_Click(sender As Object, e As EventArgs) Handles RetryButton.Click

        ' Resets player and game stats
        Lives = 10
        Coins = 50
        Wave = 1

        additionalenemies = 0

        'Resets the enemies

        InitializeGame()

        'removes current tower pictureboxes

        For counter = 0 To TowerCount - 1
            Controls.Remove(CurrentTowers(counter).TowerGraphic)
        Next

        'Clears tower arrays, list,variables and tower placing
        Tower = Nothing
        PicTower = Nothing

        CurrentTowers.Clear()
        TowerCount = 0
        TowerPlacing = False


        EnemyLogic.Start()
        GameLogic.Start()
        TowerLogic.Start()
        TowerShooting.Start()

        LblGameOver.Hide()
        RetryButton.Hide()

        SpawnGoblins(3)

    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click

        Close()


    End Sub

End Class

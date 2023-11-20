Imports System.Drawing.Imaging

Public Class Form1

    'EnemiesKilledInWave will be incremented every time an enemy is killed, Totalenemiesinwave will be assigned to the value equal to the number of enemies created for that wave
    'These variables are used to check if a wave has ended

    Public EnemiesKilledInWave As Integer
    Public TotalEnemiesInWave As Integer

    'A list to hold the objects of various enemies for that wave

    Public currentEnemies As New List(Of Enemy)

    'Arrays of objects and pictureboxes for each enemy type

    Public Goblins(-1) As Enemy
    Public PicGoblins(-1) As PictureBox
    Public Demons(-1) As Enemy
    Public PicDemons(-1) As PictureBox

    'Condition variable to check if a wave has ended or started

    Public WaveEnded As Boolean

    'Variable to be incremented every time a wave has ended, new value will then be added on the next wave

    Public additionalGoblins As Integer
    Public additionalDemons As Integer

    'EnemyNum variable holds the index of the next enemy to be adjusted, enemiesleftover is a boolean flag to allow the timer to run again for adjusting 10 more enemies 15 seconds later

    Public EnemyNum As Integer
    Public enemiesleftover As Boolean

    'A list to hold all the various towers that have been created

    Public CurrentTowers As New List(Of Tower)

    'A variable that holds the next free position for a tower to be created in the array of objects for tower as well as to increment the arrays to this element
    'This variable also functions as the total amount of towers which have been placed

    Public TowerCount As Integer
    Public TowerLimit As Integer = 25

    'Arrays of objects and pictureboxes for the tower

    Public PicTower(-1) As PictureBox
    Public Tower(-1) As Tower

    'Boolean variable used to check if the player is in tower placing mode

    Public TowerPlacing As Boolean

    'Player stats for updating labels

    Public Lives As Integer = 10
    Public Coins As Integer = 60
    Public Wave As Integer = 1


    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        'Code to be run for wave 1 game state
        'Spawning 3 goblins
        'adjusting these enemies at a certain distance so that the player has time to prepare
        'Hides the start screen UI and enables the relevant game UI for towers
        'Starting the timers for the game

        SpawnGoblins(3)

        For counter = 0 To TotalEnemiesInWave - 1
            currentEnemies(counter).Enemygraphic.Location = New Point(-650 - (counter * 50), 275)
        Next

        StartButton.Hide()
        QuitButton.Hide()

        TurretPanel.Show()
        LblTower1Cost.Show()
        TowerBuy1.Show()
        LblTowerCapacity.Show()
        TurretPanel.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTower1Cost.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTowerCapacity.BackColor = Color.FromArgb(130, TurretPanel.BackColor)


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

        'Condition to check if a wave has ended
        'Boolean variable is used t prevent errors

        If WaveEnded = False And EnemiesKilledInWave = TotalEnemiesInWave Then

            LblWaveCompleted.Show()
            LblWaveCompleted.BringToFront()
            WaveCompletionUI.Start()
            WaveEnded = True

        End If

        LblWaveCompleted.BringToFront()
        NextWaveButton.BringToFront()
        CancelPlacing.BringToFront()


        'condition for endgame

        If Lives = 0 Then
            Endgame()
        End If

    End Sub




    Private Sub EnemyLogic_Tick(sender As Object, e As EventArgs) Handles EnemyLogic.Tick

        'Moves each enemy of that wave to a certain point
        'Checks each enemy to see if it has had a collision with the player base


        For counter = 0 To TotalEnemiesInWave - 1

            currentEnemies(counter).MoveEnemy()
            currentEnemies(counter).EnemyReachedBase()

        Next

        'Condition to check if there are still more enemies that need to be brought into the game for that wave
        'If true it will restart the timer for enemy adjustments which will spawn another 10 enemies if able to in 15 seconds

        If enemiesleftover = True Then

            NextSpawn.Start()
            enemiesleftover = False

        End If


    End Sub


    'Redeclares the arrays to hold the amount of goblins for that wave
    'Creates pictureboxes for each goblin and assigns it to their associated objects

    Public Sub SpawnGoblins(NumberOfGoblins)

        ReDim Goblins(NumberOfGoblins - 1)
        ReDim PicGoblins(NumberOfGoblins - 1)


        For counter = 0 To NumberOfGoblins - 1

            PicGoblins(counter) = New PictureBox With {
    .Location = New Point(-1000, -100),
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


    'Redeclares the arrays to hold the amount of demons for that wave
    'Creates pictureboxes for each demon and assigns it to their associated objects

    Public Sub SpawnDemons(NumberOfDemons)

        ReDim Demons(NumberOfDemons - 1)
        ReDim PicDemons(NumberOfDemons - 1)



        For counter = 0 To NumberOfDemons - 1

            PicDemons(counter) = New PictureBox With {
    .Location = New Point(-1000, -100),
    .Size = New Size(33, 33),
    .BackColor = Color.DarkRed,
    .Name = "PicDemons" & counter.ToString()
                }

            Controls.Add(PicDemons(counter))
            PicDemons(counter).BringToFront()

            Demons(counter) = New Enemy(PicDemons(counter), 10, 10, 8)
            TotalEnemiesInWave += 1
            currentEnemies.Add(Demons(counter))

        Next


    End Sub

    'Runs when wave ends then stops 2.0 seconds later
    'Allowing the wave completed label to appear for 2 seconds and to then show the nextwave button after it

    Private Sub WaveCompletionUI_Tick(sender As Object, e As EventArgs) Handles WaveCompletionUI.Tick

        LblWaveCompleted.Hide()
        WaveCompletionUI.Stop()
        NextWaveButton.Show()
        NextWaveButton.BringToFront()

    End Sub


    'Once the nextwave button has been clicked it increments the additional amount of enemies that will be brought into the next wave
    'Hides the button and increments wave by 1, then it starts the wavespawn
    Private Sub NextWaveButton_Click(sender As Object, e As EventArgs) Handles NextWaveButton.Click

        If Wave >= 7 And Wave <= 15 Then
            additionalDemons += 2
        End If

        additionalGoblins += 2
        NextWaveButton.Hide()
        Wave += 1
        WaveSpawn()

    End Sub

    Public Sub WaveSpawn()

        'Condition to check if the wave is between 2 to 100
        'If so it initializes the game for the next wave
        'Spawns the next wave
        'And adjusts the first 10 enemies positions, and then for every 10 enemies after the first 10, it will adjust 10 more enemies then wait 15 seconds before doing the next

        If Wave >= 2 And Wave <= 15 Then

            InitializeGame()
            SpawnGoblins(3 + additionalGoblins)

        End If

        'Adjust the positions of 10 enemies and if at any point the amount of enemies that have been adjusted is the same as totalenemiesinwave then exit sub
        'since there is no longer any need to run this sub routine since all the enemies of that wave have been adjsuted
        For counter = 0 To 9

            If EnemyNum < TotalEnemiesInWave Then
                currentEnemies(EnemyNum).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 278)
                EnemyNum += 1
            Else
                Exit Sub
            End If

        Next

        'Reaches this line if it has succesfully adjusted 10 enemie positions without exiting the sub
        'Which means there are more than 10 enemies for that wave
        'Starts the timer which will start 15 seconds later to spawn another 10

        NextSpawn.Start()


    End Sub


    Private Sub EnemySpawnTimer_Tick(sender As Object, e As EventArgs) Handles NextSpawn.Tick


        For counter = 0 To 9
            If EnemyNum < TotalEnemiesInWave Then
                currentEnemies(EnemyNum).Enemygraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 278)
                EnemyNum += 1
            Else
                NextSpawn.Stop()
            End If
        Next

        'Reaches this line if the program has succesfully adjusted another 10 without stopping the timer
        'Which means that there are more enemies to be adjusted
        'Boolean variable is set to true whihc triggers the condition in the enemy logic for the timer to start again
        'Timer is then stopped

        enemiesleftover = True
        NextSpawn.Stop()



    End Sub

    Private Sub TowerBuy1_Click(sender As Object, e As EventArgs) Handles TowerBuy1.Click

        'If the players coins are valid and they are not currently placing a tower then create a new tower to be placed

        If Coins >= 30 And TowerPlacing = False AndAlso TowerCount < TowerLimit AndAlso Lives > 0 Then

            TowerPlacing = True
            CancelPlacing.Show()

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

            TowerIndicator.Hide()
            TowerIndicatorUI.Stop()
            CancelPlacing.Hide()

            ReDim Preserve PicTower(TowerCount)


            PicTower(TowerCount) = New PictureBox With {
    .Size = New Size(37, 33),
    .BackColor = Color.CadetBlue,
    .Name = "PicTower" & TowerCount.ToString(),
    .Location = PointToClient(Cursor.Position) - p
                    }

            Controls.Add(PicTower(TowerCount))
            PicTower(TowerCount).BringToFront()


            ReDim Preserve Tower(TowerCount)
            Tower(TowerCount) = New Tower(PicTower(TowerCount), 160, 1)

            CurrentTowers.Add(Tower(TowerCount))
            Coins -= 30
            TowerCount += 1

            TowerPlacing = False

        End If


    End Sub

    Private Sub CancelPlacing_Click(sender As Object, e As EventArgs) Handles CancelPlacing.Click

        TowerPlacing = False
        TowerIndicator.Hide()
        TowerIndicatorUI.Stop()
        CancelPlacing.Hide()

    End Sub

    Private Sub TowerLogic_Tick(sender As Object, e As EventArgs) Handles TowerLogic.Tick

        LblTowerCapacity.Text = "Tower Capacity" & " " & TowerCount & "/25"


        'Checks every tower to see if they have a target, if not it assigns the closest one

        For Each PlayerTower As Tower In CurrentTowers

            If PlayerTower.TargetEnemy IsNot Nothing Then
                If EnemyIsInRange(PlayerTower, PlayerTower.TargetEnemy) = False Then
                    PlayerTower.TargetEnemy = Nothing
                End If
            End If

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
        Dim p As New Point(18, 16)

        Dim towerCenterX As Integer = Tower.TowerGraphic.Location.X - p.X
        Dim towerCenterY As Integer = Tower.TowerGraphic.Location.Y - p.Y
        Dim enemyCenterX As Integer = Enemy.Enemygraphic.Location.X - Enemy.Enemygraphic.Width \ 2
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
        EnemyNum = 0
        enemiesleftover = False
        NextSpawn.Stop()



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
        Coins = 60
        Wave = 1

        additionalGoblins = 0
        additionalDemons = 0

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

        For counter = 0 To TotalEnemiesInWave - 1
            currentEnemies(counter).Enemygraphic.Location = New Point(-650 - (counter * 50), 275)
        Next

    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click

        Close()


    End Sub

End Class

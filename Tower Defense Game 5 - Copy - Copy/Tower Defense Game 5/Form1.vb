
Public Class Form1

    'EnemiesKilledInWave will be incremented every time an enemy is killed, Totalenemiesinwave will be assigned to the value equal to the number of enemies created for that wave
    'These variables are used to check if a wave has ended

    Private EnemiesKilledInWave As Integer
    Private TotalEnemiesInWave As Integer
    Private WaveEnded As Boolean

    'Arrays of Enemy and pictureboxe for each enemy

    Private Enemies(-1) As Enemy
    Private PicEnemies(-1) As PictureBox

    'additionalEnemies is increased after a wave has ended, used to increase the amount of enemies spawned for the next wave
    'Enemynum is used to hold the index of the next enemy to be spawned as well is to check if every enemy has been spawned
    'EnemiesLeftOver is used to retrigger the nextspawndelay timer, if there are more enemies to be brought into the game

    Private additionalEnemies As Integer
    Private EnemyNum As Integer
    Private enemiesleftover As Boolean

    'Arrays of Tower and pictureboxe for each tower

    Private Towers(-1) As Tower
    Private PicTower(-1) As PictureBox

    Private currentTowers As New List(Of Tower)

    'Towercount is used to redclare the arrays to hold the new position of the tower to be created
    'Tower limit is used to restrict the total amount of towers to be created to 25
    'Towerplacing is used to determine whether the player is placing a tower and to run certain code while doing so

    Private TowerCount As Integer
    Private TowerLimit As Integer = 25
    Private TowerPlacing As Boolean
    Private clickedTower As Tower

    'Buffprice is used to hold the price of the next upgrade
    'UpgradeIndex is used to hold index of the next upgrade being bought for the boughtupgrade array and the upgrade slots array
    'boughtUpgrade is used to hold the boolean values of each upgrade to determine whether the uprade has been bought

    Private BuffPrice As Integer = 1000
    Private UpgradeIndex As Integer
    Private boughtUpgrade(2) As Boolean

    'Player stats

    Private Lives As Integer = 10
    Private Coins As Integer = 60
    Private Wave As Integer = 1

    'Arrays to hold the player names and wavesReached of the original leaderboard

    Private PlayerNames() As String = {"QSD", "BMV", "AJS", "123", "HJT", Nothing}
    Private WavesReached() As Integer = {"13", "10", "8", "12", "5", Nothing}

    'Arrays of label to hold the data for each playername with its associated waves reached

    Private NameLabels(4) As Label
    Private WaveReachedLabels(4) As Label

    'Player information used in the leaderboard and database table

    Private UserName As String
    Private TotalEnemiesKilled As Integer
    Private TotalCoinsEarned As Integer


    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        'Once the startbutton is clicked it:
        'Spawns the enemies for wave 1
        'Initializes the labels to be used in the leaderboard
        'Loads the game UI
        'Starts the games timers

        WaveSpawn()
        InitializeLabels()
        LoadUI()
        startGameTimers()


    End Sub

    Private Sub GameLogic_Tick(sender As Object, e As EventArgs) Handles GameLogic.Tick

        'Updates Player Stats Labels

        LblLives.Text = "LIVES " & Lives
        LblCoins.Text = "COINS " & Coins
        LblWave.Text = "WAVE " & Wave

        'Checks if a wave has ended by comparing the enemieskilled to the totalenemies from that wave
        'Waveended is used to prevent the condition from running again until the next wave has been called from pressing the next wave button
        'Starts the wavecompletionUI timer to simulate the label showing then dissapearing 2 seconds later and to show the nextwavebutton once this has been done

        If WaveEnded = False And EnemiesKilledInWave = TotalEnemiesInWave Then

            LblWaveCompleted.Show()
            WaveCompletionUI.Start()
            WaveEnded = True

        End If

        'Once the player Lives reaches 0 or they complete the final wave it ends the game

        If Lives = 0 Or Wave = 51 Then
            Endgame()
        End If

        'UI brought to the front when in use to prevent the tower indicator from overlapping it

        LblWaveCompleted.BringToFront()
        NextWaveButton.BringToFront()
        CancelPlacing.BringToFront()

    End Sub




    Private Sub EnemyLogic_Tick(sender As Object, e As EventArgs) Handles EnemyLogic.Tick

        'Moves each enemy along the path and checks if they have reached the players base at the other end

        For counter = 0 To TotalEnemiesInWave - 1

            Enemies(counter).MoveEnemy()
            Enemies(counter).EnemyReachedBase()

        Next

        'Enemeisleftover is set to true if there are enemies still to be brought into the game after the intial 20 
        'This allows another 10 enemies to be brought into the game by restarting the timer

        If enemiesleftover = True Then

            NextSpawnDelay.Start()
            enemiesleftover = False

        End If


    End Sub

    'Used to create each enemy with their associated picturebox attributes and enemy attributes of that wave

    Public Sub CreateEnemies(NumberOfEnemies As Integer, EnemySizeX As Integer, EnemySizeY As Integer, EnemyColor As Color, movementSpeed As Integer, Health As Integer, CoinsDropped As Integer)

        'Redeclares the arrays to hold the amount of enemies needed for that wave

        ReDim Enemies(NumberOfEnemies - 1)
        ReDim PicEnemies(NumberOfEnemies - 1)

        'For every enemy a picturebox is created with its associated attributes, and then an enemy object is instantiated to hold this new enemy with its picturebox
        'TotalEnemeisInWave is increased to be used in conditions throught the pogram

        For counter = 0 To NumberOfEnemies - 1

            PicEnemies(counter) = New PictureBox With {
                .Location = New Point(-1000, -100),
                .Size = New Size(EnemySizeX, EnemySizeY),
                .BackColor = EnemyColor
            }

            Controls.Add(PicEnemies(counter))
            PicEnemies(counter).BringToFront()

            Console.WriteLine("Picturebox created")

            Enemies(counter) = New Enemy(PicEnemies(counter), movementSpeed, Health, CoinsDropped)
            TotalEnemiesInWave += 1

            Console.WriteLine("Enemy Object Created " & TotalEnemiesInWave)


        Next



    End Sub

    'Runs if a wave has eneded and then stops 2 seconds later to simulate the label appearing then dissapearing 2 seconds later
    'Displays the nextwavebutton to allow the next wave to be called

    Private Sub WaveCompletionUI_Tick(sender As Object, e As EventArgs) Handles WaveCompletionUI.Tick

        LblWaveCompleted.Hide()
        WaveCompletionUI.Stop()
        NextWaveButton.Show()
        NextWaveButton.BringToFront()

    End Sub

    'If the nextwavebutton is pressed it hides it and increases the wave by one
    'Checks if the wave is now any of the waves that brings in a new type of enemy so that additionalenemies can be set to 0 for the new enemy type
    'additionalenemies is increased by 2 to allow a new total of enemies to be brought into the next wave
    'Wavespawn sub routine is called to spawn the next wave

    Private Sub NextWaveButton_Click(sender As Object, e As EventArgs) Handles NextWaveButton.Click

        NextWaveButton.Hide()

        Wave += 1
        If Wave = 8 Or Wave = 16 Or Wave = 26 Or Wave = 36 Or Wave = 46 Then
            additionalEnemies = 0
        End If

        additionalEnemies += 2
        WaveSpawn()

    End Sub


    Public Sub WaveSpawn()

        'If else if statements checks which wave it currently is and to create its associated enemies
        'Each time the game is initialized to reset the arrays and logic variables used during each wave

        If Wave = 1 Then

            CreateEnemies(3, 30, 30, Color.Green, 1, 4, 5)


            For counter = 0 To TotalEnemiesInWave - 1
                Enemies(counter).getEnemyGraphic.Location = New Point(-650 - (counter * 50), 275)
            Next

        ElseIf Wave >= 2 And Wave <= 7 Then

            InitializeGame()
            CreateEnemies(3 + additionalEnemies, 30, 30, Color.Green, 1, 4, 5)

        ElseIf Wave >= 8 And Wave <= 15 Then

            InitializeGame()
            CreateEnemies(10 + additionalEnemies, 30, 30, Color.DarkRed, 2, 6, 6)

        ElseIf Wave >= 16 And Wave <= 25 Then

            InitializeGame()
            CreateEnemies(15 + additionalEnemies, 30, 30, Color.Gray, 3, 8, 7)

        ElseIf Wave >= 26 And Wave <= 35 Then

            InitializeGame()
            CreateEnemies(20 + additionalEnemies, 30, 30, Color.Crimson, 4, 10, 8)

        ElseIf Wave >= 36 And Wave <= 45 Then

            InitializeGame()
            CreateEnemies(30 + additionalEnemies, 30, 30, Color.Olive, 5, 12, 9)

        ElseIf Wave >= 46 And Wave <= 50 Then

            InitializeGame()
            CreateEnemies(25 + additionalEnemies, 30, 30, Color.DarkMagenta, 6, 14, 10)

        End If

        'If the wave is no longer wave 1 then for the first ten enemies adjust their positions to be closer to the enemybase so that they get into the game faster
        'At any point if all the enemies have already been brought into the game exit sub

        For counter = 0 To 9

            If Wave <> 1 AndAlso EnemyNum < TotalEnemiesInWave Then
                Enemies(EnemyNum).getEnemyGraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 278)
                EnemyNum += 1
            Else
                Exit Sub
            End If

        Next

        'If exit sub has not been called then the totalenemiesinwave must be greater than 10, therefore the timer can start

        NextSpawnDelay.Start()


    End Sub

    'If this timer starts it will then spawn in another 10 enemies, If at any point enemynum is no longer less than totalenemiesinwave then stop the timer

    Private Sub EnemySpawnTimer_Tick(sender As Object, e As EventArgs) Handles NextSpawnDelay.Tick


        For counter = 0 To 9
            If EnemyNum < TotalEnemiesInWave Then
                Enemies(EnemyNum).getEnemyGraphic.Location = New Point(EnemyBase.Location.X - 100 - (counter * 50), 278)
                EnemyNum += 1
            Else
                NextSpawnDelay.Stop()
            End If
        Next

        'If the timer has not been stopped then totalenemiesinwave must be greater than 20, therefore enemiesleftover is set to true, to allow the timer to be recalled for the next 10 enemies to be brought into the game

        enemiesleftover = True
        NextSpawnDelay.Stop()



    End Sub

    'Runs if the player has clicked the UI to buy a tower
    'If they have enough coins and are currently not placing a tower as well as the total towers placed has yet to reach 25 and the game hasn't ended
    'Then set towerplacing to true and show the cancel button


    Private Sub TowerBuy1_Click(sender As Object, e As EventArgs) Handles TowerBuy1.Click

        If Coins >= 30 And TowerPlacing = False AndAlso TowerCount < TowerLimit AndAlso Lives > 0 Then

            TowerPlacing = True
            CancelPlacing.Show()

        End If

    End Sub

    'While the mouse is moving during towerplacing, show the tower indicator and start the towerIndicatorUI timer

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If TowerPlacing = True Then

            TowerIndicator.Show()
            TowerIndicator.BringToFront()
            TowerIndicator.BackColor = Color.FromArgb(200, TowerIndicator.BackColor)

            TowerIndicatorUI.Start()

        End If

    End Sub

    'Timer is used to allow the adjusting of the tower indicators psotion to be as responsive as possible
    'Adjust the tower indicators position so that its center is at the cursors position

    Private Sub TowerIndicatorUI_Tick(sender As Object, e As EventArgs) Handles TowerIndicatorUI.Tick

        Dim p As New Point(18, 16)

        TowerIndicator.Location = New Point(PointToClient(Cursor.Position) - p)

    End Sub


    Private Sub TowerIndicator_Click(sender As Object, e As EventArgs) Handles TowerIndicator.Click

        Dim p As New Point(18, 16)

        'Occurs if the player clicks the towerindicator and is in tower placing mode
        'Checks if the tower indicator is not in collision with any picturebox to ensure that the spawn location is valid
        'If the location is valid then it will hide the UI used during tower placing and create a tower to be placed at this new set position

        If TowerPlacing = True Then


            For Each PictureBox As PictureBox In Controls.OfType(Of PictureBox)

                If PictureBox IsNot TowerIndicator AndAlso TowerIndicator.Bounds.IntersectsWith(PictureBox.Bounds) Then
                    Exit Sub
                End If

            Next

            TowerIndicator.Hide()
            CancelPlacing.Hide()

            ReDim Preserve PicTower(TowerCount)


            PicTower(TowerCount) = New PictureBox With {
    .Size = New Size(37, 33),
    .BackColor = Color.CadetBlue,
    .Name = "PicTower" & TowerCount.ToString,
    .Location = PointToClient(Cursor.Position) - p
                    }

            Controls.Add(PicTower(TowerCount))
            PicTower(TowerCount).BringToFront()


            AddHandler PicTower(TowerCount).Click, AddressOf Tower_Click

            ReDim Preserve Towers(TowerCount)
            Towers(TowerCount) = New Tower(PicTower(TowerCount), 160, 1)
            currentTowers.Add(Towers(TowerCount))

            Coins -= 30
            TowerCount += 1

            TowerPlacing = False

        End If


    End Sub

    'If the cancel Placing button is pressed then stop the player from placing a tower and hide the relevant UI

    Private Sub CancelPlacing_Click(sender As Object, e As EventArgs) Handles CancelPlacing.Click

        TowerPlacing = False
        TowerIndicator.Hide()
        CancelPlacing.Hide()

    End Sub

    Private Sub TowerLogic_Tick(sender As Object, e As EventArgs) Handles TowerLogic.Tick

        'Updates Tower UI

        LblTowerCapacity.Text = "Tower Capacity" & " " & TowerCount & "/25"
        LblTowerdmgBuffCost.Text = BuffPrice & " COINS"

        If UpgradeIndex = 3 Then
            LblTowerdmgBuffCost.Text = "MAXED"
        End If


        'For every tower find it a target and check if has been upgraded to the highest upgrade available

        For counter = 0 To TowerCount - 1

            currentTowers(counter).FindTarget()

            For i = 0 To 2
                If boughtUpgrade(i) = True Then
                    If currentTowers(counter).getdamage <> 2 + i Then
                        currentTowers(counter).setDamage(2 + i)

                    End If
                End If
            Next

        Next

    End Sub

    'Timer that runs every second and works as if the tower is dealing damage to the enemy every second

    Private Sub TowerShooting_Tick(sender As Object, e As EventArgs) Handles TowerShooting.Tick

        For counter = 0 To TowerCount - 1
            currentTowers(counter).shootTarget()
        Next

    End Sub

    Public Sub Tower_Click(sender As Object, e As EventArgs)

        For counter = 0 To TowerCount - 1
            If sender Is currentTowers(counter).getTowerGraphic Then
                clickedTower = currentTowers(counter)
            End If
        Next

        If clickedTower IsNot Nothing Then

            TowerOptionsPanel.Show()
            TowerOptionsPanel.BringToFront()
            clickedTower.getTowerGraphic.bringtofront

            TowerOptionsPanel.Location = New Point(clickedTower.getTowerGraphic.location.x - 44, clickedTower.getTowerGraphic.location.y - 67)

        End If


    End Sub

    Private Sub SellButton_Click(sender As Object, e As EventArgs) Handles SellButton.Click


        Coins += 20

        For counter = 0 To TowerCount - 1
            If currentTowers(counter).getTowerGraphic Is clickedTower.getTowerGraphic Then

                Controls.Remove(currentTowers(counter).getTowerGraphic)
                currentTowers(counter) = Nothing
                currentTowers.RemoveAt((counter))

                TowerOptionsPanel.Hide()
                TowerCount -= 1
                clickedTower = Nothing

            End If
        Next
    End Sub




    'Runs once the buff button for damage has been clicked
    'Initially checks if the player has enough coins, atleast 1 tower, and they have not bought all 3 upgrades
    'Then it sets the pictureboxes backcolor that displays if the current upgrade has been bought to green
    'Deducts the price from the coins, sets the next buff price, sets the current bought upgrade to true and increases the upgradeindex so that the next upgrade can be bought

    Private Sub DamageBuffbutton_Click(sender As Object, e As EventArgs) Handles DamageBuffButton.Click

        Dim UpgradeSlots() = {DamageBuff1, DamageBuff2, DamageBuff3}

        If Coins >= BuffPrice And TowerCount >= 1 And UpgradeIndex <= 2 Then

            UpgradeSlots(UpgradeIndex).BackColor = Color.Green
            Coins -= BuffPrice
            BuffPrice = 1500 + (UpgradeIndex * 500)
            boughtUpgrade(UpgradeIndex) = True
            UpgradeIndex += 1

        End If

    End Sub

    'Used to reset the game to a state to allow the next wave to use the games logic

    Public Sub InitializeGame()

        'Remoevs pictureboxes of previous wave

        For counter = 0 To TotalEnemiesInWave - 1
            Controls.Remove(Enemies(counter).getEnemyGraphic)
            Enemies(counter).getEnemyGraphic.Dispose()
        Next

        'Sets arrays to nothing, logic variables to 0 or false and stops the nextspawndelay timer

        Enemies = Nothing
        PicEnemies = Nothing
        TotalEnemiesInWave = 0
        EnemiesKilledInWave = 0
        WaveEnded = False
        EnemyNum = 0
        enemiesleftover = False
        NextSpawnDelay.Stop()

    End Sub

    'Runs if the player dies or completes the last wave
    'Stops the game from running by stopping the timers and displays the game over screen while starting the timer for the leaderboard to be shown 2.5 seconds later

    Public Sub Endgame()

        GameLogic.Stop()
        EnemyLogic.Stop()
        TowerLogic.Stop()
        TowerShooting.Stop()

        LblGameOver.Show()
        LblGameOver.BringToFront()

        LeaderBoardDelay.Start()

    End Sub

    Private Sub LeaderBoardDelay_Tick(sender As Object, e As EventArgs) Handles LeaderBoardDelay.Tick

        'Hides Game over screen
        'Moves the leaderboard panel to cover the screen and stops the timer to prevent it from being shown once the next game has started


        LblGameOver.Hide()
        LeaderBoardPanel.Location = New Point(0, 0)
        LeaderBoardPanel.Show()
        LeaderBoardPanel.BringToFront()
        LeaderBoardDelay.Stop()

    End Sub

    'Runs if there is a key that is pressed down while using the newName text box

    Private Sub newName_KeyDown(sender As Object, e As KeyEventArgs) Handles newName.KeyDown

        'If the key was enter and the name entered is valid then it hides the previous leaderbaord UI
        'Declares the new name and waves reached to be held in the 6th position of the arrays for playernames and waves reached

        If e.KeyCode = Keys.Enter And newName.Text.Length = 3 Then

            newName.Hide()
            LblEnterUsername.Hide()
            UserName = newName.Text
            PlayerNames(5) = UserName
            WavesReached(5) = Wave

            'Insertion sorts the leaderboard with respect to waves reached

            For counter = 1 To 5

                Dim tempName = PlayerNames(counter)
                Dim tempWave = WavesReached(counter)
                Dim index = counter

                While index > 0 AndAlso tempWave > WavesReached(index - 1)

                    WavesReached(index) = WavesReached(index - 1)
                    PlayerNames(index) = PlayerNames(index - 1)

                    index = index - 1
                End While

                WavesReached(index) = tempWave
                PlayerNames(index) = tempName

            Next

            'Sets each label to their associated playerName and waves reached for the first 5 positions and shows the leaderboard

            For counter = 0 To 4

                NameLabels(counter).Text = PlayerNames(counter)
                NameLabels(counter).Show()

                WaveReachedLabels(counter).Text = WavesReached(counter)
                WaveReachedLabels(counter).Show()

            Next

            'Displays leaderbaord UI

            UpdateTableButton.Show()
            LblPlayerNamesHeading.Show()
            LblWavesReachedHeading.Show()


        End If

    End Sub




    Private Sub RetryButton_Click(sender As Object, e As EventArgs) Handles RetryButton.Click

        'Hides Leaderboard UI and resets the text box and shows the Recieving the player name for next use

        newName.Show()
        LblEnterUsername.Show()
        LblPlayerNamesHeading.Hide()
        LblWavesReachedHeading.Hide()
        UpdateTableButton.Hide()
        LeaderBoardPanel.Hide()
        newName.Text = Nothing

        For counter = 0 To 4
            NameLabels(counter).Hide()
            WaveReachedLabels(counter).Hide()
        Next

        'Resets player stats

        Lives = 10
        Coins = 60
        Wave = 1

        'Resets the game for enemies

        additionalEnemies = 0
        InitializeGame()

        'Resets the game for towers

        For counter = 0 To TowerCount - 1
            Controls.Remove(Towers(counter).getTowerGraphic)
        Next
        Towers = Nothing
        PicTower = Nothing
        TowerCount = 0
        TowerPlacing = False
        UpgradeIndex = 0
        For counter = 0 To 2
            boughtUpgrade(counter) = False
        Next
        BuffPrice = 1000

        startGameTimers()

        'Spawns wave 1 again

        WaveSpawn()

    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click

        Close()

    End Sub


    Public Sub startGameTimers()

        GameLogic.Start()
        EnemyLogic.Start()
        TowerLogic.Start()
        TowerShooting.Start()


    End Sub

    Public Sub LoadUI()

        StartButton.Hide()
        QuitButton.Hide()

        LblLives.Show()
        LblCoins.Show()
        LblWave.Show()

        TurretPanel.Show()
        LblTower1Cost.Show()
        TowerBuy1.Show()
        DamageBuffButton.Show()
        DamageBuff1.Show()
        DamageBuff2.Show()
        DamageBuff3.Show()
        LblTowerdmgBuffCost.Show()
        LblTowerCapacity.Show()
        TurretPanel.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTower1Cost.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTowerCapacity.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        LblTowerdmgBuffCost.BackColor = Color.FromArgb(130, TurretPanel.BackColor)
        TowerOptionsPanel.BackColor = Color.FromArgb(130, TurretPanel.BackColor)

    End Sub

    Public Sub InitializeLabels()

        NameLabels(0) = LblName1
        NameLabels(1) = LblName2
        NameLabels(2) = LblName3
        NameLabels(3) = LblName4
        NameLabels(4) = LblName5

        WaveReachedLabels(0) = LblWaveReached1
        WaveReachedLabels(1) = LblWaveReached2
        WaveReachedLabels(2) = LblWaveReached3
        WaveReachedLabels(3) = LblWaveReached4
        WaveReachedLabels(4) = LblWaveReached5

        For counter = 0 To 4

            NameLabels(counter).Text = PlayerNames(counter)
            WaveReachedLabels(counter).Text = WavesReached(counter)

        Next

    End Sub

    Public Sub setLives(LivesLost As Integer)

        Lives -= LivesLost

    End Sub

    Public Sub setCoins(CoinsEarned As Integer)

        Coins += CoinsEarned

    End Sub

    Public Sub settotalCoinsEarned(CoinsEarned As Integer)

        TotalCoinsEarned += CoinsEarned
    End Sub

    Public Sub setEnemiesKilledInWave(AmountKilled As Integer)

        EnemiesKilledInWave += AmountKilled

    End Sub

    Public Sub setTotalEnemiesKilled(AmountKilled As Integer)

        TotalEnemiesKilled += AmountKilled

    End Sub
    Public Function getEnemies()

        Return Enemies

    End Function

    Public Function getTowers()

        Return Towers

    End Function

    Public Function getWaveEnded()

        Return WaveEnded

    End Function


End Class





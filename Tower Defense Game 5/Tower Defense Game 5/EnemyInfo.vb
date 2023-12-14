Public Class EnemyInfo


    'Totalenemiesinwave will be assigned to the value equal to the number of enemies created for that wave
    'EnemiesKilledInWave will be incremented from 0 for every enemy that has been killed
    'These variables are used to check if a wave has ended

    'additionalEnemies is increased by 2 after a wave has ended, used to increase the amount of enemies spawned for the next wave
    'Enemynum is used to hold the index of the next enemy to be spawned as well is to check if every enemy has been spawned
    'LastEnemy holds the last enemy object to be spawned, used to check if this enemy has died and to then spawn the next group of enemies for that wave 2 seconds later if possible

    Private Enemies() As Enemy
    Private PicEnemies() As PictureBox
    Private TotalEnemiesInWave As Integer
    Private EnemiesKilledInWave As Integer
    Private WaveEnded As Boolean
    Private additionalEnemies As Integer
    Private EnemyNum As Integer
    Private LastEnemy As Enemy


    Public Sub setEnemies(Index As Integer, Enemy As Enemy)

        Enemies(Index) = Enemy

    End Sub

    Public Function getEnemies(Index)

        Return Enemies(Index)

    End Function

    Public Sub setPicEnemies(Index As Integer, PictureBox As PictureBox)

        PicEnemies(Index) = PictureBox

    End Sub

    Public Function getPicEnemies(Index As Integer)

        Return PicEnemies(Index)

    End Function

    Public Sub setTotalEnemiesInWave(Amount As Integer)

        TotalEnemiesInWave += Amount

    End Sub

    Public Function getTotalEnemiesInWave()

        Return TotalEnemiesInWave

    End Function

    Public Sub setEnemiesKilledInWave(Amount As Integer)

        EnemiesKilledInWave += Amount

    End Sub

    Public Function getEnemiesKilledInWave()

        Return EnemiesKilledInWave

    End Function

    Public Sub setWaveEnded(State As Boolean)

        WaveEnded = State

    End Sub

    Public Function getWaveEnded()

        Return WaveEnded

    End Function

    Public Sub setadditionalEnemies(Value)

        additionalEnemies += Value

        If Value = Nothing Then

            additionalEnemies = Value

        End If


    End Sub

    Public Function getadditionalEnemies()

        Return additionalEnemies

    End Function

    Public Sub setEnemyNum()

        EnemyNum += 1

    End Sub

    Public Function getEnemyNum()

        Return EnemyNum

    End Function

    Public Sub setLastEnemy(Enemy As Enemy)

        LastEnemy = Enemy

    End Sub

    Public Function getLastEnemy()

        Return LastEnemy

    End Function

    Public Sub setLastEnemyIsDead(State As Boolean)

        LastEnemy.setIsdead(State)

    End Sub

    Public Function getLastEnemyIsDead()

        Return LastEnemy.getIsDead

    End Function

End Class

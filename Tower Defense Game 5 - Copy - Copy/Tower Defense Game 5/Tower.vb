
Public Class Tower

    Private TowerGraphic As PictureBox
    Private TargetEnemy As Enemy
    Private Range As Integer
    Private damage As Integer

    Public Sub New(Graphic As PictureBox, Range As Integer, Damage As Integer)

        TowerGraphic = Graphic
        TargetEnemy = Nothing

        With Me

            .Range = Range
            .damage = Damage

        End With

    End Sub

    'Method used to find the next target for a tower
    'First if statement is used to check the towers who already have a target, and if this target is no longer in range, then it should no longer be its target
    'Second if statement is used to assign targets to towers which currently don't have one, it checks every enemy to the given tower from the for loop to check if one is in range
    'As soon as it finds one it assigns it as its target, exits for since it is no longer necessary

    Public Sub FindTarget()

        If TargetEnemy IsNot Nothing Then
            If EnemyIsInRange(Me, TargetEnemy) = False Then
                Console.WriteLine("Enemy Left Range")
                TargetEnemy = Nothing
            End If
        End If

        If TargetEnemy Is Nothing Then

            For Each Enemy As Enemy In Form1.getEnemies

                If EnemyIsInRange(Me, Enemy) Then

                    Console.WriteLine("Enemy In Range")
                    TargetEnemy = Enemy
                    Exit For

                End If

            Next

        End If

    End Sub

    'Method used to shoot the towers target
    'First for each loop checks every tower to check if its targets health is already 0, if so it sets its target to nothing, this prevents the enemy death condition from running for an enemy that is already dead
    'If statement is used to check if the tower has a target, if so it then reduces the targets health by 1,
    'then if the targets health reaches 0 it incerases the enemieskilledinwave and totalenemieskilled by 1,
    'increases the players coins by the amount recieved from the enemy and increases total coins earned by the amount recieved from the enemy
    'targetenemies associated enemy object isdead attribute is set to false
    'target enemy is set to nothing

    Public Sub shootTarget()

        With Form1

            For Each otherTower As Tower In .getTowers

                If otherTower.TargetEnemy IsNot Nothing AndAlso otherTower.TargetEnemy.getHealth <= 0 Then

                    otherTower.TargetEnemy = Nothing

                End If

            Next

            If TargetEnemy IsNot Nothing Then

                TargetEnemy.setHealth(damage)


                If TargetEnemy.getHealth <= 0 And TargetEnemy.getIsDead = False Then

                    TargetEnemy.getEnemyGraphic.Top -= 1000
                    .setEnemiesKilledInWave(1)
                    .setTotalEnemiesKilled(1)

                    If .getWaveEnded = False Then
                        .setCoins(TargetEnemy.getCoinsDropped)
                        .settotalCoinsEarned(TargetEnemy.getCoinsDropped)
                    End If

                    TargetEnemy.setIsdead(True)
                    TargetEnemy = Nothing

                End If
            End If

        End With

    End Sub

    'Towers will shoot any enemy that is in an area of a circle that surrounds the tower
    'the radius of this circle is equal to the towers range
    'Therefore if the distance is less than the range it must be in this valid area to be shot if it is a target
    'Function used to calculate the distance between a given tower and enemy

    Public Function EnemyIsInRange(Tower As Tower, Enemy As Enemy) As Boolean

        Dim p As New Point(18, 16)

        Dim towerCenterX As Integer = Tower.TowerGraphic.Location.X - p.X
        Dim towerCenterY As Integer = Tower.TowerGraphic.Location.Y - p.Y
        Dim enemyCenterX As Integer = Enemy.getEnemyGraphic.Location.X - Enemy.getEnemyGraphic.Width \ 2
        Dim enemyCenterY As Integer = Enemy.getEnemyGraphic.Location.Y - Enemy.getEnemyGraphic.Height \ 2

        Dim distance As Double = Math.Sqrt((towerCenterX - enemyCenterX) ^ 2 + (towerCenterY - enemyCenterY) ^ 2)


        Return Enemy.getEnemyGraphic.Location.X >= 15 And
    distance <= Range

    End Function


    Public Function getTowerGraphic()

        Return TowerGraphic

    End Function

    Public Sub setDamage(Newdamage As Integer)

        damage = Newdamage

    End Sub

    Public Function getdamage()

        Return damage

    End Function
End Class

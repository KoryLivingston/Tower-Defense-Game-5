
Public Class Tower

    'attributes of Towers

    Public TowerGraphic As PictureBox
    Public TargetEnemy As Enemy
    Public Range As Integer
    Public damage As Integer

    Public Sub New(Graphic As PictureBox, Range As Integer, Damage As Integer)

        TowerGraphic = Graphic
        TargetEnemy = Nothing

        With Me

            .Range = Range
            .damage = Damage

        End With


    End Sub


    Public Sub DealDamage(Enemy As Enemy)

        If TargetEnemy IsNot Nothing Then
            Enemy.Health -= Me.damage
        End If

    End Sub


End Class

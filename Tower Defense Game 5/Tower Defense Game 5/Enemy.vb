Public Class Enemy


    Public Enemygraphic As PictureBox
    Public MovementSpeed As Integer
    Public Health As Integer
    Public CoinsDropped As Integer
    Public EnemyLocation As Point

    Public Sub New(Graphic As PictureBox, MovementSpeed As Integer, Health As Integer, CoinsDropped As Integer)

        Enemygraphic = Graphic
        EnemyLocation = Nothing

        With Me

            .MovementSpeed = MovementSpeed
            .Health = Health
            .CoinsDropped = CoinsDropped

        End With

    End Sub

    Public Sub MoveEnemy()

        If Enemygraphic.Location.X > -1000 And Enemygraphic.Location.X < 405 Then
            Enemygraphic.Left += MovementSpeed
        End If

        If Enemygraphic.Location.X > 400 And Enemygraphic.Location.Y > 122 Then
            Enemygraphic.Top -= MovementSpeed
        End If

        If Enemygraphic.Location.Y <= 122 Then
            Enemygraphic.Left += MovementSpeed
        End If



    End Sub

    Public Sub EnemyReachedBase()

        If Enemygraphic.Bounds.IntersectsWith(Form1.PicBase.Bounds) Then

            Enemygraphic.Top -= 1000
            With Form1
                .Lives -= 1
                .EnemiesKilledInWave += 1
            End With
        End If


    End Sub



End Class

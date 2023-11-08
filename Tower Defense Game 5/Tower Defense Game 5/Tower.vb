Public Class Tower

    Public TowerGraphic As PictureBox
    Public ShotsGraphic As PictureBox
    Public ShotSpeed As Integer
    Public Range As Integer
    Public damage As Integer
    Public TowerLocation As Point
    Public Sub New(Graphic As PictureBox, TowerShots As PictureBox, ShotSpeed As Integer, Range As Integer, Damage As Integer)

        TowerGraphic = Graphic
        TowerLocation = Nothing

        With Me

            .ShotsGraphic = TowerShots
            .ShotSpeed = ShotSpeed
            .Range = Range
            .damage = Damage
        End With


    End Sub



End Class

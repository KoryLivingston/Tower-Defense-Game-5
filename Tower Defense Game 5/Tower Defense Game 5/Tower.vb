Public Class Tower

    Public TowerGraphic As PictureBox
    Public Range As Integer
    Public damage As Integer
    Public TowerLocation As Point
    Public Sub New(Graphic As PictureBox, Range As Integer, Damage As Integer)

        TowerGraphic = Graphic
        TowerLocation = Nothing

        With Me

            .Range = Range
            .damage = Damage
        End With


    End Sub



End Class

Public Class Tower

    Public TowerGraphic As PictureBox
    Public TowerLocation As Point
    Public Range As Integer



    Public Sub New(Graphic As PictureBox, Range As Integer)

        TowerGraphic = Graphic
        TowerLocation = Nothing

        With Me

            .Range = Range

        End With

    End Sub



End Class

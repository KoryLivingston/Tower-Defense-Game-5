Public Class Tower

    Public TowerGraphic As PictureBox
    Public Price As Integer

    Public Sub New(Graphic As PictureBox, Price As Integer)

        TowerGraphic = Graphic

        With Me

            .Price = Price

        End With

    End Sub



End Class

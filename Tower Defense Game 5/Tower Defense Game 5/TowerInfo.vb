Public Class TowerInfo

    'Towercount is used to redclare the arrays to hold the new position of the next tower to be created
    'Towerplacing is used to determine whether the player is placing a tower and to run certain code while doing so

    Private TowerCount As Integer
    Private TowerPlacing As Boolean

    'ClickedTower holds the tower object that has been clicked, this will then be used in the code involving the tower UI
    'Index holds the position of this tower in the list, so if it is sold it can be removed from the list

    Private clickedTower As Tower
    Private Index As Integer

    Public Sub setTowerCount()

        TowerCount += 1

    End Sub

    Public Function getTowerCount()

        Return TowerCount

    End Function

    Public Sub setTowerPlacing(State As Boolean)

        TowerPlacing = State

    End Sub

    Public Function getTowerPlacing()

        Return TowerPlacing

    End Function

    Public Sub setClickedTower(Tower As Tower)

        clickedTower = Tower

    End Sub

    Public Function getClickedTower()

        Return clickedTower

    End Function

    Public Sub setIndex(NewIndex As Integer)

        Index = NewIndex

    End Sub

    Public Function getIndex()

        Return Index

    End Function
End Class

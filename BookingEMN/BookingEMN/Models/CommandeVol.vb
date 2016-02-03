Public Class CommandeVol
    Inherits Commande

    Private idVol As Integer

    Public Sub New()

    End Sub

    Public Sub New(idVol As Integer, client As Client)
        MyBase.New(client)
        Me.idVol = idVol
    End Sub

    Public Property Id
        Get
            Return Me.idVol
        End Get
        Set(value)
            Me.idVol = value
        End Set
    End Property

End Class

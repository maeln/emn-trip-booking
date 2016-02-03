Public MustInherit Class Commande

    Private clientValue As Client

    Public Sub New()

    End Sub
    Public Sub New(client As Client)
        Me.clientValue = client
    End Sub

    Public Property Client
        Get
            Return Me.clientValue

        End Get
        Set(value)
            Me.clientValue = value
        End Set
    End Property

End Class

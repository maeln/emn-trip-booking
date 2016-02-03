Public Class CommandeHotel
    Inherits Commande

    Private idHotel As Integer
    Private dateDebutValue As String
    Private dateFinValue As String

    Public Sub New()

    End Sub

    Public Sub New(idHotel As Integer, dateDebut As String, dateFin As String, client As Client)
        MyBase.New(client)
        Me.idHotel = idHotel
        Me.dateDebutValue = dateDebut
        Me.dateFinValue = dateFin
    End Sub

    Public Property Id
        Get
            Return Me.idHotel
        End Get
        Set(value)
            Me.idHotel = value
        End Set
    End Property

    Public Property DateDebut() As String
        Get
            Return dateDebutValue
        End Get
        Set(ByVal value As String)
            dateDebutValue = value
        End Set
    End Property

    Public Property DateFin() As String
        Get
            Return dateFinValue
        End Get
        Set(ByVal value As String)
            dateFinValue = value
        End Set
    End Property
End Class

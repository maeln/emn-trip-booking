Public Class Client

    Private nomClient As String
    Private prenomClient As String
    Private telephoneClient As String
    Private mailClient As String

    Public Sub New()

    End Sub

    Public Sub New(nom As String, prenom As String, telephone As String, mail As String)
        Me.nomClient = nom
        Me.prenomClient = prenom
        Me.telephoneClient = telephone
        Me.mailClient = mail
    End Sub

    Public ReadOnly Property Nom As String
        Get
            Return Me.nomClient
        End Get
    End Property
    Public ReadOnly Property Prenom As String
        Get
            Return Me.prenomClient
        End Get
    End Property
    Public ReadOnly Property Telephone As String
        Get
            Return Me.telephoneClient
        End Get
    End Property
    Public ReadOnly Property Mail As String
        Get
            Return Me.mailClient
        End Get
    End Property

End Class

Public Class BookingMessage

    Private idVolValue As Integer
    Public Property IdVol() As Integer
        Get
            Return idVolValue
        End Get
        Set(ByVal value As Integer)
            idVolValue = value
        End Set
    End Property

    Private idHotelValue As Integer
    Public Property IdHotel() As Integer
        Get
            Return idHotelValue
        End Get
        Set(ByVal value As Integer)
            idHotelValue = value
        End Set
    End Property

    Private nomValue As String
    Public Property Nom() As String
        Get
            Return nomValue
        End Get
        Set(ByVal value As String)
            nomValue = value
        End Set
    End Property

    Private prenomValue As String
    Public Property Prenom() As String
        Get
            Return prenomValue
        End Get
        Set(ByVal value As String)
            prenomValue = value
        End Set
    End Property

    Private mailValue As String
    Public Property Mail() As String
        Get
            Return mailValue
        End Get
        Set(ByVal value As String)
            mailValue = value
        End Set
    End Property

    Private telephoneValue As String
    Public Property Telephone() As String
        Get
            Return telephoneValue
        End Get
        Set(ByVal value As String)
            telephoneValue = value
        End Set
    End Property

    Private dateDebutValue As String
    Public Property DateDebut() As String
        Get
            Return dateDebutValue
        End Get
        Set(ByVal value As String)
            dateDebutValue = value
        End Set
    End Property

    Private dateFinValue As String
    Public Property DateFin() As String
        Get
            Return dateFinValue
        End Get
        Set(ByVal value As String)
            dateFinValue = value
        End Set
    End Property

    Private Function GetClient() As Client
        Return New Client(nomValue, prenomValue, mailValue, telephoneValue)
    End Function

    Public Function GetCommandeVol() As CommandeVol
        If (idHotelValue <> Nothing) Then
            Return New CommandeVol(idVolValue, Me.GetClient)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetCommandeHotel() As CommandeHotel
        If (idVolValue <> Nothing) Then
            Return New CommandeHotel(idHotelValue, dateDebutValue, dateFinValue, Me.GetClient)
        Else
            Return Nothing
        End If
    End Function

End Class

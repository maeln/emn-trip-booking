Imports System.EnterpriseServices
Imports BookingEMN
Imports HotelLibrary
Imports VolLibrary

<Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled>
Public Class TransactionCommande
    Inherits ServicedComponent

    <AutoComplete>
    Friend Sub registerVol(cmdVol As CommandeVol)
        Dim volRegisterer As New LibVol
        Try
            volRegisterer.EnregistrerVol(cmdVol.Id, cmdVol.Client.Nom, cmdVol.Client.Prenom, cmdVol.Client.Telephone, cmdVol.Client.Mail)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    <AutoComplete>
    Friend Sub registerHotel(cmdHotel As CommandeHotel)
        Dim hotelRegisterer As New LibHotel
        Try
            hotelRegisterer.EnregistrerHotel(cmdHotel.Id, cmdHotel.DateDebut, cmdHotel.DateFin, cmdHotel.Client.Nom, cmdHotel.Client.Prenom, cmdHotel.Client.Telephone, cmdHotel.Client.Mail)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

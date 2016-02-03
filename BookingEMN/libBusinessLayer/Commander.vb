Imports System.Messaging
Imports BookingEMN

Public Class Commander

    Public Sub ReadQueue()
        Dim mq As MessageQueue
        If MessageQueue.Exists(".\Private$\BookingEMN") Then
            mq = New MessageQueue(".\Private$\BookingEMN")
        Else
            mq = MessageQueue.Create(".\Private$\BookingEMN")
        End If

        mq.Formatter = New XmlMessageFormatter(New Type() {GetType(BookingMessage)})
        Dim msg As BookingMessage = CType(mq.Peek().Body, BookingMessage)

        Dim registered As Boolean = Me.Commander(msg)

        If (registered) Then
            mq.Receive()
            Console.WriteLine("Message successfully treated")
        Else
            Console.WriteLine("Error while treating Message")
        End If
        mq.Close()
    End Sub

    Private Function Commander(msg As BookingMessage) As Boolean
        Dim ret As Boolean = True

        Dim cmdVol As CommandeVol = msg.GetCommandeVol
        Dim cmdHotel As CommandeHotel = msg.GetCommandeHotel
        Dim transCmd As New TransactionCommande()
        Try
            If (cmdVol IsNot Nothing) Then
                transCmd.registerVol(cmdVol)
            End If
            If (cmdHotel IsNot Nothing) Then
                transCmd.registerHotel(cmdHotel)
            End If
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

End Class

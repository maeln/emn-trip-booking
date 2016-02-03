Imports System.Messaging
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Namespace Controllers
    <RoutePrefix("/api/commande")>
    Public Class CommandeController
        Inherits ApiController

        ' POST: api/commande
        Public Function PostValue(msg As BookingMessage) As HttpResponseMessage
            Dim response As HttpResponseMessage
            Try
                Dim mq As MessageQueue
                If MessageQueue.Exists(".\Private$\BookingEMN") Then
                    mq = New MessageQueue(".\Private$\BookingEMN")
                Else
                    mq = MessageQueue.Create(".\Private$\BookingEMN")
                End If
                mq.Send(msg)
                mq.Close()
                response = Request.CreateResponse(HttpStatusCode.OK, "Commande enregistrée")
            Catch ex As Exception
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.Message)
            End Try

            Return response
        End Function

    End Class
End Namespace
Imports System.Net
Imports System.Web.Http
Imports libBusinessLayer

<RoutePrefix("/api/msmq")>
Public Class ValuesController1
    Inherits ApiController

    ' GET api/msmq
    Public Function GetValues() As IEnumerable(Of String)
        Dim cmder As New Commander()
        cmder.ReadQueue()
        Return "Ok"
    End Function


End Class

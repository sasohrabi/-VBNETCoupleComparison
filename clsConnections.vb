Public Class clsConnections
    Inherits clsVariables

    Public Shared sClsCon As New clsConnections

    Sub New()
        sClsCon = Me
    End Sub

    Public Function setConnectionString() As String
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\mdb.mdb" + ";Persist Security Info=False;"
    End Function

    Public Function setOleDbConnectionState() 'For Oledb Connection

        If (sOleDbConnection.State = ConnectionState.Open) Then
            sOleDbConnection.Close()
        End If
        sOleDbConnection.ConnectionString = setConnectionString()

        Return ""
    End Function

End Class

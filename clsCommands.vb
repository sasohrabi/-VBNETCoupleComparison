Public Class clsCommands
    Inherits clsVariables

    Public Function setOledbAdapter(ByRef dsFill As DataSet, ByVal daFill As OleDb.OleDbDataAdapter, ByVal sSQL As String, ByVal sTable As String) As DataSet
        clsConnections.sClsCon.setOleDbConnectionState()
        clsConnections.sClsCon.sOleDbConnection.Open()
        daFill.SelectCommand = New OleDb.OleDbCommand(sSQL, clsConnections.sClsCon.sOleDbConnection)
        ' dsFill.Clear()
        daFill.Fill(dsFill, sTable)
        Return dsFill
    End Function

    Public Function setOleDbCommand(ByVal sSQL As String)

        'Set Connection
        clsConnections.sClsCon.setOleDbConnectionState()
        clsConnections.sClsCon.sOleDbConnection.Open()
        sOleDbCommand.Connection = clsConnections.sClsCon.sOleDbConnection
        sOleDbCommand.CommandText = sSQL
        sOleDbCommand.ExecuteNonQuery()
        sOleDbConnection.Close()

        Return ""
    End Function

    Public Function getOleDbCommand(ByVal sSQL As String) As Integer
        clsConnections.sClsCon.setOleDbConnectionState()
        clsConnections.sClsCon.sOleDbConnection.Open()
        sOleDbCommand.Connection = clsConnections.sClsCon.sOleDbConnection
        sOleDbCommand.CommandText = sSQL

        Return sOleDbCommand.ExecuteScalar
    End Function
    Public Function getOleDbCommand2(ByVal sSQL As String) As String
        clsConnections.sClsCon.setOleDbConnectionState()
        clsConnections.sClsCon.sOleDbConnection.Open()
        sOleDbCommand.Connection = clsConnections.sClsCon.sOleDbConnection
        sOleDbCommand.CommandText = sSQL

        Return sOleDbCommand.ExecuteScalar
    End Function

    Public Function setOledbCommandReader(ByVal sSQL As String) As OleDb.OleDbDataReader

        'Set Connection
        clsConnections.sClsCon.setOleDbConnectionState()
        clsConnections.sClsCon.sOleDbConnection.Open()
        sOleDbCommand.Connection = clsConnections.sClsCon.sOleDbConnection
        sOleDbCommand.CommandText = sSQL
        sOleDbDataReader = sOleDbCommand.ExecuteReader()

        Return sOleDbDataReader
    End Function


End Class

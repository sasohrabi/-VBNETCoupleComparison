Imports System.Data
Imports System.Data.OleDb

Public Class clsVariables

    Public sOleDbConnection As New OleDbConnection
    Public sOleDbCommand As New OleDbCommand
    Public sOleDbDataReader As OleDbDataReader
    Public sOleDataAdapter As New OleDbDataAdapter

    'BOOLEAN VARIABLES
    Public boolConnected As Boolean = False

End Class

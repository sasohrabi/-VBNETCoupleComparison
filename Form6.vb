Public Class Form6

    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsreport As New mdbDataSet
        Dim rptViewer As New CrystalReport4
        Dim ds As DataSet

        '    ds = object_cmd.setOledbAdapter(dsreport, sVariables.sOleDataAdapter, "select * from temprep", "temprep")

        ds = object_cmd.setOledbAdapter(dsreport, sVariables.sOleDataAdapter, "select * from temprep", "temprep")
        ds = object_cmd.setOledbAdapter(dsreport, sVariables.sOleDataAdapter, "select * from tblAcademy", "tblAcademy")
        rptViewer.SetDataSource(ds)
        Me.CrystalReportViewer1.ReportSource = rptViewer
        '       crystalviewer.ReportSource = rptViewer;

        'Dim rpt As New CrystalReport3
        ''rpt.SetDatabaseLogon("admin", "83440085")
        'Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class
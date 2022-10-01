Public Class _srchDG
    Public Shared Sub _srchDG(ByRef dg As System.Windows.Forms.DataGridView, ByVal fld As String, ByVal vle As String)
        Dim drw = (From rw As System.Windows.Forms.DataGridViewRow In dg.Rows Where rw.Cells(fld).Value Like vle Or rw.Cells(fld).Value.ToString.Contains(vle)).LastOrDefault

        'System.Windows.Forms.MessageBox.Show(drw.Index)
        If dg.Rows.Count = 0 Then Exit Sub

        If IsNothing(drw) Then
            dg.Rows(0).Selected = True
            dg.FirstDisplayedScrollingRowIndex = 0
            dg.CurrentCell = dg.Rows(0).Cells(fld)
        Else
            dg.Rows(drw.Index).Selected = True
            dg.FirstDisplayedScrollingRowIndex = drw.Index
            dg.CurrentCell = drw.Cells(fld)
        End If
    End Sub
End Class

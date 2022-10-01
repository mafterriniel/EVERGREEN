Public Class _vldxn
    Public Shared Function _vldxnChrs(ByVal cs As List(Of System.Windows.Forms.Control)) As Boolean
        Dim r As Boolean = True
        For Each c As System.Windows.Forms.Control In cs
            For ChrIdx = 1 To Len(c.Text)
                If GetChar(c.Text, ChrIdx) = "'" Then
                    r = False
                End If

                If GetChar(c.Text, ChrIdx) = "' '" Then
                    r = False
                End If
            Next
        Next
        Return r
    End Function
End Class

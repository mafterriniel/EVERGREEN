Public Class fmttr

    Public Shared Function vdtNum(ByVal str As String, ByVal t As TriState, Optional ByVal d As Integer = 0, Optional ByVal disZero As Boolean = False) As String
        Dim r As String = ""
        str = (IIf(String.IsNullOrWhiteSpace(str), "0", str))
            If IsNumeric(str) = (False) Then Return str
        r = FormatNumber(str, d, TriState.True, TriState.False, t)
            Return r
    End Function

End Class

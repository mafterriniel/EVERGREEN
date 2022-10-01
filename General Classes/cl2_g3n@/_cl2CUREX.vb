Public Class _cl2CUREX
    Public Shared Function _cl2CUREX(n1 As String, n2 As String) As String
        Try
            ' CURRENCY EXCHANGE
            Dim res As Double = 0

            Dim HWR As System.Net.HttpWebRequest = (System.Net.WebRequest.Create(String.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", n1, n2)))
            HWR.Timeout = 5000
            HWR.KeepAlive = False
            Dim response As Net.HttpWebResponse = HWR.GetResponse
            Dim CStream As System.IO.Stream = response.GetResponseStream

            Dim rw As System.IO.StreamReader = New System.IO.StreamReader(CStream)
            res = Split(rw.ReadToEnd, ",")(1)

            Return res
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

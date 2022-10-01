
Public Class _prts
    Public Class WMIProp_mod
        Public Shared Function lst() As List(Of WMIProp)
            'For Each SP As String In My.Computer.Ports.SerialPortNames
            '    chkPorts.Items.Add(SP)
            'Next
            Dim _sr = New System.Management.ManagementObjectSearcher( _
    "Select * from  Win32_PnpEntity")
            Dim objs As Integer = _sr.Get.Count - 1
            Dim WMIs As New List(Of WMIProp)

            For Each OBJ As System.Management.ManagementObject In _sr.Get()

                If IsNothing(OBJ("CAPTION")) Then
                Else
                    If OBJ("CAPTION").ToString.Contains("(COM") Then

                        Dim WMI As New WMIProp
                        On Error Resume Next
                        With WMI
                            .AVAILABILITY = OBJ("AVAILABILITY")
                            .CAPTION = OBJ("CAPTION")
                            .DESCRIPTION = OBJ("DESCRIPTION")
                            .ERRDESC = OBJ("ERRORDESCRIPTION")
                            .NAME = OBJ("NAME")
                            .STATUS = OBJ("STATUS")
                            .COMM = Mid(Trim(Replace(.NAME, .DESCRIPTION, "")), 2)
                            .COMM = Mid(.COMM, 1, Len(.COMM) - 1)
                            WMIs.Add(WMI)
                        End With

                    End If
                End If
            Next

            Return WMIs
        End Function
    End Class

    Public Class WMIProp
        Private _COMM As String
        Public Property COMM() As String
            Get
                Return _COMM
            End Get
            Set(ByVal value As String)
                _COMM = value
            End Set
        End Property

        Private _NAME As String
        Public Property NAME() As String
            Get
                If IsNothing(_NAME) Then
                    Return ""
                Else
                    Return _NAME
                End If
            End Get
            Set(ByVal value As String)
                _NAME = value
            End Set
        End Property



        Private _CAPTION As String
        Public Property CAPTION() As String
            Get
                If IsNothing(_CAPTION) Then
                    Return ""
                Else
                    Return _CAPTION
                End If
            End Get
            Set(ByVal value As String)
                _CAPTION = value
            End Set
        End Property


        Private _DESCRIPTION As String
        Public Property DESCRIPTION() As String
            Get
                If IsNothing(_DESCRIPTION) Then
                    Return ""
                Else
                    Return _DESCRIPTION
                End If
            End Get
            Set(ByVal value As String)
                _DESCRIPTION = value
            End Set
        End Property


        Private _STATUS As String
        Public Property STATUS() As String
            Get
                If IsNothing(_STATUS) Then
                    Return ""
                Else
                    Return _STATUS
                End If
            End Get
            Set(ByVal value As String)
                _STATUS = value
            End Set
        End Property


        Private _AVAILABILITY As String
        Public Property AVAILABILITY() As String
            Get
                If IsNothing(_AVAILABILITY) Then
                    Return ""
                Else
                    Return _AVAILABILITY
                End If
            End Get
            Set(ByVal value As String)
                _AVAILABILITY = value
            End Set
        End Property


        Private _ERRDESC As String
        Public Property ERRDESC() As String
            Get
                Return _ERRDESC
            End Get
            Set(ByVal value As String)
                _ERRDESC = value
            End Set
        End Property


    End Class
End Class



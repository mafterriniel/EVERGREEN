Imports System.Windows.Forms
Module Module1

    

    Sub Main()
        Dim stp As New stp
        stp.SaveINI()


        System.Console.WriteLine(stp.INI_COMMPORTS)
        System.Console.WriteLine(stp.INI_BAUDRATE)
        System.Console.WriteLine(stp.INI_PARITY)
        System.Console.ReadKey()
    End Sub

End Module

Public Class stp
    Private _SYSFLE As String = Application.StartupPath + "\sys.file"

    Private Function CreateINI() As TextBox
        Dim sysFle As String = Application.StartupPath + "\sys.file"
        Dim txtTmp = New System.Windows.Forms.TextBox
        If System.IO.File.Exists(sysFle).Equals(False) Then
            Dim tw As System.IO.TextWriter = Nothing
            tw = System.IO.File.CreateText(sysFle)

            txtTmp.Text += "[DateCreated]"
            txtTmp.Text += Environment.NewLine() + Format(Now, "yyyy-MM-dd hh:mm:ss")
            txtTmp.Text += Environment.NewLine() + "[DateModified]"
            txtTmp.Text += Environment.NewLine() + Format(Now, "yyyy-MM-dd hh:mm:ss")
            txtTmp.Text += Environment.NewLine() + "[SerialPort]"
            txtTmp.Text += Environment.NewLine() + "INI_COMMPORTS=""COM1"""
            txtTmp.Text += Environment.NewLine() + "INI_BAUDRATE=""9600"""
            txtTmp.Text += Environment.NewLine() + "INI_PARITY=""NONE"""
            txtTmp.Text += Environment.NewLine() + "INI_DATABITS=""8"""
            txtTmp.Text += Environment.NewLine() + "INI_STOPBITS=""1"""

            txtTmp.Text += Environment.NewLine() + "[AccessDB]"
            txtTmp.Text += Environment.NewLine() + "INI_PATH=""C:\Weighing System v1.11"""
            txtTmp.Text += Environment.NewLine() + "INI_PWD=""database"""

            txtTmp.Text += Environment.NewLine() + "[SQLDB]"
            txtTmp.Text += Environment.NewLine() + "INI_SERVERNAME=""WIN-PC\SQLEXPRESS"""
            txtTmp.Text += Environment.NewLine() + "INI_CATALOG=""sysDB"""
            txtTmp.Text += Environment.NewLine() + "INI_UID=""sa"""
            txtTmp.Text += Environment.NewLine() + "INI_PWD=""1"""

            tw.WriteLine(txtTmp.Text)
            tw.Flush()
            tw.Close()
            txtTmp.Text = ""
        End If

        Dim rd As System.IO.TextReader = Nothing
        rd = System.IO.File.OpenText(sysFle)
        While rd.Peek >= 0
            txtTmp.Text = rd.ReadToEnd
        End While
        rd.Close()
        Return txtTmp
    End Function

    Public Sub SaveINI()
        Dim txtTmp As New TextBox
        Dim tw As System.IO.TextWriter = Nothing
        tw = System.IO.File.CreateText(_SYSFLE)

        _DTMODIFIED = Now
        txtTmp.Text = "[DateCreated]"
        txtTmp.Text += Environment.NewLine() + Format(_DTCREATED, "yyyy-MM-dd hh:mm:ss")
        txtTmp.Text += Environment.NewLine() + "[DateModified]"
        txtTmp.Text += Environment.NewLine() + Format(_DTMODIFIED, "yyyy-MM-dd hh:mm:ss")
        txtTmp.Text += Environment.NewLine() + "[SerialPort]"
        txtTmp.Text += Environment.NewLine() + "INI_COMMPORTS=""" & _INI_COMMPORTS & """"
        txtTmp.Text += Environment.NewLine() + "INI_BAUDRATE=""" & _INI_BAUDRATE & """"
        txtTmp.Text += Environment.NewLine() + "INI_PARITY=""" & _INI_PARITY & """"
        txtTmp.Text += Environment.NewLine() + "INI_DATABITS=""" & _INI_DATABITS & """"
        txtTmp.Text += Environment.NewLine() + "INI_STOPBITS=""" & _INI_STOPBITS & """"

        txtTmp.Text += Environment.NewLine() + "[AccessDB]"
        txtTmp.Text += Environment.NewLine() + "INI_PATH=""C:\Weighing System v1.11"""
        txtTmp.Text += Environment.NewLine() + "INI_PWD=""database"""

        txtTmp.Text += Environment.NewLine() + "[SQLDB]"
        txtTmp.Text += Environment.NewLine() + "INI_SERVERNAME=""WIN-PC\SQLEXPRESS"""
        txtTmp.Text += Environment.NewLine() + "INI_CATALOG=""sysDB"""
        txtTmp.Text += Environment.NewLine() + "INI_UID=""sa"""
        txtTmp.Text += Environment.NewLine() + "INI_PWD=""1"""

        tw.WriteLine(txtTmp.Text)
        tw.Flush()
        tw.Close()
        txtTmp.Text = ""
    End Sub

    Public Sub New()
        Dim txtTmp As TextBox = CreateINI()
        _DTCREATED = CDate(txtTmp.Lines(1))
        _DTMODIFIED = CDate(txtTmp.Lines(3))
        _INI_COMMPORTS = getStp(txtTmp, "INI_COMMPORTS")
        _INI_BAUDRATE = getStp(txtTmp, "INI_BAUDRATE")
    
    End Sub

    Private Function getStp(txtTmp As TextBox, paramN As String) As String
        Dim str As String = ""
        Dim paramV As String = ""
        Dim aa = From ss As String In txtTmp.Lines Where ss.StartsWith(paramN) From tt As String In ss.Split("=") Select tt
        paramV = Mid(aa(1), 2, aa(1).Count - 2)
        Return paramV
    End Function

    Private _DTCREATED As DateTime
    Public ReadOnly Property DTCREATED() As DateTime
        Get
            Return _DTCREATED
        End Get
    End Property

    Private _DTMODIFIED As DateTime
    Public Property DTMODIFIED() As DateTime
        Get
            Return _DTMODIFIED
        End Get
        Set(ByVal value As DateTime)
            _DTMODIFIED = value
        End Set
    End Property


    Private _INI_COMMPORTS As String
    Public Property INI_COMMPORTS() As String
        Get
            Return _INI_COMMPORTS
        End Get
        Set(ByVal value As String)
            _INI_COMMPORTS = value
        End Set
    End Property

    Private _INI_BAUDRATE As String
    Public Property INI_BAUDRATE() As String
        Get
            Return _INI_BAUDRATE
        End Get
        Set(ByVal value As String)
            _INI_BAUDRATE = value
        End Set
    End Property

    Private _INI_PARITY As String
    Public Property INI_PARITY() As String
        Get
            Return _INI_PARITY
        End Get
        Set(ByVal value As String)
            _INI_PARITY = value
        End Set
    End Property

    Private _INI_DATABITS As String
    Public Property INI_DATABITS() As String
        Get
            Return _INI_DATABITS
        End Get
        Set(ByVal value As String)
            _INI_DATABITS = value
        End Set
    End Property

    Private _INI_STOPBITS As String
    Public Property INI_STOPBITS As String
        Get
            Return _INI_STOPBITS
        End Get
        Set(ByVal value As String)
            _INI_STOPBITS = value
        End Set
    End Property

    Public Property _INI_CAM_1_OIP As String
    Public Property INI_CAM_1_OIP As String
        Get
            Return _INI_CAM_1_OIP
        End Get
        Set(ByVal value As String)
            _INI_CAM_1_OIP = value
        End Set
    End Property

    Public Property _INI_CAM_2_OIP As String
    Public Property INI_CAM_2_OIP As String
        Get
            Return _INI_CAM_2_OIP
        End Get
        Set(ByVal value As String)
            _INI_CAM_2_OIP = value
        End Set
    End Property

    Public Property _CAM_TIME_OUT As String
    Public Property CAM_TIME_OUT As String
        Get
            Return _CAM_TIME_OUT
        End Get
        Set(ByVal value As String)
            _CAM_TIME_OUT = value
        End Set
    End Property

End Class

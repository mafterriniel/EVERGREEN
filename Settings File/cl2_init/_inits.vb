Imports System.Windows.Forms
Imports cl2_g3n_

'Module _inits
'    Sub TestEncoding()
'        Dim plainText As String = InputBox("Enter the plain text:")
'        Dim password As String = InputBox("Enter the password:")

'        Dim wrapper As New _crpt0MD5(password)
'        Dim cipherText As String = wrapper.EncryptData(plainText)

'        MsgBox("The cipher text is: " & cipherText)
'        My.Computer.FileSystem.WriteAllText(
'            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
'            "\cipherText.txt", cipherText, False)
'    End Sub

'    Sub TestDecoding()
'        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
'            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
'                "\cipherText.txt")
'        Dim password As String = InputBox("Enter the password:")
'        Dim wrapper As New _crpt0MD5(password)

'        ' DecryptData throws if the wrong password is used.
'        Try
'            Dim plainText As String = wrapper.DecryptData(cipherText)
'            MsgBox("The plain text is: " & plainText)
'        Catch ex As System.Security.Cryptography.CryptographicException
'            MsgBox("The data could not be decrypted with the password.")
'        End Try
'    End Sub

'    '    Sub Main()

'    '        Dim stp As New stp

'    '        System.Console.WriteLine(stp.INI_COMMPORTS)
'    '        System.Console.WriteLine(stp.INI_BAUDRATE)
'    '        System.Console.WriteLine(stp.INI_PARITY)
'    '        System.Console.WriteLine(stp.INI_DATABITS)
'    '        System.Console.WriteLine(stp.INI_STOPBITS)

'    '        System.Console.WriteLine(stp.INI_ACSPATH)
'    '        System.Console.WriteLine(stp.INI_ACSPWD)

'    '        System.Console.WriteLine(stp.INI_SERVERNAME)
'    '        System.Console.WriteLine(stp.INI_CATALOG)
'    '        System.Console.WriteLine(stp.INI_SQLUID)
'    '        System.Console.WriteLine(stp.INI_SQLPWD)

'    '        System.Console.WriteLine(stp.INI_PRINT_ALL)
'    '        System.Console.WriteLine(stp.INI_PRINT_SEPARATE)
'    '        System.Console.WriteLine(stp.UNIT_WEIGHT)
'    '        System.Console.WriteLine(stp.SHOW_PRICING)
'    '        System.Console.ReadKey()

'    '        stp._iniS()
'    '    End Sub

'    Sub main()
'        TestEncoding()
'        TestDecoding()
'    End Sub
'End Module

Public Class stp
    Private _SYSFLE As String = Application.StartupPath + "\sys.file"
    Dim wrapper As New _crpt0MD5("JOJO")

    Private _acspp As String
    Public Property acspp() As String
        Get
            Return _acspp
        End Get
        Set(ByVal value As String)
            _acspp = value
        End Set
    End Property

    Public Sub New()

        Dim txtTmp As TextBox = _iniC()

        _DTCREATED = CDate(txtTmp.Lines(1))
        _DTMODIFIED = CDate(txtTmp.Lines(3))
        _INI_COMMPORTS = (_gtStp(txtTmp, "INI_COMMPORTS"))
        _INI_BAUDRATE = (_gtStp(txtTmp, "INI_BAUDRATE"))
        _INI_PARITY = (_gtStp(txtTmp, "INI_PARITY"))
        _INI_DATABITS = (_gtStp(txtTmp, "INI_DATABITS"))
        _INI_STOPBITS = (_gtStp(txtTmp, "INI_STOPBITS"))

        _INI_ACSPATH = (_gtStp(txtTmp, "INI_ACSPATH"))
        _INI_ACSPWD = (_gtStp(txtTmp, "INI_ACSPWD"))

        _INI_SERVERNAME = (_gtStp(txtTmp, "INI_SERVERNAME"))
        _INI_CATALOG = (_gtStp(txtTmp, "INI_CATALOG"))
        _INI_SQLUID = (_gtStp(txtTmp, "INI_SQLUID"))
        _INI_SQLPWD = (_gtStp(txtTmp, "INI_SQLPWD"))

        _INI_PRINT_ALL = (_gtStp(txtTmp, "INI_PRINT_ALL"))
        _INI_PRINT_SEPARATE = (_gtStp(txtTmp, "INI_PRINT_SEPARATE"))
        _UNIT_WEIGHT = (_gtStp(txtTmp, "UNIT_WEIGHT"))
        _SHOW_PRICING = (_gtStp(txtTmp, "SHOW_PRICING"))
        _DEV = (_gtStp(txtTmp, "DEV"))

        'CDC
        _DOLLAR_CNV = (_gtStp(txtTmp, "DOLLAR_CNV"))
        'EOF CDC'

        'UPPC'
        _StationCode = (_gtStp(txtTmp, "STATION_CODE"))
        _StationName = (_gtStp(txtTmp, "STATION_NAME"))
        _PurchasesInitials = (_gtStp(txtTmp, "PURCHASE_INITIAL"))
        _SalesInitials = (_gtStp(txtTmp, "SALES_INITIAL"))
        _ENTLimit = (_gtStp(txtTmp, "ENT_LIMIT"))
        _MinimumTolerance = (_gtStp(txtTmp, "MIN_TOL"))
        _MaximumTolerance = (_gtStp(txtTmp, "MAX_TOL"))
        _MCDTDiff = (_gtStp(txtTmp, "MCDT_DIFF"))
        _MCInput = (_gtStp(txtTmp, "MC_INPUT"))
        _SavingDelayPeriod = (_gtStp(txtTmp, "SAVING_DELAY_PERIOD"))
        _WeightStability = (_gtStp(txtTmp, "WEIGHT_STABILITY"))
        _SlipTkt = (_gtStp(txtTmp, "SLIP_TKT"))
        _TruckDelivery = (_gtStp(txtTmp, "TRUCK_DELIVERY"))
        _TruckDeliveryLockPeriod = (_gtStp(txtTmp, "TRUCK_DELIVERY_LOCK"))
        _WeightComparison = (_gtStp(txtTmp, "WEIGHT_COMPARISON"))
        _WeightLockPeriod = (_gtStp(txtTmp, "WEIGHT_LOCK_PERIOD"))
        _client_id = (_gtStp(txtTmp, "CLIENT_ID"))
        _client_secret = (_gtStp(txtTmp, "CLIENT_SECRET"))
        _folder_name = (_gtStp(txtTmp, "FOLDER_NAME"))

        'ACCESS
        _OnL = (_gtStp(txtTmp, "ONL"))
        _OfL = (_gtStp(txtTmp, "OFL"))
        _InY = (_gtStp(txtTmp, "INY"))
        _Mods = (_gtStp(txtTmp, "MODS"))

        _EY = (_gtStp(txtTmp, "EY"))
        _DY = (_gtStp(txtTmp, "DY"))

        _ET = (_gtStp(txtTmp, "ET"))
        _DT = (_gtStp(txtTmp, "DT"))
        _RT = (_gtStp(txtTmp, "RT"))

        _Cust = (_gtStp(txtTmp, "CUST"))
        _Sup = (_gtStp(txtTmp, "SUP"))
        _Haul = (_gtStp(txtTmp, "HAUL"))
        _Rmats = (_gtStp(txtTmp, "RMATS"))
        _Prod = (_gtStp(txtTmp, "PROD"))
        _Ble = (_gtStp(txtTmp, "BLE"))
        _Trk = (_gtStp(txtTmp, "TRK"))
        _TrkC = (_gtStp(txtTmp, "TRKC"))

        _Insp = (_gtStp(txtTmp, "INSP"))
        _Rec = (_gtStp(txtTmp, "RECNO"))
        _MS = (_gtStp(txtTmp, "MS"))
        _Sign = (_gtStp(txtTmp, "SIGN"))
        _Acs = (_gtStp(txtTmp, "ACS"))

        _SS = (_gtStp(txtTmp, "SS"))
        _DV = (_gtStp(txtTmp, "DV"))
        _LV = (_gtStp(txtTmp, "LV"))
        'ACCESS

        'SENSOR
        _SNSR_ENABLED = (_gtStp(txtTmp, "SNSR_ENABLED"))
        _SNSR_TCP = (_gtStp(txtTmp, "SNSR_TCP"))
        _SNSR_TCPPort = (_gtStp(txtTmp, "SNSR_TCPPORT"))

        _SNSR_DeviceId = (_gtStp(txtTmp, "SNSR_DEVICEID"))
        _SNSR_IPaddress = (_gtStp(txtTmp, "SNSR_IP"))
        _SNSR_BitsPerSecond = (_gtStp(txtTmp, "SNSR_BPS"))
        _SNSR_Protocol = (_gtStp(txtTmp, "SNSR_PROTOCOL"))
        _SNSR_TimeOut = (_gtStp(txtTmp, "SNSR_TIMOUT"))
        _SNSR_PortName = (_gtStp(txtTmp, "SNSR_PORTNAME"))
        _SNSR_Password = (_gtStp(txtTmp, "SNSR_PWD"))

        'CMAERA
        _IP1 = (_gtStp(txtTmp, "IP1"))
        _UID1 = (_gtStp(txtTmp, "UID1"))
        _PWD1 = (_gtStp(txtTmp, "PWD1"))
        _BN1 = (_gtStp(txtTmp, "BN1"))
        _NETMASK1 = (_gtStp(txtTmp, "NETMASK1"))
        _GATEWAY1 = (_gtStp(txtTmp, "GATEWAY1"))
        _WEB_PORT1 = (_gtStp(txtTmp, "WEBPORT1"))
        _DEV_PORT1 = (_gtStp(txtTmp, "DEVPORT1"))
        _RSTP_PORT1 = (_gtStp(txtTmp, "RSTPPORT1"))

        _IP2 = (_gtStp(txtTmp, "IP2"))
        _UID2 = (_gtStp(txtTmp, "UID2"))
        _PWD2 = (_gtStp(txtTmp, "PWD2"))
        _BN2 = (_gtStp(txtTmp, "BN2"))
        _NETMASK2 = (_gtStp(txtTmp, "NETMASK2"))
        _GATEWAY2 = (_gtStp(txtTmp, "GATEWAY2"))
        _WEB_PORT2 = (_gtStp(txtTmp, "WEBPORT2"))
        _DEV_PORT2 = (_gtStp(txtTmp, "DEVPORT2"))
        _RSTP_PORT2 = (_gtStp(txtTmp, "RSTPPORT2"))

        _EnablePCapture = (_gtStp(txtTmp, "ENABLE_PCAPTURE"))
        _EnableSCapture = (_gtStp(txtTmp, "ENABLE_SCAPTURE"))
        _TimeOut = (_gtStp(txtTmp, "TIME_OUT"))
        'EOF UPPC'

        'BOF 8 DRAGON'
        _W_FEE = (_gtStp(txtTmp, "W_FEE"))
        'EOF 8 DRAGON'

        'EVERGREEN'
        _CAM_TIME_OUT = (_gtStp(txtTmp, "CAM_TIME_OUT"))
        _CAM_1_IP = (_gtStp(txtTmp, "CAM_1_IP"))
        _CAM_2_IP = (_gtStp(txtTmp, "CAM_2_IP"))
        'EOF EVERGEEN'
    End Sub

    Private Function _iniC() As TextBox
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
            txtTmp.Text += Environment.NewLine() + "INI_COMMPORTS:=" & ("COM1")
            txtTmp.Text += Environment.NewLine() + "INI_BAUDRATE:=" & ("9600")
            txtTmp.Text += Environment.NewLine() + "INI_PARITY:=" & ("NONE")
            txtTmp.Text += Environment.NewLine() + "INI_DATABITS:=" & ("8")
            txtTmp.Text += Environment.NewLine() + "INI_STOPBITS:=" & ("1")
            txtTmp.Text += Environment.NewLine() + "INI_CONN_TYPE:=" & ("OLEDB")

            txtTmp.Text += Environment.NewLine() + "[AccessDB]"
            txtTmp.Text += Environment.NewLine() + "INI_ACSPATH:=" & ("C:\Weighing System v1.1")
            txtTmp.Text += Environment.NewLine() + "INI_ACSPWD:=" & ("database")

            txtTmp.Text += Environment.NewLine() + "[SQLDB]"
            txtTmp.Text += Environment.NewLine() + "INI_SERVERNAME:=" & (My.Computer.Name & "\SQLEXPRESS")
            txtTmp.Text += Environment.NewLine() + "INI_CATALOG:=" & ("SYSDB")
            txtTmp.Text += Environment.NewLine() + "INI_SQLUID:=" & ("sa")
            txtTmp.Text += Environment.NewLine() + "INI_SQLPWD:=" & ("1")

            txtTmp.Text += Environment.NewLine() + "[GENERAL]"
            txtTmp.Text += Environment.NewLine() + "INI_PRINT_ALL:=" & "TRUE"
            txtTmp.Text += Environment.NewLine() + "INI_PRINT_SEPARATE:=" & "FALSE"
            txtTmp.Text += Environment.NewLine() + "UNIT_WEIGHT:=" & "KG"
            txtTmp.Text += Environment.NewLine() + "SHOW_PRICING:=" & "FALSE"
            txtTmp.Text += Environment.NewLine() + "DEV:=" & "GSE460"
            txtTmp.Text += Environment.NewLine() + "DOLLAR_CNV:=" & "45.00"

            'UPPC'
            txtTmp.Text += Environment.NewLine() + "STATION_CODE:=" & "STN1"
            txtTmp.Text += Environment.NewLine() + "STATION_NAME:=" & "STATION 1"
            txtTmp.Text += Environment.NewLine() + "PURCHASE_INITIAL:=" & "R1"
            txtTmp.Text += Environment.NewLine() + "SALES_INITIAL:=" & "D1"

            txtTmp.Text += Environment.NewLine() + "ENT_LIMIT:=" & "u"
            txtTmp.Text += Environment.NewLine() + "MIN_TOL:=" & "-30"
            txtTmp.Text += Environment.NewLine() + "MAX_TOL:=" & "+30"
            txtTmp.Text += Environment.NewLine() + "MCDT_DIFF:=" & "TRUE"
            txtTmp.Text += Environment.NewLine() + "MC_INPUT:=" & "MCInput"
            txtTmp.Text += Environment.NewLine() + "REPORT_PATH:=" & ""
            txtTmp.Text += Environment.NewLine() + "SAVING_DELAY_PERIOD:=" & "3"
            txtTmp.Text += Environment.NewLine() + "WEIGHT_STABILITY:=" & "True"
            txtTmp.Text += Environment.NewLine() + "SLIP_TKT:=" & "Old"
            txtTmp.Text += Environment.NewLine() + "TRUCK_DELIVERY:=" & "True"
            txtTmp.Text += Environment.NewLine() + "TRUCK_DELIVERY_LOCK:=" & "30"
            txtTmp.Text += Environment.NewLine() + "WEIGHT_COMPARISON:=" & "True"
            txtTmp.Text += Environment.NewLine() + "WEIGHT_LOCK_PERIOD:=" & "30"
            txtTmp.Text += Environment.NewLine() + "CLIENT_ID:=" & "799044794099-16eenmg8k69a0eodt7jdjum5iffirm97.apps.googleusercontent.com"
            txtTmp.Text += Environment.NewLine() + "CLIENT_SECRET:=" & "30_SNtB5AJugwN66xEYjOIBn"
            txtTmp.Text += Environment.NewLine() + "FOLDER_NAME:=" & "BALINTAWAK"

            txtTmp.Text += Environment.NewLine() + "SNSR_ENABLED:=" & "False"
            txtTmp.Text += Environment.NewLine() + "SNSR_TCP:=" & ""
            txtTmp.Text += Environment.NewLine() + "SNSR_TCPPORT:=" & "4370"
            txtTmp.Text += Environment.NewLine() + "SNSR_DEVICEID:=" & "1"
            txtTmp.Text += Environment.NewLine() + "SNSR_IP:=" & ""
            txtTmp.Text += Environment.NewLine() + "SNSR_BPS:=" & "38400"
            txtTmp.Text += Environment.NewLine() + "SNSR_PROTOCOL:=" & ""
            txtTmp.Text += Environment.NewLine() + "SNSR_TIMOUT:=" & "2000"
            txtTmp.Text += Environment.NewLine() + "SNSR_PORTNAME:=" & "COM3"
            txtTmp.Text += Environment.NewLine() + "SNSR_PWD:=" & ""

            txtTmp.Text += Environment.NewLine() + "ENABLE_PCAPTURE:=" & "True"
            txtTmp.Text += Environment.NewLine() + "ENABLE_SCAPTURE:=" & "False"
            txtTmp.Text += Environment.NewLine() + "TIME_OUT:=" & "2000"

            txtTmp.Text += Environment.NewLine() + "IP1:=" & ""
            txtTmp.Text += Environment.NewLine() + "UID1:=" & ""
            txtTmp.Text += Environment.NewLine() + "PWD1:=" & ""
            txtTmp.Text += Environment.NewLine() + "BN1:=" & ""
            txtTmp.Text += Environment.NewLine() + "NETMASK1:=" & ""
            txtTmp.Text += Environment.NewLine() + "GATEWAY1:=" & ""
            txtTmp.Text += Environment.NewLine() + "WEBPORT1:=" & ""
            txtTmp.Text += Environment.NewLine() + "DEVPORT1:=" & ""
            txtTmp.Text += Environment.NewLine() + "RSTPPORT1:=" & ""

            txtTmp.Text += Environment.NewLine() + "IP2:=" & ""
            txtTmp.Text += Environment.NewLine() + "UID2:=" & ""
            txtTmp.Text += Environment.NewLine() + "PWD2:=" & ""
            txtTmp.Text += Environment.NewLine() + "BN2:=" & ""
            txtTmp.Text += Environment.NewLine() + "NETMASK2:=" & ""
            txtTmp.Text += Environment.NewLine() + "GATEWAY2:=" & ""
            txtTmp.Text += Environment.NewLine() + "WEBPORT2:=" & ""
            txtTmp.Text += Environment.NewLine() + "DEVPORT2:=" & ""
            txtTmp.Text += Environment.NewLine() + "RSTPPORT2:=" & ""

            'ACCESS'
            txtTmp.Text += Environment.NewLine() + "ONL:=" & "True"
            txtTmp.Text += Environment.NewLine() + "OFL:=" & "True"
            txtTmp.Text += Environment.NewLine() + "INY:=" & "True"
            txtTmp.Text += Environment.NewLine() + "MODS:=" & "True"

            txtTmp.Text += Environment.NewLine() + "EY:=" & "False"
            txtTmp.Text += Environment.NewLine() + "DY:=" & "False"

            txtTmp.Text += Environment.NewLine() + "ET:=" & "True"
            txtTmp.Text += Environment.NewLine() + "DT:=" & "True"
            txtTmp.Text += Environment.NewLine() + "RT:=" & "True"

            txtTmp.Text += Environment.NewLine() + "CUST:=" & "false"
            txtTmp.Text += Environment.NewLine() + "SUP:=" & "false"
            txtTmp.Text += Environment.NewLine() + "HAUL:=" & "false"
            txtTmp.Text += Environment.NewLine() + "RMATS:=" & "false"
            txtTmp.Text += Environment.NewLine() + "PROD:=" & "false"
            txtTmp.Text += Environment.NewLine() + "BLE:=" & "false"
            txtTmp.Text += Environment.NewLine() + "TRK:=" & "false"
            txtTmp.Text += Environment.NewLine() + "TRKC:=" & "false"

            txtTmp.Text += Environment.NewLine() + "INSP:=" & "false"
            txtTmp.Text += Environment.NewLine() + "RECNO:=" & "false"
            txtTmp.Text += Environment.NewLine() + "MS:=" & "false"
            txtTmp.Text += Environment.NewLine() + "SIGN:=" & "false"
            txtTmp.Text += Environment.NewLine() + "ACS:=" & "True"

            txtTmp.Text += Environment.NewLine() + "SS:=" & "True"
            txtTmp.Text += Environment.NewLine() + "DV:=" & "True"
            txtTmp.Text += Environment.NewLine() + "LV:=" & "True"

            txtTmp.Text += Environment.NewLine() + "W_FEE:=" & "0.00"
            'END OF ACCESS

            'EVERGREEN'
            txtTmp.Text += Environment.NewLine() + "CAM_TIME_OUT:=" & "3000"
            txtTmp.Text += Environment.NewLine() + "CAM_1_IP:=" & "192.168.1.1"
            txtTmp.Text += Environment.NewLine() + "CAM_2_IP:=" & "192.168.1.1"
            'EOF EVERGREEN'
            tw.WriteLine(wrapper.EncryptData(txtTmp.Text))
            tw.Flush()
            tw.Close()
            txtTmp.Text = ""

            Dim rd As System.IO.TextReader = Nothing
            rd = System.IO.File.OpenText(sysFle)
            While rd.Peek >= 0
                txtTmp.Text = rd.ReadToEnd
            End While
            rd.Close()
        Else
            Dim rd As System.IO.TextReader = Nothing
            rd = System.IO.File.OpenText(sysFle)
            While rd.Peek >= 0
                txtTmp.Text = rd.ReadToEnd
            End While
            rd.Close()
        End If
        txtTmp.Text = wrapper.DecryptData(txtTmp.Text)
        Return txtTmp
    End Function

    Public Sub _iniS()
        If _acspp.Equals("mijochanel122208") = False Then Exit Sub
        Dim txtTmp As New TextBox
        Dim tw As System.IO.TextWriter = Nothing
        tw = System.IO.File.CreateText(_SYSFLE)

        _DTMODIFIED = Now
        txtTmp.Text = "[DateCreated]"
        txtTmp.Text += Environment.NewLine() + Format(_DTCREATED, "yyyy-MM-dd hh:mm:ss")
        txtTmp.Text += Environment.NewLine() + "[DateModified]"
        txtTmp.Text += Environment.NewLine() + Format(_DTMODIFIED, "yyyy-MM-dd hh:mm:ss")
        txtTmp.Text += Environment.NewLine() + "[SerialPort]"
        txtTmp.Text += Environment.NewLine() + "INI_COMMPORTS:=" & (_INI_COMMPORTS)
        txtTmp.Text += Environment.NewLine() + "INI_BAUDRATE:=" & (_INI_BAUDRATE)
        txtTmp.Text += Environment.NewLine() + "INI_PARITY:=" & (_INI_PARITY)
        txtTmp.Text += Environment.NewLine() + "INI_DATABITS:=" & (_INI_DATABITS)
        txtTmp.Text += Environment.NewLine() + "INI_STOPBITS:=" & (_INI_STOPBITS)
        txtTmp.Text += Environment.NewLine() + "INI_CONN_TYPE:=" & (_INI_CONN_TYPE)

        txtTmp.Text += Environment.NewLine() + "[AccessDB]"
        txtTmp.Text += Environment.NewLine() + "INI_ACSPATH:=" & (_INI_ACSPATH)
        txtTmp.Text += Environment.NewLine() + "INI_ACSPWD:=" & (_INI_ACSPWD)

        txtTmp.Text += Environment.NewLine() + "[SQLDB]"
        txtTmp.Text += Environment.NewLine() + "INI_SERVERNAME:=" & (_INI_SERVERNAME)
        txtTmp.Text += Environment.NewLine() + "INI_CATALOG:=" & (_INI_CATALOG)
        txtTmp.Text += Environment.NewLine() + "INI_SQLUID:=" & (_INI_SQLUID)
        txtTmp.Text += Environment.NewLine() + "INI_SQLPWD:=" & (_INI_SQLPWD)

        txtTmp.Text += Environment.NewLine() + "[GENERAL]"
        txtTmp.Text += Environment.NewLine() + "INI_PRINT_ALL:=" & (_INI_PRINT_ALL)
        txtTmp.Text += Environment.NewLine() + "INI_PRINT_SEPARATE:=" & (_INI_PRINT_SEPARATE)
        txtTmp.Text += Environment.NewLine() + "UNIT_WEIGHT:=" & (_UNIT_WEIGHT)
        txtTmp.Text += Environment.NewLine() + "SHOW_PRICING:=" & (_SHOW_PRICING)
        txtTmp.Text += Environment.NewLine() + "DEV:=" & (_DEV)
        txtTmp.Text += Environment.NewLine() + "DOLLAR_CNV:=" & (_DOLLAR_CNV)
        'uppc
        txtTmp.Text += Environment.NewLine() + "STATION_CODE:=" & (_StationCode)
        txtTmp.Text += Environment.NewLine() + "STATION_NAME:=" & (_StationName)
        txtTmp.Text += Environment.NewLine() + "PURCHASE_INITIAL:=" & (_PurchasesInitials)
        txtTmp.Text += Environment.NewLine() + "SALES_INITIAL:=" & (_SalesInitials)
        txtTmp.Text += Environment.NewLine() + "ENT_LIMIT:=" & _ENTLimit
        txtTmp.Text += Environment.NewLine() + "MIN_TOL:=" & _MinimumTolerance
        txtTmp.Text += Environment.NewLine() + "MAX_TOL:=" & _MaximumTolerance
        txtTmp.Text += Environment.NewLine() + "MCDT_DIFF:=" & _MCDTDiff
        txtTmp.Text += Environment.NewLine() + "MC_INPUT:=" & _MCInput
        txtTmp.Text += Environment.NewLine() + "REPORT_PATH:=" & ""
        txtTmp.Text += Environment.NewLine() + "SAVING_DELAY_PERIOD:=" & _SavingDelayPeriod
        txtTmp.Text += Environment.NewLine() + "WEIGHT_STABILITY:=" & _WeightStability
        txtTmp.Text += Environment.NewLine() + "SLIP_TKT:=" & _SlipTkt
        txtTmp.Text += Environment.NewLine() + "TRUCK_DELIVERY:=" & _TruckDelivery
        txtTmp.Text += Environment.NewLine() + "TRUCK_DELIVERY_LOCK:=" & _TruckDeliveryLockPeriod
        txtTmp.Text += Environment.NewLine() + "WEIGHT_COMPARISON:=" & _WeightComparison
        txtTmp.Text += Environment.NewLine() + "WEIGHT_LOCK_PERIOD:=" & _WeightLockPeriod
        'SENSOR
        txtTmp.Text += Environment.NewLine() + "SNSR_ENABLEd:=" & _SNSR_ENABLED
        txtTmp.Text += Environment.NewLine() + "SNSR_TCP:=" & _SNSR_TCP
        txtTmp.Text += Environment.NewLine() + "SNSR_TCPPORT:=" & _SNSR_TCPPort
        txtTmp.Text += Environment.NewLine() + "SNSR_DEVICEID:=" & _SNSR_DeviceId
        txtTmp.Text += Environment.NewLine() + "SNSR_IP:=" & _SNSR_IPaddress
        txtTmp.Text += Environment.NewLine() + "SNSR_BPS:=" & _SNSR_BitsPerSecond
        txtTmp.Text += Environment.NewLine() + "SNSR_PROTOCOL:=" & _SNSR_Protocol
        txtTmp.Text += Environment.NewLine() + "SNSR_TIMOUT:=" & _SNSR_TimeOut
        txtTmp.Text += Environment.NewLine() + "SNSR_PORTNAME:=" & _SNSR_PortName
        txtTmp.Text += Environment.NewLine() + "SNSR_PWD:=" & _SNSR_Password

        'GDRIVE
        txtTmp.Text += Environment.NewLine() + "CLIENT_ID:=" & _client_id
        txtTmp.Text += Environment.NewLine() + "CLIENT_SECRET:=" & _client_secret
        txtTmp.Text += Environment.NewLine() + "FOLDER_NAME:=" & _folder_name

        'CAMERA
        txtTmp.Text += Environment.NewLine() + "ENABLE_PCAPTURE:=" & _EnablePCapture
        txtTmp.Text += Environment.NewLine() + "ENABLE_SCAPTURE:=" & _EnableSCapture
        txtTmp.Text += Environment.NewLine() + "TIME_OUT:=" & _TimeOut

        txtTmp.Text += Environment.NewLine() + "IP1:=" & _IP1
        txtTmp.Text += Environment.NewLine() + "UID1:=" & _UID1
        txtTmp.Text += Environment.NewLine() + "PWD1:=" & _PWD1
        txtTmp.Text += Environment.NewLine() + "BN1:=" & _BN1
        txtTmp.Text += Environment.NewLine() + "NETMASK1:=" & _NETMASK1
        txtTmp.Text += Environment.NewLine() + "GATEWAY1:=" & _GATEWAY1
        txtTmp.Text += Environment.NewLine() + "WEBPORT1:=" & _WEB_PORT1
        txtTmp.Text += Environment.NewLine() + "DEVPORT1:=" & _DEV_PORT1
        txtTmp.Text += Environment.NewLine() + "RSTPPORT1:=" & _RSTP_PORT1

        txtTmp.Text += Environment.NewLine() + "IP2:=" & _IP2
        txtTmp.Text += Environment.NewLine() + "UID2:=" & _UID2
        txtTmp.Text += Environment.NewLine() + "PWD2:=" & _PWD2
        txtTmp.Text += Environment.NewLine() + "BN2:=" & _BN2
        txtTmp.Text += Environment.NewLine() + "NETMASK2:=" & _NETMASK2
        txtTmp.Text += Environment.NewLine() + "GATEWAY2:=" & _GATEWAY2
        txtTmp.Text += Environment.NewLine() + "WEBPORT2:=" & _WEB_PORT2
        txtTmp.Text += Environment.NewLine() + "DEVPORT2:=" & _DEV_PORT2
        txtTmp.Text += Environment.NewLine() + "RSTPPORT2:=" & _RSTP_PORT2

        'ACCESS'
        txtTmp.Text += Environment.NewLine() + "ONL:=" & _OnL
        txtTmp.Text += Environment.NewLine() + "OFL:=" & _OfL
        txtTmp.Text += Environment.NewLine() + "INY:=" & _InY
        txtTmp.Text += Environment.NewLine() + "MODS:=" & _Mods

        txtTmp.Text += Environment.NewLine() + "EY:=" & _EY
        txtTmp.Text += Environment.NewLine() + "DY:=" & _DY

        txtTmp.Text += Environment.NewLine() + "ET:=" & _ET
        txtTmp.Text += Environment.NewLine() + "DT:=" & _DT
        txtTmp.Text += Environment.NewLine() + "RT:=" & _RT

        txtTmp.Text += Environment.NewLine() + "CUST:=" & _Cust
        txtTmp.Text += Environment.NewLine() + "SUP:=" & _Sup
        txtTmp.Text += Environment.NewLine() + "HAUL:=" & _Haul
        txtTmp.Text += Environment.NewLine() + "RMATS:=" & _Rmats
        txtTmp.Text += Environment.NewLine() + "PROD:=" & _Prod
        txtTmp.Text += Environment.NewLine() + "BLE:=" & "false"
        txtTmp.Text += Environment.NewLine() + "TRK:=" & _Trk
        txtTmp.Text += Environment.NewLine() + "TRKC:=" & _TrkC

        txtTmp.Text += Environment.NewLine() + "INSP:=" & _Insp
        txtTmp.Text += Environment.NewLine() + "RECNO:=" & _Rec
        txtTmp.Text += Environment.NewLine() + "MS:=" & _MS
        txtTmp.Text += Environment.NewLine() + "SIGN:=" & _Sign
        txtTmp.Text += Environment.NewLine() + "ACS:=" & Acs

        txtTmp.Text += Environment.NewLine() + "SS:=" & _SS
        txtTmp.Text += Environment.NewLine() + "DV:=" & _DV
        txtTmp.Text += Environment.NewLine() + "LV:=" & _LV
        'END OF ACCESS

        'EOF UPPC'

        'BOF 8 DRAGON'
        txtTmp.Text += Environment.NewLine() + "W_FEE:=" & _W_FEE

        'EVERGREEN'
        txtTmp.Text += Environment.NewLine() + "CAM_TIME_OUT:=" & _CAM_TIME_OUT
        txtTmp.Text += Environment.NewLine() + "CAM_1_IP:=" & _CAM_1_IP
        txtTmp.Text += Environment.NewLine() + "CAM_2_IP:=" & _CAM_2_IP
        'EOF EVERGREEN'

        tw.WriteLine(wrapper.EncryptData(txtTmp.Text))
        tw.Flush()
        tw.Close()
        txtTmp.Text = ""
    End Sub

    Private Function _gtStp(ByVal txtTmp As TextBox, ByVal paramN As String) As String

        Dim str As String = ""
        Dim paramV As String = ""
        Dim aa = From ss As String In txtTmp.Lines Where ss.StartsWith(paramN) From tt As String In ss.Split(":=", 2, StringSplitOptions.RemoveEmptyEntries) Select tt
        'paramV = Mid(aa(1), 2, aa(1).Count - 1)
        paramV = aa(1)
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
    Public Property INI_STOPBITS() As String
        Get
            Return _INI_STOPBITS
        End Get
        Set(ByVal value As String)
            _INI_STOPBITS = value
        End Set
    End Property


    Private _INI_CONN_TYPE As String
    Public Property INI_CONN_TYPE() As String
        Get
            Return _INI_CONN_TYPE
        End Get
        Set(ByVal value As String)
            _INI_CONN_TYPE = value
        End Set
    End Property

    Private _INI_ACSPATH As String
    Public Property INI_ACSPATH() As String
        Get
            Return _INI_ACSPATH
        End Get
        Set(ByVal value As String)
            _INI_ACSPATH = value
        End Set
    End Property

    Private _INI_ACSPWD As String
    Public Property INI_ACSPWD() As String
        Get
            Return _INI_ACSPWD
        End Get
        Set(ByVal value As String)
            _INI_ACSPWD = value
        End Set
    End Property

    Private _INI_SERVERNAME As String
    Public Property INI_SERVERNAME() As String
        Get
            Return _INI_SERVERNAME
        End Get
        Set(ByVal value As String)
            _INI_SERVERNAME = value
        End Set
    End Property

    Private _INI_CATALOG As String
    Public Property INI_CATALOG() As String
        Get
            Return _INI_CATALOG
        End Get
        Set(ByVal value As String)
            _INI_CATALOG = value
        End Set
    End Property

    Private _INI_SQLUID As String
    Public Property INI_SQLUID() As String
        Get
            Return _INI_SQLUID
        End Get
        Set(ByVal value As String)
            _INI_SQLUID = value
        End Set
    End Property

    Private _INI_SQLPWD As String
    Public Property INI_SQLPWD() As String
        Get
            Return _INI_SQLPWD
        End Get
        Set(ByVal value As String)
            _INI_SQLPWD = value
        End Set
    End Property

    Private _INI_PRINT_ALL As Boolean
    Public Property INI_PRINT_ALL() As Boolean
        Get
            Return _INI_PRINT_ALL
        End Get
        Set(ByVal value As Boolean)
            _INI_PRINT_ALL = value
        End Set
    End Property

    Private _INI_PRINT_SEPARATE As Boolean
    Public Property INI_PRINT_SEPARATE() As Boolean
        Get
            Return _INI_PRINT_SEPARATE
        End Get
        Set(ByVal value As Boolean)
            _INI_PRINT_SEPARATE = value
        End Set
    End Property

    Private _UNIT_WEIGHT As String
    Public Property UNIT_WEIGHT() As String
        Get
            Return _UNIT_WEIGHT
        End Get
        Set(ByVal value As String)
            _UNIT_WEIGHT = value
        End Set
    End Property

    Private _SHOW_PRICING As Boolean
    Public Property SHOW_PRICING() As Boolean
        Get
            Return _SHOW_PRICING
        End Get
        Set(ByVal value As Boolean)
            _SHOW_PRICING = value
        End Set
    End Property

    Private _DEV As String
    Public Property INI_DEV() As String
        Get
            Return _DEV
        End Get
        Set(ByVal value As String)
            _DEV = value
        End Set
    End Property
#Region "CDC"

    'CDC'
    Private _DOLLAR_CNV As String
    Public Property DOLLAR_CNV() As String
        Get
            Return _DOLLAR_CNV
        End Get
        Set(ByVal value As String)
            _DOLLAR_CNV = value
        End Set
    End Property

#End Region

#Region "UPPC"
#Region "general Settings"
    Private _StationName As String
    Public Property StationName() As String
        Get
            Return _StationName
        End Get
        Set(ByVal value As String)
            _StationName = value
        End Set
    End Property

    Private _StationCode As String
    Public Property StationCode() As String
        Get
            Return _StationCode
        End Get
        Set(ByVal value As String)
            _StationCode = value
        End Set
    End Property

    Private _PurchasesInitials As String
    Public Property PurchasesInitials() As String
        Get
            Return _PurchasesInitials
        End Get
        Set(ByVal value As String)
            _PurchasesInitials = value
        End Set
    End Property

    Private _SalesInitials As String
    Public Property SalesInitials() As String
        Get
            Return _SalesInitials
        End Get
        Set(ByVal value As String)
            _SalesInitials = value
        End Set
    End Property

    Private _ENTLimit As String
    Public Property ENTLimit() As String
        Get
            Return _ENTLimit
        End Get
        Set(ByVal value As String)
            _ENTLimit = value
        End Set
    End Property

    Private _MCInput As String
    Public Property MCInput() As String
        Get
            Return _MCInput
        End Get
        Set(ByVal value As String)
            _MCInput = value
        End Set
    End Property

    Private _MCDTDiff As String
    Public Property MCDTDiff() As String
        Get
            Return _MCDTDiff
        End Get
        Set(ByVal value As String)
            _MCDTDiff = value
        End Set
    End Property

    Private _MinimumTolerance As String
    Public Property MinimumTolerance() As String
        Get
            Return _MinimumTolerance
        End Get
        Set(ByVal value As String)
            _MinimumTolerance = value
        End Set
    End Property

    Private _MaximumTolerance As String
    Public Property MaximumTolerance() As String
        Get
            Return _MaximumTolerance
        End Get
        Set(ByVal value As String)
            _MaximumTolerance = value
        End Set
    End Property

    Private _SavingDelayPeriod As String
    Public Property SavingDelayPeriod() As String
        Get
            Return _SavingDelayPeriod
        End Get
        Set(ByVal value As String)
            _SavingDelayPeriod = value
        End Set
    End Property

    Private _WeightStability As String
    Public Property WeightStability() As String
        Get
            Return _WeightStability
        End Get
        Set(ByVal value As String)
            _WeightStability = value
        End Set
    End Property

    Private _SlipTkt As String
    Public Property SlipTkt() As String
        Get
            Return _SlipTkt
        End Get
        Set(ByVal value As String)
            _SlipTkt = value
        End Set
    End Property

    Private _TruckDelivery As String
    Public Property TruckDelivery() As String
        Get
            Return _TruckDelivery
        End Get
        Set(ByVal value As String)
            _TruckDelivery = value
        End Set
    End Property

    Private _TruckDeliveryLockPeriod As String
    Public Property TruckDeliveryLockPeriod() As String
        Get
            Return _TruckDeliveryLockPeriod
        End Get
        Set(ByVal value As String)
            _TruckDeliveryLockPeriod = value
        End Set
    End Property

    Private _WeightComparison As String
    Public Property WeightComparison() As String
        Get
            Return _WeightComparison
        End Get
        Set(ByVal value As String)
            _WeightComparison = value
        End Set
    End Property

    Private _WeightLockPeriod As String
    Public Property WeightLockPeriod() As String
        Get
            Return _WeightLockPeriod
        End Get
        Set(ByVal value As String)
            _WeightLockPeriod = value
        End Set
    End Property

#End Region

#Region "SENSOR"
    Private _SNSR_ENABLED As String
    Public Property SNSR_ENABLED() As String
        Get
            Return _SNSR_ENABLED
        End Get
        Set(ByVal value As String)
            _SNSR_ENABLED = value
        End Set
    End Property

    Private _SNSR_TCP As String
    Public Property SNSR_TCP() As String
        Get
            Return _SNSR_TCP
        End Get
        Set(ByVal value As String)
            _SNSR_TCP = value
        End Set
    End Property

    Private _SNSR_BitsPerSecond As String
    Public Property SNSR_BitsPerSecond() As String
        Get
            Return _SNSR_BitsPerSecond
        End Get
        Set(ByVal value As String)
            _SNSR_BitsPerSecond = value
        End Set
    End Property

    Private _SNSR_DeviceId As String
    Public Property SNSR_DeviceId() As String
        Get
            Return _SNSR_DeviceId
        End Get
        Set(ByVal value As String)
            _SNSR_DeviceId = value
        End Set
    End Property

    Private _SNSR_IPaddress As String
    Public Property SNSR_IPaddress() As String
        Get
            Return _SNSR_IPaddress
        End Get
        Set(ByVal value As String)
            _SNSR_IPaddress = value
        End Set
    End Property

    Private _SNSR_Password As String
    Public Property SNSR_Password() As String
        Get
            Return _SNSR_Password
        End Get
        Set(ByVal value As String)
            _SNSR_Password = value
        End Set
    End Property

    Private _SNSR_PortName As String
    Public Property SNSR_PortName() As String
        Get
            Return _SNSR_PortName
        End Get
        Set(ByVal value As String)
            _SNSR_PortName = value
        End Set
    End Property

    Private _SNSR_Protocol As String
    Public Property SNSR_Protocol() As String
        Get
            Return _SNSR_Protocol
        End Get
        Set(ByVal value As String)
            _SNSR_Protocol = value
        End Set
    End Property

    Private _SNSR_TCPPort As String
    Public Property SNSR_TCPPort() As String
        Get
            Return _SNSR_TCPPort
        End Get
        Set(ByVal value As String)
            _SNSR_TCPPort = value
        End Set
    End Property

    Private _SNSR_TimeOut As String
    Public Property SNSR_TimeOut() As String
        Get
            Return _SNSR_TimeOut
        End Get
        Set(ByVal value As String)
            _SNSR_TimeOut = value
        End Set
    End Property
#End Region

#Region "ASC"
    Private _Acs As String
    Public Property Acs() As String
        Get
            Return _Acs
        End Get
        Set(ByVal value As String)
            _Acs = value
        End Set
    End Property

    Private _Ble As String
    Public Property Ble() As String
        Get
            Return _Ble
        End Get
        Set(ByVal value As String)
            _Ble = value
        End Set
    End Property

    Private _Cust As String
    Public Property Cust() As String
        Get
            Return _Cust
        End Get
        Set(ByVal value As String)
            _Cust = value
        End Set
    End Property

    Private _DT As String
    Public Property DT() As String
        Get
            Return _DT
        End Get
        Set(ByVal value As String)
            _DT = value
        End Set
    End Property

    Private _DV As String
    Public Property DV() As String
        Get
            Return _DV
        End Get
        Set(ByVal value As String)
            _DV = value
        End Set
    End Property

    Private _DY As String
    Public Property DY() As String
        Get
            Return _DY
        End Get
        Set(ByVal value As String)
            _DY = value
        End Set
    End Property

    Private _ET As String
    Public Property ET() As String
        Get
            Return _ET
        End Get
        Set(ByVal value As String)
            _ET = value
        End Set
    End Property

    Private _EY As String
    Public Property EY() As String
        Get
            Return _EY
        End Get
        Set(ByVal value As String)
            _EY = value
        End Set
    End Property

    Private _Haul As String
    Public Property Haul() As Boolean
        Get
            Return _Haul
        End Get
        Set(ByVal value As Boolean)
            _Haul = value
        End Set
    End Property

    Private _Insp As String
    Public Property Insp() As String
        Get
            Return _Insp
        End Get
        Set(ByVal value As String)
            _Insp = value
        End Set
    End Property

    Private _InY As String
    Public Property InY() As String
        Get
            Return _InY
        End Get
        Set(ByVal value As String)
            _InY = value
        End Set
    End Property

    Private _LV As String
    Public Property LV() As String
        Get
            Return _LV
        End Get
        Set(ByVal value As String)
            _LV = value
        End Set
    End Property

    Private _Mods As String
    Public Property Mods() As String
        Get
            Return _Mods
        End Get
        Set(ByVal value As String)
            _Mods = value
        End Set
    End Property

    Private _MS As String
    Public Property MS() As String
        Get
            Return _MS
        End Get
        Set(ByVal value As String)
            _MS = value
        End Set
    End Property

    Private _OfL As String
    Public Property OfL() As String
        Get
            Return _OfL
        End Get
        Set(ByVal value As String)
            _OfL = value
        End Set
    End Property

    Private _OnL As String
    Public Property OnL() As String
        Get
            Return _OnL
        End Get
        Set(ByVal value As String)
            _OnL = value
        End Set
    End Property

    Private _Prod As String
    Public Property Prod() As String
        Get
            Return _Prod
        End Get
        Set(ByVal value As String)
            _Prod = value
        End Set
    End Property

    Private _Rec As String
    Public Property Rec() As String
        Get
            Return _Rec
        End Get
        Set(ByVal value As String)
            _Rec = value
        End Set
    End Property

    Private _Rmats As String
    Public Property Rmats() As String
        Get
            Return _Rmats
        End Get
        Set(ByVal value As String)
            _Rmats = value
        End Set
    End Property

    Private _RT As String
    Public Property RT() As String
        Get
            Return _RT
        End Get
        Set(ByVal value As String)
            _RT = value
        End Set
    End Property

    Private _Sign As String
    Public Property Sign() As String
        Get
            Return _Sign
        End Get
        Set(ByVal value As String)
            _Sign = value
        End Set
    End Property

    Private _SS As String
    Public Property SS() As String
        Get
            Return _SS
        End Get
        Set(ByVal value As String)
            _SS = value
        End Set
    End Property

    Private _Sup As String
    Public Property Sup() As String
        Get
            Return _Sup
        End Get
        Set(ByVal value As String)
            _Sup = value
        End Set
    End Property

    Private _Trk As String
    Public Property Trk() As String
        Get
            Return _Trk
        End Get
        Set(ByVal value As String)
            _Trk = value
        End Set
    End Property

    Private _TrkC As String
    Public Property TrkC() As String
        Get
            Return _TrkC
        End Get
        Set(ByVal value As String)
            _TrkC = value
        End Set
    End Property


#End Region

#Region "GOOGLE DRIVE"
    Private _client_id As String
    Public Property client_id() As String
        Get
            Return _client_id
        End Get
        Set(ByVal value As String)
            _client_id = value
        End Set
    End Property

    Private _client_secret As String
    Public Property client_secret() As String
        Get
            Return _client_secret
        End Get
        Set(ByVal value As String)
            _client_secret = value
        End Set
    End Property

    Private _folder_name As String
    Public Property folder_name() As String
        Get
            Return _folder_name
        End Get
        Set(ByVal value As String)
            _folder_name = value
        End Set
    End Property

#End Region

#Region "CAMERA"
    Private _EnablePCapture As String
    Public Property EnablePCapture() As String
        Get
            Return _EnablePCapture
        End Get
        Set(ByVal value As String)
            _EnablePCapture = value
        End Set
    End Property

    Private _EnableSCapture As String
    Public Property EnableSCapture() As String
        Get
            Return _EnableSCapture
        End Get
        Set(ByVal value As String)
            _EnableSCapture = value
        End Set
    End Property


    Private _TimeOut As String
    Public Property TimeOut() As String
        Get
            Return _TimeOut
        End Get
        Set(ByVal value As String)
            _TimeOut = value
        End Set
    End Property

    Private _IP1 As String
    Public Property IP1() As String
        Get
            Return _IP1
        End Get
        Set(ByVal value As String)
            _IP1 = value
        End Set
    End Property

    Private _UID1 As String
    Public Property UID1() As String
        Get
            Return _UID1
        End Get
        Set(ByVal value As String)
            _UID1 = value
        End Set
    End Property

    Private _PWD1 As String
    Public Property PWD1() As String
        Get
            Return _PWD1
        End Get
        Set(ByVal value As String)
            _PWD1 = value
        End Set
    End Property

    Private _BN1 As String
    Public Property BN1() As String
        Get
            Return _BN1
        End Get
        Set(ByVal value As String)
            _BN1 = value
        End Set
    End Property

    Private _NETMASK1 As String
    Public Property NETMASK1() As String
        Get
            Return _NETMASK1
        End Get
        Set(ByVal value As String)
            _NETMASK1 = value
        End Set
    End Property

    Private _GATEWAY1 As String
    Public Property GATEWAY1() As String
        Get
            Return _GATEWAY1
        End Get
        Set(ByVal value As String)
            _GATEWAY1 = value
        End Set
    End Property

    Private _WEB_PORT1 As String
    Public Property WEB_PORT1() As String
        Get
            Return _WEB_PORT1
        End Get
        Set(ByVal value As String)
            _WEB_PORT1 = value
        End Set
    End Property

    Private _DEV_PORT1 As String
    Public Property DEV_PORT1() As String
        Get
            Return _DEV_PORT1
        End Get
        Set(ByVal value As String)
            _DEV_PORT1 = value
        End Set
    End Property

    Private _RSTP_PORT1 As String
    Public Property RSTP_PORT1() As String
        Get
            Return _RSTP_PORT1
        End Get
        Set(ByVal value As String)
            _RSTP_PORT1 = value
        End Set
    End Property

    Private _IP2 As String
    Public Property IP2() As String
        Get
            Return _IP2
        End Get
        Set(ByVal value As String)
            _IP2 = value
        End Set
    End Property

    Private _UID2 As String
    Public Property UID2() As String
        Get
            Return _UID2
        End Get
        Set(ByVal value As String)
            _UID2 = value
        End Set
    End Property

    Private _PWD2 As String
    Public Property PWD2() As String
        Get
            Return _PWD2
        End Get
        Set(ByVal value As String)
            _PWD2 = value
        End Set
    End Property

    Private _BN2 As String
    Public Property BN2() As String
        Get
            Return _BN2
        End Get
        Set(ByVal value As String)
            _BN2 = value
        End Set
    End Property

    Private _NETMASK2 As String
    Public Property NETMASK2() As String
        Get
            Return _NETMASK2
        End Get
        Set(ByVal value As String)
            _NETMASK2 = value
        End Set
    End Property

    Private _GATEWAY2 As String
    Public Property GATEWAY2() As String
        Get
            Return _GATEWAY2
        End Get
        Set(ByVal value As String)
            _GATEWAY2 = value
        End Set
    End Property

    Private _WEB_PORT2 As String
    Public Property WEB_PORT2() As String
        Get
            Return _WEB_PORT2
        End Get
        Set(ByVal value As String)
            _WEB_PORT2 = value
        End Set
    End Property

    Private _DEV_PORT2 As String
    Public Property DEV_PORT2() As String
        Get
            Return _DEV_PORT2
        End Get
        Set(ByVal value As String)
            _DEV_PORT2 = value
        End Set
    End Property

    Private _RSTP_PORT2 As String
    Public Property RSTP_PORT2() As String
        Get
            Return _RSTP_PORT2
        End Get
        Set(ByVal value As String)
            _RSTP_PORT2 = value
        End Set
    End Property
#End Region
#End Region

#Region "8 DRAGON"
    Private _W_FEE As Double
    Public Property W_FEE() As Double
        Get
            Return _W_FEE
        End Get
        Set(ByVal value As Double)
            _W_FEE = value
        End Set
    End Property

#End Region

#Region "EVER_GREEN"
    Public Property _CAM_1_IP As String
    Public Property CAM_1_IP As String
        Get
            Return _CAM_1_IP
        End Get
        Set(ByVal value As String)
            _CAM_1_IP = value
        End Set
    End Property

    Public Property _CAM_2_IP As String
    Public Property CAM_2_IP As String
        Get
            Return _CAM_2_IP
        End Get
        Set(ByVal value As String)
            _CAM_2_IP = value
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
#End Region
End Class


Public Class cdes



#Region "FORM KEYDON"

   

    'Private Sub FrmTransaction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    ' GO TO NEXT CONTROL ON PRESSING ENTER
    '    If e.Alt Or e.Control Or e.Shift = False Then
    '        If e.KeyCode = Keys.Enter Then
    '            If TypeOf Me.ActiveControl Is MykeCtrlEx.PushButton Then Exit Sub
    '            SelectNextControl(Me.ActiveControl, True, True, True, True)
    '        End If
    '    End If

    ' If e.Alt Or e.Shift = True Then Exit Sub
    'If e.Control = True Then
    '    Select Case e.KeyCode
    '        Case Keys.A
    '            BtnAdd_Click(sender, e)
    '        Case Keys.E
    '            BtnEdit_Click(sender, e)
    '        Case Keys.S
    '            BtnSave_Click(sender, e)
    '    End Select
    'Else
    '    Select Case e.KeyCode
    '        Case Keys.Delete
    '            BtnDelete_Click(sender, e)
    '        Case Keys.Escape
    '            BtnCancel_Click(sender, e)
    '    End Select
    'End If

    '    If e.Alt = True Then Exit Sub
    '    If e.Control = True Then Exit Sub
    '    If e.Shift = True Then Exit Sub

    '    Select Case e.KeyCode
    '        Case Keys.F1
    '            If BtnIn.Enabled = True Then BtnIn_Click(sender, e)
    '        Case Keys.F2
    '            If Btnsave.Enabled = True Then Btnsave_Click(sender, e)
    '        Case Keys.Escape
    '            If Btncancel.Enabled = True Then Btncancel_Click(sender, e)
    '        Case Keys.F4
    '            If BtnRePrint.Enabled = True Then BtnRePrint_Click(sender, e)
    '        Case Keys.F5
    '            ' If BtnGross.Enabled = True Then BtnGross_Click(sender, e)
    '        Case Keys.F6
    '            ' If BtnTare.Enabled = True Then BtnTare_Click(sender, e)
    '        Case Keys.F7
    '            'If BtnReset.Enabled = True Then BtnReset_Click(sender, e)
    '    End Select
    'End Sub
#End Region

#Region "LIST TABLE STRINGS"
    'gen_mod.vs.AddRange(From a As String In (From str As DataRow In (_rp0cDB._rQRY(ccnfg, v_mod.lst_str_v, "vehicles", False, , )) Select str.Item(0))
#End Region

#Region "UPPER CASE ALL CBO"
    Public Shared Sub uc_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = Convert.ToChar(e.KeyChar.ToString.ToUpper)
    End Sub
#End Region

#Region "SET PHOTO DIALOG"

    'Dim OFdialog As New OpenFileDialog

    '    OFdialog.Multiselect = False
    '    OFdialog.DefaultExt = "JPEG image [*.jpg]|"
    '    OFdialog.AddExtension = False
    '    OFdialog.Filter = "JPEG Image [*.jpg]|*.jpg| Bitmap Image [*.BMP]|*.BMP| Png [*.PNG]|*.Png"
    '    OFdialog.FileName = ""
    '    OFdialog.ShowDialog()
    '    If String.IsNullOrEmpty(OFdialog.FileName) Then Exit Sub

    '    pt_img.SizeMode = PictureBoxSizeMode.StretchImage
    '    pt_img.Image = Image.FromFile(OFdialog.FileName)
    '    pt_loc = OFdialog.FileName

#End Region
End Class

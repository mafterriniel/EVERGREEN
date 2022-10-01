Imports System.Windows.Forms
Imports System.Drawing

Public Class _mdiS
    Public Sub _setFS()
        frm.Left = 0
        frm.Top = 0
        frm.Height = Screen.PrimaryScreen.WorkingArea.Height + (Screen.PrimaryScreen.WorkingArea.Height * 0.057)
        frm.Width = (Screen.PrimaryScreen.WorkingArea.Width)
        frm.Size = SystemInformation.PrimaryMonitorSize
        frm.StartPosition = FormStartPosition.CenterScreen
        '  Me.BackgroundImage = My.Resources.uppc_main_bg
        frm.BackgroundImageLayout = ImageLayout.Stretch
        _setST()
        GC.Collect()
        GC.SuppressFinalize(Me)
    End Sub

    Public frm As Form
    Public maxButton As Button = Nothing
    Public minButton As Button = Nothing
    Public closeButton As Button = Nothing

    Private Sub _setST(Optional ByVal ws As FormWindowState = FormWindowState.Maximized)
        With frm
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .BackColor = Color.FromArgb(255, 255, 255)

            If IsNothing(maxButton) = False Then maxButton.Image = Global.cl2_g3n_.My.Resources.maximum_gray
            If IsNothing(minButton) = False Then minButton.Image = Global.cl2_g3n_.My.Resources.minimum_gray
            If IsNothing(closeButton) = False Then closeButton.Image = Global.cl2_g3n_.My.Resources.close_gray

            If IsNothing(maxButton).Equals(False) Then AddHandler maxButton.Click, AddressOf MaximizeBtn
            If IsNothing(minButton).Equals(False) Then AddHandler minButton.Click, AddressOf MinimizeBtn
            If IsNothing(closeButton).Equals(False) Then AddHandler closeButton.Click, AddressOf CloseBtn
            If IsNothing(maxButton).Equals(False) Then maxButton.Enabled = False
            .StartPosition = FormStartPosition.CenterScreen
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = ws
        End With
    End Sub


    Protected Sub MaximizeBtn()
        If frm.WindowState = FormWindowState.Maximized Then
            frm.WindowState = FormWindowState.Normal
        Else
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Protected Sub MinimizeBtn()
        frm.WindowState = FormWindowState.Minimized
    End Sub

    Protected Sub CloseBtn()
        frm.Close()
    End Sub

    Protected Sub SizedChanged()
        If frm.WindowState = FormWindowState.Maximized Then
            If IsNothing(maxButton).Equals(False) Then maxButton.Image = Global.cl2_g3n_.My.Resources.restore_gray
        Else
            If IsNothing(minButton).Equals(False) Then maxButton.Image = Global.cl2_g3n_.My.Resources.Resources.maximum_gray
        End If
    End Sub
End Class

Public Class Viewer

    Dim StartIndex As Integer = 1
    Dim EndIndex As Integer = 673
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartIndex = GetSetting(Application.ProductName, Name, "StartIndex", StartIndex)
        LoadImages(StartIndex)

    End Sub

    Sub LoadImages(ByVal i As Integer)
        Try
            'SplitContainer1.Panel1.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\Quran_Page_" & i.ToString.PadLeft(3, "0") & ".fbk")
            'SplitContainer1.Panel2.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\Quran_Page_" & (i + 1).ToString.PadLeft(3, "0") & ".fbk")
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\data\Quran_Page_" & i.ToString.PadLeft(3, "0") & ".fbk")
            PictureBox2.Image = Image.FromFile(Application.StartupPath & "\data\Quran_Page_" & (i + 1).ToString.PadLeft(3, "0") & ".fbk")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, SplitContainer1.KeyDown
        If (e.KeyData = Keys.Up Or e.KeyData = Keys.Right) And StartIndex > 1 Then
            StartIndex -= 2
        ElseIf (e.KeyData = Keys.Down Or e.KeyData = Keys.Left) And StartIndex < EndIndex Then
            StartIndex += 2
        ElseIf e.KeyData = Keys.Home Then
            StartIndex = 1
        ElseIf e.KeyData = Keys.End Then
            StartIndex = EndIndex
        ElseIf e.KeyData = Keys.PageUp And StartIndex > 1 Then
            StartIndex -= 20
            If StartIndex < 1 Then StartIndex = 1
        ElseIf e.KeyData = Keys.PageDown And StartIndex < EndIndex Then
            StartIndex += 20
            If StartIndex > EndIndex Then StartIndex = EndIndex
        Else
            Return
        End If
        LoadImages(StartIndex)
        SaveSetting(Application.ProductName, Name, "StartIndex", StartIndex)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    'Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
    '    StartIndex += 2
    '    LoadImages(StartIndex)
    '    SaveSetting(Application.ProductName, Name, "StartIndex", StartIndex)
    'End Sub

    'Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    '    StartIndex -= 2
    '    LoadImages(StartIndex)
    '    SaveSetting(Application.ProductName, Name, "StartIndex", StartIndex)
    'End Sub
End Class

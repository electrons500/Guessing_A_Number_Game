Public Class FrmGame
    Dim counter As Integer = 5



    Private Sub FrmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btnguess.Visible = False
        lblCounter.Text = counter
        lblRandomNumber.Visible = False
    End Sub


    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        lblRandomNumber.Text = CInt((Rnd() * 10) * 3) + CInt((Rnd() * 10))
        txtNumber.ReadOnly = False
        Btnguess.Visible = True
        BtnStart.Visible = False
    End Sub

    Private Sub Btnguess_Click(sender As Object, e As EventArgs) Handles Btnguess.Click
        Try
            If txtNumber.Text = String.Empty Or Not IsNumeric(txtNumber.Text) Then
                MessageBox.Show("Please enter a guess number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim Randnumber As Integer = Convert.ToInt32(lblRandomNumber.Text)
                Dim guessNumber As Integer = Convert.ToInt32(txtNumber.Text)
                If Not counter = 0 Then
                    If guessNumber > Randnumber Then
                        MessageBox.Show("Hint: Go Lower", "Hint information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtNumber.Clear()

                    ElseIf guessNumber < Randnumber Then
                        MessageBox.Show("Hint: Go higher", "Hint information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtNumber.Clear()

                    Else
                        MessageBox.Show("Congratulations you have won GHC 50", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim dialog As DialogResult = MessageBox.Show("Do want to Play again?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If dialog = DialogResult.Yes Then
                            Btnguess.Hide()
                            BtnStart.Show()
                            txtNumber.Clear()
                            txtNumber.ReadOnly = True
                            counter = 6

                        Else
                            Me.Close()

                        End If
                    End If
                Else
                    Dim GameOverdialog As DialogResult = MessageBox.Show("Game Over! " & ControlChars.NewLine & "Do you want to Play again?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If GameOverdialog = DialogResult.Yes Then
                        Btnguess.Hide()
                        BtnStart.Show()
                        txtNumber.Clear()
                        txtNumber.ReadOnly = True
                        counter = 6
                    Else
                        Me.Close()
                    End If

                End If

                counter -= 1
                lblCounter.Text = counter

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Btnquit_Click(sender As Object, e As EventArgs) Handles Btnquit.Click
        Me.Close()

    End Sub
End Class
